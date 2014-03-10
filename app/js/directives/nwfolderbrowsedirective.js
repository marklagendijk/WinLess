angular.module('WinLess')
    .directive('nwBrowsefolders', function(){
        return {
            link: function(scope, element, attrs){
                var input = $('<input type="file" nwdirectory class="hidden" />');
                element.append(input);

                input.change(function(event){
                    var path = input.val();
                    if(path){
                        scope.$apply(function(){
                            scope.$eval(attrs.nwBrowsefolders, {
                                $event: {
                                    value: path,
                                    originalEvent: event
                                }
                            });
                            input.val('');
                        });
                    }
                });

                input.click(function(event){
                    event.stopPropagation();
                });

                element.on('click', function(){
                    input.trigger('click');
                });
            }
        };
    });