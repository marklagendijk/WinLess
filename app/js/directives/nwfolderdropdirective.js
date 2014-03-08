angular.module('WinLess')
    .directive('nwFolderdrop', function(){
        var fs = require('fs');

        window.ondragover = cancelEvent;
        window.ondrop = cancelEvent;

        return {
            link: function(scope, element, attrs){
                element[0].ondragover = function(){
                    element.addClass('dragover');
                    return false;
                };
                element[0].ondragend = function(){
                    element.removeClass('dragover');
                    return false;
                };
                element[0].ondrop = function(event){
                    var folders = [];
                    _.forEach(event.dataTransfer.files, function(item){
                        var stats = fs.statSync(item.path);
                        if(stats && stats.isDirectory()){
                            folders.push(item.path);
                        }
                    });

                    scope.$apply(function(){
                        scope.$eval(attrs.nwFolderdrop, {
                            $event: {
                                value: folders,
                                originalEvent: event
                            }
                        });
                    });

                    event.preventDefault();
                    return false;
                };

            }
        };


        function cancelEvent(event){
            event.preventDefault();
            return false;
        }
    });