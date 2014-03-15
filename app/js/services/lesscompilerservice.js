angular.module('WinLess')
    .factory('lessCompiler', function($rootScope, exec, settings){
        var lessCompiler = {
            log: [],
            compile: function(file){
                var command = getCompileCommand(file);
                exec(command, function(error, stdout, stderr){
                    lessCompiler.log.push({
                        file: file,
                        date: new Date(),
                        isError: !!stderr,
                        error: stderr
                    });
                    $rootScope.$apply();
                });
            }
        };

        return lessCompiler;

        function getCompileCommand(file){
            var lessc = getLesscCommand();
            var args = getLesscArguments(file);
            return lessc + args + '"' + file.path + '" "' + file.outputPath + '"';
        }

        function getLesscCommand(){
            if(settings.values.compiler.useCustomLessc){
                return '"' + settings.values.compiler.lesscPath + '" ';
            }
            else{
                return '"' + process.cwd() + '\\node_modules\\.bin\\lessc" ';
            }
        }

        function getLesscArguments(file){
            var args = '--no-color ';
            if(file.compileOptions.minify){
                // Use the 'clean-css' option for minification, don't break compatability
                args += '--clean-css --clean-option=--compatibility:ie7 ';
            }
            if(file.compileOptions.strictMath){
                args += '--strict-math=on ';
            }
            if(file.compileOptions.strictUnits){
                args += '--strict-units=on ';
            }

            return args;
        }
    });