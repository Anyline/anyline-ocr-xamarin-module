#!/bin/bash
if [ -e Generated.xml ]
then
  echo File Generated.xml already exists. skipping...
else
  echo "<metadata>THIS FILE WILL BE AUTO-GENERATED</metadata>" > Generated.xml
fi
