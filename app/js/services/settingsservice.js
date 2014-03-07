angular.module('WinLess')
    .factory('settings', function(){
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
             * Loads the setting values from localStorage.
             */
            load: function(){
                if(localStorage.settings){
                    _.extend(settings.values, JSON.parse(localStorage.settings));
                }
                else{
                    settings.save();
                }
            },
            /**
             * Saves the settings values to localStorage
             */
            save: function(){
                if(settings.values.startWithWindows){
                    startOnBoot.enableAutoStart('WinLess', process.execPath);
                }
                else{
                    startOnBoot.disableAutoStart('WinLess');
                }

                localStorage.settings = JSON.stringify(settings.values);
            }
        };
        settings.load();

        return settings;
    });