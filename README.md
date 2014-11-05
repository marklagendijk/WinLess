# WinLess
[http://winless.org](http://winless.org)

WinLess is written with C#.NET using Visual Studio 2010.

The installer is created using [War Setup](http://sourceforge.net/projects/warsetup/)

## Project status and future
WinLess 1.x is now in maintenance mode. This means that at this time no feature requests will be accepted. Bug reports are still welcome, but all current issues are closed to make sure that the open issues are only about current bugs.

WinLess 2.x is a rewrite of WinLess using node-webkit. The development of [WinLess 2.0](https://github.com/marklagendijk/WinLess/tree/winless2) can be followed [here](https://github.com/marklagendijk/WinLess/issues/116). Most of the work is done, however, since my priorities have shifted it is now not clear whether it will ever be finished. Feature requests will only be accepted after the 2.0 release.

Follow [this issue](https://github.com/marklagendijk/WinLess/issues/116) for more information.

## Using a globally installed less
To use a globally installed LESS, instead of the one bundled with WinLess, you should follow the following steps:

1. Install [Node.js](http://nodejs.org/), which comes bundled with NPM.
2. Open command prompt.
3. Execute `npm install less -g`
4. Execute `npm install less-plugin-clean-css -g`
5. Choose `use globally installed less` in WinLess settings.
