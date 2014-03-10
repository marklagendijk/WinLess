angular.module('WinLess')
    .controller('ApplicationController', function($scope, $state, $stateParams, gui, win, settings){
        $scope.$state = $state;
        $scope.$stateParams = $stateParams;

        initTray();
        initWindow();


        /**
         * Initializes the tray item + menu.
         */
        function initTray(){
            // Create the tray item.
            var tray = window.tray = new gui.Tray({ title: 'WinLess', icon: 'img/icon.png' });

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
            if(!settings.values.general.startMinified){
                win.show();
            }
            // Minimize to tray
            win.on('minimize', minimizeToTray);

            $(window).keydown(function(event){
                var keycodes = {
                    F5: 116,
                    F12: 123
                };

                switch(event.which){
                // Reload the application on F5
                case keycodes.F5:
                    window.location.reload();
                    break;

                // Toggle DevTools on F12
                case keycodes.F12:
                    if(win.isDevToolsOpen()){
                        win.closeDevTools();
                    }
                    else{
                        win.showDevTools();
                    }
                    break;
                }
            });
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