import sys
import os
import hashlib
from GetJavaSignatures import *

"""
This python script retrieves all XML bindings from all generated .cs files when given
an input directory (probably '..\..\obj\Debug\generated\src'). It will output all XML Metadata
that have 1 or more parameters with the matching parameter names.

This script is compiled with py2exe to a Windows executable.

For more information about py2exe, see http://www.py2exe.org/index.cgi/Tutorial
"""


# get md5 hash of file contents
def md5(f):
    hash_md5 = hashlib.md5()
    with open(f, "rb") as fo:
        for chunk in iter(lambda: fo.read(4096), b""):
            hash_md5.update(chunk)
    return hash_md5.hexdigest()


# retrieves a "meta" signature to make it easier to match against the java method signatures
def getMethodSignature(text):
    _cl = 'class[@name=' + "'"
    _i = 'interface[@name=' + "'"
    _m = 'method[@name=' + "'"
    _ct = 'constructor[@name=' + "'"
    _t = '@type=' + "'"

    # find class name
    if text.find(_cl) != -1:
        namePos = text.find(_cl) + len(_cl)
    else:
        namePos = text.find(_i) + len(_i)

    name = text[namePos:len(text)].split("'")[0]

    # find method name
    if text.find(_m) != -1:
        methodPos = text.find(_m) + len(_m)
    else:
        methodPos = text.find(_ct) + len(_ct)

    method = text[methodPos:len(text)].split("'")[0]

    # find list of types
    typesPos = [i + len(_t) for i in range(len(text)) if text.startswith(_t, i)]

    types = ""
    for x in typesPos:
        types = types + text[x:len(text)].split("'")[0] + ', '

    types = types[0:len(types) - 2]

    return name + "." + method + "(" + types + ")"


# the main script
def main(argv):
    if len(argv) != 4:
        sys.exit("Please locate the input directory of the generated .cs classes, the output file path and java path!")

    input_path = os.path.abspath(argv[1])
    output_path = os.path.abspath(argv[2])
    java_path = os.path.abspath(argv[3])

    print ('######################################################################################################')
    print ('#                        AUTO-GENERATING METADATA TRANSFORMS FROM JAVA DOC                           #')
    print ('######################################################################################################')

    fileHash = ""
    output_filename = output_path.split('\\')[-1]

    # remove existing file first
    if os.path.exists(output_path):

        fileHash = md5(output_path)
        os.remove(output_path)

    print('Existing file hash for file ' + '"' + output_filename + '"' + ':      ' + fileHash)

    # open file to write
    with open(output_path, 'w+') as fo:

        fo.write('<!-- THIS FILE IS AUTO-GENERATED! DO NOT EDIT! -->\n')
        fo.write('\n')
        fo.write('<metadata>\n\n')

        javaSignatures = getJavaSignatures(java_path)

        files = next(os.walk(input_path))[2]
        files = filter(lambda x: x.endswith('.cs') and x.find('__') == -1, files)

        for f in files:

            fo.write('<!-- File: ' + f + ' -->' + '\r\n')

            with open(os.path.abspath(input_path + '\\' + f)) as fp:
                for line in fp:

                    if line.strip().startswith("// Metadata.xml"):

                        # ignore everything with less than 1 parameter
                        if line.find('count(parameter)=0') != -1 or line.find('count(parameter)') == -1:
                            continue

                        i = line.find('path="')
                        line = line[i:len(line)].rstrip('\n')
                        line = "<attr " + line + " name=" + '"' + "managedName" + '"' + ">???</attr>"

                        paramCount = int(line.split('count(parameter)=', 1)[1][0])

                        metaSignature = getMethodSignature(line)

                        fo.write("<!-- " + metaSignature + " -->" + '\n')

                        matches = filter(lambda x: x.startswith(metaSignature.split('(')[0]), javaSignatures)

                        metaParamTypes = []

                        # list of types in metaSignature
                        _ = find_between(metaSignature, '(', ')') + ', '
                        _ = _.split(', ')
                        for p in _:
                            if p != '':
                                _ = p.split(' ')[0]
                                _ = _.split('.')

                                # append the last element (e.g. android.content.Context -> Context)
                                metaParamTypes.append(_[-1])

                        match = None
                        for m in matches:

                            isMatch = True
                            for mp in metaParamTypes:
                                if m.find(mp) == -1:
                                    isMatch = False

                            if isMatch:
                                match = m
                                break

                        if match is not None:

                            paramNames = []
                            paramTypes = []

                            # list of types and names in matching signature
                            _ = find_between(match, '(', ')') + ', '
                            _ = _.split(', ')
                            for p in _:
                                if p != '':
                                    paramTypes.append(p.split(' ')[0])
                                    paramNames.append(p.split(' ')[1])

                            # for i in range(0, len(paramNames)):
                            #    print paramTypes[i] + " - " + paramNames[i]

                            for p in range(1, paramCount + 1):

                                paramText = line.split(']]"', 1)

                                paramText[0] = paramText[0] + ']]/parameter[' + str(p) + ']"'

                                paramText = paramText[0] + paramText[1]

                                # HINT: may NEVER be in capslock or start with big letters!
                                paramText = paramText.replace('???', paramNames[p - 1])

                                fo.write(paramText + '\n')

                        fo.write('\r')

            fo.write('\r')

        fo.write('</metadata>\n')

    fileHashNew = md5(output_path)

    print('Updated File hash for file ' + '"' + output_filename + '"' + ':       ' + fileHashNew)

    print ('######################################################################################################')

    if fileHash != fileHashNew:

        print('WARNING: File ' + '"' + output_filename + '"' +
              ' has been updated! Build the project once more to apply the generated XML transforms!')

    else:
        print("Success.")

    sys.exit(0)


# the entry point
if __name__ == "__main__":
    main(sys.argv)
