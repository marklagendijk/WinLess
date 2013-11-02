## Changelog

### 1.8.2
- Updated less.js to 1.5.0

### 1.8.1
- Updated less.js to 1.4.1
- Partial fix for automatic less.js updating mechanism, it should now work when you run WinLess as admin. Proper fix is still needed.


### 1.8.0
- Updated less.js to 1.3.3
- Added automatic updating of less.js. On start WinLess now checks whether there is a new version of less.js available and offers to install it. This can disabled in the settings dialog. WinLess also performs this check when the about dialog is opened.

### 1.7.1
- Updated less.js to 1.3.2


### 1.7.0
- Improved folder selection via 'Add folder' by using Ookii.VistaFolderBrowserDialog
- Improved output path selection by changing 'select output folder' to 'select output file', @jmclocklin thanks for the help
- Improved automatic output folder recognition.
- Fixed some bugs

### 1.6.0
Node.js, Node Package Manager and lessc are now all compatible with Windows. [See here](https://github.com/cloudhead/less.js/wiki/Command-Line-use-of-LESS).
- Rewrote WinLess to compile via Node.js with lessc

### 1.5.4
- Added "Compile" as a tray icon context menu, by @DashK
- Changed so WinLess doesn't save settings to ProgramData but to UserData instead, by @dunston
- Updated less.js to v1.3.1, by @gpk-urmc

### 1.5.3
- Fixed displaying of errors.
- Updated less.wsf to latest version.

### 1.5.2
- Adjusted the SingleInstance logic so that WinLess will restore from the tray if you already have it running. This only happens when you don't call it from the command line (with arguments).

### 1.5.1
- Fixed a bug which caused a console window to open alongside WinLess

### 1.5.0
WinLess is now SingleInstance:

- Calling WinLess via the command line adds the directories instead of always clearing the list.
- You can optionally clear the current list with the '--clear'-flag.

### 1.4.0
- Added 'check all' checkbox.
- Made directory list resizable
- The less.js version shown in 'about' is now read from the actual less.js file.
- less.js 1.3.0
