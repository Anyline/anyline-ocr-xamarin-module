@echo off
SET FILE=%1
if exist %FILE% (
    echo File %FILE% already exists. skipping..
) else (
	echo ^<metadata^>THIS FILE WILL BE AUTO-GENERATED^</metadata^> > %FILE%
)