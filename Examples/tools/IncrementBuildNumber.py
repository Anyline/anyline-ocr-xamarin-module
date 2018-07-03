import sys
import os


# the main script
def main(argv):
    if len(argv) != 2:
        sys.exit("Correct usage: IncrementBuildNumber <file> (only accepts .plist or .xml files)")

    input_path = os.path.abspath(argv[1])

    print("Auto-Incrementing build version for " + input_path + "...")

    output = []

    # open file to read
    with open(input_path) as f:

        # AndroidManifest.xml
        if input_path.endswith('xml'):

            replace_string = 'android:versionCode="'

            for line in f:

                new = line

                if line.find(replace_string) != -1:

                    split = line.split(replace_string, 2)
                    end = split[1].split('"')

                    version = int(end[0])
                    version += 1
                    new = split[0] + replace_string + str(version) + '"' + end[1]

                output.append(new)

        # Info.plist
        if input_path.endswith('plist'):

            edit_next = False

            for line in f:

                new = line

                if not edit_next:

                    if line.find('CFBundleVersion') != -1:
                        edit_next = True
                else:

                    edit_next = False
                    string = line.replace('<string>', '').replace(' ', '').replace('</string>', '').replace('\n', '')
                    version = int(string)
                    version += 1
                    new = '\t' + '<string>' + str(version) + '</string>' + '\n'

                output.append(new)

    # open file to write
    with open(input_path, 'w+') as f:

        for line in output:

            f.write(line)


# the entry point
if __name__ == "__main__":
    main(sys.argv)