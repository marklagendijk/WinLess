## Changelog

### 1.5.2
-Adjusted the SingleInstance logic so that WinLess will restore from the tray if you already have it running. This only happens when you don't call it from the command line (with arguments).

### 1.5.1
-Fixed a bug which caused a console window to open alongside WinLess

### 1.5.0
WinLess is now SingleInstance:
-Calling WinLess via the command line adds the directories instead of always clearing the list.
-You can optionally clear the current list with the '--clear'-flag.

### 1.4.0
-Added 'check all' checkbox.
-Made directory list resizable
-The less.js version shown in 'about' is now read from the actual less.js file.
-less.js 1.3.0