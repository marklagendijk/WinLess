angular.module('WinLess')
    .factory('settings', function(storage){
        var startOnBoot = require('start-on-windows-boot');

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
                    showSuccessMessages: true
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
                    _.extend(settings.values, storage.get('settings'));
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