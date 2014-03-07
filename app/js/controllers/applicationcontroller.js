angular.module('WinLess')
    .controller('ApplicationController', function($scope, $state, $stateParams, settings, menuHelper){
        $scope.$state = $state;
        $scope.$stateParams = $stateParams;

        $scope.logDirs = function(event){
            console.log(event.folders);
        };

        var gui = require('nw.gui');
        var win = gui.Window.get();

        initTray();
        initMenu();
        initWindow();


        /**
         * Initializes the tray item + menu.
         */
        function initTray(){
            // Create the tray item.
            var tray = new gui.Tray({ icon: 'img/icon.png' });

            // Restore from tray when clicked.
            tray.on('click', restoreFromTray);

            // Add the tray menu
            var trayMenu = new gui.Menu();
            trayMenu.append(new gui.MenuItem({ label: 'Open', click: restoreFromTray }));
            trayMenu.append(new gui.MenuItem({ label: 'Compile' })); // ToDo
            trayMenu.append(new gui.MenuItem({ label: 'Exit', click: exit }));
            tray.menu = trayMenu;
        }

        /**
         * Initializes the application menu.
         */
        function initMenu(){
            win.menu = menuHelper.createMenuItems(new gui.Menu({ type: 'menubar' }), [
                {
                    label: 'File',
                    items: [
                        {
                            label: 'Settings',
                            click: function(){
                                alert('Settings!');
                            }
                        }
                    ]
                },
                {
                    label: 'Help',
                    items: [
                        {
                            label: 'About',
                            click: function(){
                                alert('About!');
                            }
                        }
                    ]
                }
            ]);
        }

        /**
         * Initializes the window
         */
        function initWindow(){
            // Show the window, if WinLess should not start minified.
            if(!settings.values.startMinified){
                win.show();
            }
            // Minimize to tray
            win.on('minimize', minimizeToTray);
        }

        function restoreFromTray(){
            win.show();
            win.focus();
        }

        function minimizeToTray(){
            win.hide();
        }

        function exit(){
            win.close();
        }
    });