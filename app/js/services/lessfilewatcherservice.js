angular.module('WinLess')
    .factory('lessFileWatcher', function(chokidar){
        var lessFiles = [];
        var imports = [];

        var watcher = new chokidar.FSWatcher();
        watcher.on('change', triggerCompile);

        return {
            watch: function(file){
                // Remove the file if it was already watched
                _.remove(lessFiles, {
                    path: file.path
                });

                // Remove any imports if the file was already watched
                _.remove(imports, function(importItem){
                    return importItem.file.path === file.path;
                });

                // Add the file to the watched files
                lessFiles.push(file);

                // Add importItems for all importPaths of the file
                file.importPaths.forEach(function(path){
                    imports.push({
                        path: path,
                        file: file
                    });
                });

                // Actually watch the file and its imports
                watcher.add(file.path);
                watcher.add(file.importPaths);
            }
        };

        function triggerCompile(path){
            // Compile the matching file, if any
            _.filter(lessFiles, {
                path: path
            }).forEach(function(file){
                file.compile();
            });

            // Compile the parent file of any matching importItem.
            _.filter(imports, {
                path: path
            }).forEach(function(importItem){
                importItem.file.compile();
            });
        }
    });