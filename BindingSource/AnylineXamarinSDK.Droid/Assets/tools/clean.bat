@echo off
SET FILE=%1\Generated.xml
if exist %FILE% (
    echo File %FILE% already exists. skipping..
) else (
	echo ^<metadata^>THIS FILE WILL BE AUTO-GENERATED^</metadata^> > %FILE%
)