angular.module('WinLess')
    .factory('settings', function(storage){
        var startOnBoot = require('start-on-windows-boot');

        var settings = {
            /**
             * All the settings with their default values.
             */
            values: {
                compileDefaults: {
                    minify: true
                },
                compileOnSave: true,
                showSuccessMessages: true,
                startMinified: true,
                startWithWindows: true
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
                if(settings.values.startWithWindows){
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