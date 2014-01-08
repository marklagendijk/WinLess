# WinLess.lessc
Package for easy compiling of LESS files in your build events.
Contains Node package of less.js.

## Usage
WinLess.lessc comes with 2 commands: `lessc` and `lesscFolder`.

1.	`lessc "<lessFile>" "<cssFile>" <otherArguments>`
2.	`lesscFolder "<lessFolder>" "<cssFolder>" "otherArguments"`

Note: the aditional lessc arguments passed to lesscFolder need to be quoted.
The most noteworthy argument is `--yui-compress`, which minifies the outputted css.

## Examples
### Compiling a folder
	CD "$(SolutionDir)packages\WinLess.lessc*\tools"
	CALL lesscFolder "$(ProjectDir)Styles" "$(ProjectDir)Styles" "--yui-compress"

### Compiling a single file
	CD "$(SolutionDir)packages\WinLess.lessc*\tools"
	CALL lessc "$(ProjectDir)Styles\Less\main.less" "$(ProjectDir)Styles\Css\main.css" --yui-compress
	
## Updating less.js
If you want you can update the included LESS package yourself, by using the Node Package Manager. To do this follow the following steps:

1.	Install [Node with Node Package Manager](http://nodejs.org/download/).
2.	Open Command Prompt and `cd` to the `packages\WinLess.lessc` folder.
3.	Execute the following command,	`npm update less`.
		
## Credits
1.	[less.js]( http://lesscss.org/) - The official LESS compiler, by Alexis Sellier (author of the LESS language).
2.	[Node.js](http://nodejs.org/).
3.	[WinLess.lessc](http://winless.org/lessc) - This package.
