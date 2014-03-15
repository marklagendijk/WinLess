angular.module('WinLess')
    .factory('settings', function(startOnBoot, storage){
        var settings = {
            /**
             * All the settings with their default values.
             */
            values: {
                general: {
                    startWithWindows: true,
                    startMinified: true
                },
                project: {
                    ignorePatterns: [
                        'bower_components\\',
                        'node_modules\\',
                        'imports\\',
                        '\\_'
                    ]
                },
                compiler: {
                    compileOnSave: true,
                    useMinExtension: true,
                    showSuccessMessages: true,
                    useCustomLessc: false,
                    lesscPath: 'lessc'
                },
                compileDefaults: {
                    minify: true,
                    strictMath: true,
                    strictUnits: true
                }
            },
            /**
             * Loads the setting values from storage.
             */
            load: function(){
                if(localStorage.settings){
                    _.merge(settings.values, storage.get('settings'));
                }
                else{
                    settings.save();
                }
            },
            /**
             * Saves the settings values to storage
             */
            save: function(){
                if(settings.values.general.startWithWindows){
                    startOnBoot.enableAutoStart('WinLess', process.execPath);
                }
                else{
                    startOnBoot.disableAutoStart('WinLess');
                }

                storage.put('settings', settings.values);
            }
        };
        settings.load();

        return settings;
    });