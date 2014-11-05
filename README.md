# WinLess
[http://winless.org](http://winless.org)

WinLess is written with C#.NET using Visual Studio 2010.

The installer is created using [War Setup](http://sourceforge.net/projects/warsetup/)

## Using a globally installed less
To use a globally installed LESS, instead of the one bundled with WinLess, you should follow the following steps:

1. Install [Node.js](http://nodejs.org/), which comes bundled with NPM.
2. Open command prompt.
3. Execute `npm install less -g`
4. Execute `npm install less-plugin-clean-css -g`
5. Choose `use globally installed less` in WinLess settings.