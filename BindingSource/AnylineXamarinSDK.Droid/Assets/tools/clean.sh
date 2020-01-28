#!/bin/bash
FILE="$1"/Generated.xml
if [ -e "$FILE" ]
then
  echo File "$FILE" already exists. skipping...
else
  echo "<metadata>THIS FILE WILL BE AUTO-GENERATED</metadata>" > "$FILE"
fi
