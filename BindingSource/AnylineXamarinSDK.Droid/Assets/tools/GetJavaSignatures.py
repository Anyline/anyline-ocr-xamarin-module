import sys
import os

"""
This python script searches the javadoc for all classes and creates a list that consists of every signature
that has at least one parameter.
"""

# returns the string between two given characters
def find_between(s, first, last):
    try:
        start = s.index(first) + len(first)
        end = s.index(last, start)
        return s[start:end]
    except ValueError:
        return ""


# recursively crawls the given directory and retrieves all java method signatures that have 1 or more parameters,
# based on the residing javadoc in that directory
def getJavaSignatures(dir):

    # recursively gather all html files in the folder
    files = [os.path.join(dp, f) for dp, dn, filenames in os.walk(dir) for f in filenames if
              os.path.splitext(f)[1] == '.html']

    # filter out some other files
    files = filter(lambda x: x.find('package-') == -1
                             and x.find('constant-') == -1
                             and x.find('allclasses-') == -1
                             and x.find('deprecated-') == -1
                             and x.find('help-') == -1
                             and x.find('overview-') == -1
                             and x.find('index') == -1
                   , files)

    result = []

    # crawl files
    for f in files:
        with open(os.path.abspath(f)) as fp:

            #print('Parsing ' + f.split('\\')[-1] + '..')

            _class = ""
            lines = []

            hasSignature = True

            l = ""
            add = False
            for line in fp:

                # find class name e.g.:
                # <span class ="typeNameLabel" >AnylineController</span>
                if line.find('typeNameLabel">') != -1 and _class == "":
                    _class = line.split('typeNameLabel">')[1].split('</')[0]
                    _class = _class.split('&lt;')[0]

                # find out if currently crawling the correct 'section'
                if line.find('<!-- ==') != -1:
                    if line.find('ENUM') != -1:
                        hasSignature = False
                    else:  # close this section again
                        hasSignature = True

                if not hasSignature:
                    continue

                # add relevant lines for method/parameter names
                if not add:
                    if line.find('memberNameLink">') != -1:
                        add = True

                if add:
                    l += line.strip('\r').strip('\n').strip(' ').replace('&nbsp;', ' ').replace(',', ', ')
                    if line.find('</code>') != -1:

                        lines.append(l)
                        l = ""
                        add = False

            for line in lines:

                # find method name
                _method = line[line.find('#'):len(line)]
                _method = _method[_method.find('">') + 2:len(_method)].split('</a>')[0]

                _params = find_between(line, '(', ')')

                # extract href tags
                off = False
                tmp = ""
                for c in _params:
                    if c == '<':
                        off = True

                    if not off:
                        tmp += c

                    if c == '>':
                        off = False

                _params = tmp

                if _params != "":

                    result.append(_class + '.' + _method + '(' + _params + ')')

    return result