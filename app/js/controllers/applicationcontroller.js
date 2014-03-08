angular.module('WinLess')
    .controller('ApplicationController', function($scope, $state, $stateParams, settings){
        $scope.$state = $state;
        $scope.$stateParams = $stateParams;

        var gui = require('nw.gui');
        var win = gui.Window.get();

        initTray();
        initWindow();


        /**
         * Initializes the tray item + menu.
         */
        function initTray(){
            // Create the tray item.
            tray = new gui.Tray({ title: 'WinLess', icon: 'img/icon.png' });

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