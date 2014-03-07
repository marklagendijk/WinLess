angular.module('WinLess')
    .factory('menuHelper', function(){
        var gui = require('nw.gui');

        return {
            /**
             * Function for easily creating nested menu-items
             * @param {Menu} menu
             * @param itemTrees
             * @returns {Menu}
             */
            createMenuItems: createMenuItems
        };

        function createMenuItems(menu, items){
            items.forEach(function(item){
                if(item.items && item.items.length){
                    // Create the submenu.
                    item.submenu = createMenuItems(new gui.Menu(), item.items);

                    // Remove the child items.
                    delete item.items;
                }
                // Create the menu item.
                menu.append(new gui.MenuItem(item));
            });

            return menu;
        }
    });