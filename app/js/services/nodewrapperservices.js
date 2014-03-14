angular.module('WinLess')
    .factory('gui', function(){
        return require('nw.gui');
    })
    .factory('win', function(gui){
        return gui.Window.get();
    })
    .factory('exec', function(){
        return require('child_process').exec;
    })
    .factory('fs', function(){
        return require('fs');
    })
    .factory('path', function(){
        return require('path');
    })
    .factory('glob', function(){
        return require('glob');
    })
    .factory('chokidar', function(){
        return require('chokidar');
    })
    .factory('open', function(){
        return require('open');
    })
    .factory('lessImports', function(){
        return require('less-imports');
    })
    .factory('startOnBoot', function(){
        return require('start-on-windows-boot');
    })
    // globals
    .run(function(){
        window._ = require('lodash');
    });
