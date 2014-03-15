angular.module('WinLess')
    .factory('LessFile', function(Class, fs, path, lessImports, lessFileWatcher, lessCompiler, throttle, settings){
        return Class.extend({
            init: function(params){
                this.compileOptions = _.cloneDeep(settings.values.compileDefaults);
                this.path = params.path;
                this.relativePath = params.relativePath;
                this.outputPath = params.outputPath || getOutputPath(this.path, settings.values.compiler.useMinExtension);
                this.watch();
            },
            /**
             * Adds or updates the item to / in the lessFileWatcher
             */
            watch: function(){
                this.importPaths = lessImports.findImports(this.path);
                lessFileWatcher.watch(this);
            },
            compile: function(){
                var self = this;

                lessCompiler.compile(self);
                // Update the imports
                self.watch();
            }
        });

        function getOutputPath(filePath, useMinExtension){
            var dir = path.dirname(filePath);
            if(fs.existsSync(dir + '/css')){
                dir = dir + '/css';
            }
            else if(fs.existsSync(dir + '/../css')){
                dir = dir + '/../css';
            }
            var fileName = path.basename(filePath, '.less') + (useMinExtension ? '.min.css' : '.css');
            return path.resolve(dir + '/' + fileName);
        }
    });