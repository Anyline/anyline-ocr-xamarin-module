import sys
import os
import shutil
from os import walk
from shutil import copyfile


# the main script: copies the AnylineResources.bundle to the app directory, updates csproj and nuget list
def main(argv):
    if len(argv) != 5:
        sys.exit("Wrong number of arguments!")

    bundle_input_path = os.path.abspath(argv[1])
    bundle_output_path = os.path.abspath(argv[2])
    csproj_file = os.path.abspath(argv[3])
    nuget_file = os.path.abspath(argv[4])

    print bundle_input_path
    print bundle_output_path
    print csproj_file

    print '------'

    # delete everything in output_path first!
    # create every directory if not exists
    # copy every file to output
    # meanwhile, fill lists with files

    if os.path.exists(bundle_output_path):
        shutil.rmtree(bundle_output_path)
    os.mkdir(bundle_output_path)

    new_root = "Resources\\AnylineResources.bundle"

    resource_list = []
    nuget_list= []
    new_csproj_content = []

    # copy files and feed resource list

    for (dirpath, dirnames, filenames) in walk(bundle_input_path):

        relative_path = dirpath[len(bundle_input_path):]
        output_path = bundle_output_path + relative_path

        if not os.path.exists(output_path):
            os.mkdir(output_path)

        for f in filenames:
            copyfile(dirpath + "\\" + f, output_path + "\\" + f)

            # append csproj list
            fstring = "    <BundleResource Include=" + '"' + new_root + chr(92)
            if relative_path > '':
                fstring = fstring + relative_path[1:] + chr(92)
            fstring = fstring + f.replace('@', '%40') + '"' + "/>"
            resource_list.append(fstring)

            # append nuget list
            nstring = "\t\t\t<file src="+ '"' + ".." + chr(92) + "AnylineResources.bundle" + chr(92)
            if relative_path > '':
                nstring = nstring + relative_path[1:] + chr(92)
            nstring = nstring + f + '"'
            nstring = nstring + " target=" + '"..\\..\\..\\AnylineResources.bundle' + relative_path + "\\" + '"/>'

            nuget_list.append(nstring)

    # insert resources in csproj file:

    insert_index = 0
    i = 0
    with open(csproj_file, 'r') as f:
        for line in f:
            if line.find('AnylineResources.bundle') == -1:
                new_csproj_content.append(line)
                i += 1
            if line.find('<BundleResource') != -1:
                insert_index = i

    i = 0
    with open(csproj_file, 'w') as f:
        for line in new_csproj_content:
            f.write(line)
            i += 1
            if i == insert_index:
                for new in resource_list:
                    f.write(new + '\n')

    # Insert resources in nuget file:
    new_nuget_content = []
    i = 0
    insert_index = 0
    with open(nuget_file, 'r') as f:
        for line in f:
            if line.find('AnylineResources.bundle') == -1 \
                    or (line.find('AnylineResources.bundle') != -1 and line.find('<file src=') == -1):
                new_nuget_content.append(line)
                i += 1
            if line.find('</files>') != -1:
                insert_index = i - 1

    i = 0
    with open(nuget_file, 'w') as f:
        for n in new_nuget_content:
            f.write(n)
            i += 1
            if i == insert_index:
                for l in nuget_list:
                    f.write(l + '\n')
    print "Done."


# the entry point
if __name__ == "__main__":
    main(sys.argv)
