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
    if len(argv) != 4 and len(argv) != 5:
        sys.exit("Correct usage: GetXMLMetadata <.cs source folder> <output file> <javadoc folder>")

    input_path = os.path.abspath(argv[1])
    output_path = os.path.abspath(argv[2])
    java_path = os.path.abspath(argv[3])

    is_detailed_output = False
    if len(argv) == 5:
        if argv[4] == "1":
            is_detailed_output = True

    print ('######################################################################################################')
    print ('#                        AUTO-GENERATING METADATA TRANSFORMS FROM JAVA DOC                           #')
    print ('######################################################################################################')

    file_hash = ""
    output_filename = output_path.split('\\')[-1]

    # remove existing file first
    if os.path.exists(output_path):

        file_hash = md5(output_path)
        os.remove(output_path)

    print('Existing file hash for file ' + '"' + output_filename + '"' + ':      ' + file_hash)

    # open file to write
    with open(output_path, 'w+') as fo:

        fo.write('<!-- THIS FILE IS AUTO-GENERATED! DO NOT EDIT! -->\n')
        fo.write('\n')
        fo.write('<metadata>\n\n')

        java_signatures = getJavaSignatures(java_path)

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

                        param_count = int(line.split('count(parameter)=', 1)[1][0])

                        meta_signature = getMethodSignature(line)

                        fo.write("<!-- " + meta_signature + " -->" + '\n')

                        matches = filter(lambda x: x.startswith(meta_signature.split('(')[0]), java_signatures)

                        meta_param_types = []

                        # list of types in meta_signature
                        _ = find_between(meta_signature, '(', ')') + ', '
                        _ = _.split(', ')
                        for p in _:
                            if p != '':
                                _ = p.split(' ')[0]
                                _ = _.split('.')

                                # append the last element (e.g. android.content.Context -> Context)
                                meta_param_types.append(_[-1])

                        match = None
                        for m in matches:

                            is_match = True
                            for mp in meta_param_types:
                                if m.find(mp) == -1:
                                    is_match = False

                            if len(meta_param_types) != len(m.split(', ')):
                                is_match = False

                            if is_match:
                                match = m
                                break

                        if match is not None:

                            param_names = []
                            param_types = []

                            if is_detailed_output:
                                print match

                            # list of types and names in matching signature
                            _ = find_between(match, '(', ')') + ', '

                            fix = False

                            # fix for Map <a, b>
                            var = find_between(_, 'Map&lt;', '&gt;')
                            if var != '':
                                fix = True
                                _ = _.replace(var, "=====")
                                var = var.replace(', ', ',')
                                _ = _.replace("=====", var)

                            _ = _ + ', '

                            _ = _.split(', ')

                            for p in _:
                                if p != '':
                                    type_name = p.split(' ')[0]

                                    if fix == True:
                                        type_name = type_name.replace(',', ', ')

                                    param_types.append(type_name)

                                    param_names.append(p.split(' ')[1])

                            # for i in range(0, len(param_names)):
                            #    print param_types[i] + " - " + param_names[i]

                            for p in range(1, param_count + 1):

                                param_text = line.split(']]"', 1)

                                param_text[0] = param_text[0] + ']]/parameter[' + str(p) + ']"'

                                param_text = param_text[0] + param_text[1]

                                # HINT: may NEVER be in caps lock or start with big letters!
                                param_text = param_text.replace('???', param_names[p - 1])

                                if is_detailed_output:
                                    print param_text

                                fo.write(param_text + '\n')

                        if is_detailed_output:
                            print ""

                        fo.write('\r')

            fo.write('\r')

        fo.write('</metadata>\n')

    file_hash_new = md5(output_path)

    print('Updated File hash for file ' + '"' + output_filename + '"' + ':       ' + file_hash_new)

    print ('######################################################################################################')

    if file_hash != file_hash_new:

        print('WARNING: File ' + '"' + output_filename + '"' +
              ' has been updated! Build the project once more to apply the generated XML transforms!')

    else:
        print("Success.")

    sys.exit(0)


# the entry point
if __name__ == "__main__":
    main(sys.argv)
