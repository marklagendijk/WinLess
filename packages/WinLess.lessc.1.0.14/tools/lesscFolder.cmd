@ECHO OFF
REM This script compiles all less files of a folder (not recursively!) and outputs them to another folder.
SETLOCAL ENABLEDELAYEDEXPANSION
SET lessFolder=%1
SET cssFolder=%2
SET arguments=%3
CALL :dequote cssFolder
CALL :dequote lessFolder 
CALL :dequote arguments 

cd "%lessFolder%"

REM Foreach less file, call compile_less_file.bat with the filename as argument.
FOR %%f IN (*.less*) DO (
	SET cssFileName=%%f
	SET cssFileName=!cssFileName:.less.css=.css!
	SET cssFileName=!cssFileName:.less=.css!
	
	CALL "%~dp0\lessc.cmd" "%%f" "%cssFolder%\!cssFileName!" %arguments%
)

GOTO :EOF

:DeQuote
FOR %%G IN (%*) DO (
SET DeQuote.Variable=%%G
CALL SET DeQuote.Contents=%%!DeQuote.Variable!%%

IF [!DeQuote.Contents:~0^,1!]==[^"] (
IF [!DeQuote.Contents:~-1!]==[^"] (
SET DeQuote.Contents=!DeQuote.Contents:~1,-1!
) ELSE (GOTO :EOF no end quote)
) ELSE (GOTO :EOF no beginning quote)

SET !DeQuote.Variable!=!DeQuote.Contents!
SET DeQuote.Variable=
SET DeQuote.Contents=
)
GOTO :EOF