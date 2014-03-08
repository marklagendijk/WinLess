angular.module('WinLess')
    .directive('nwBrowsefolders', function(){
        return {
            link: function(scope, element, attrs){
                var input = $('<input type="file" nwdirectory class="hidden" />');
                element.append(input);

                input.change(function(event){
                    scope.$apply(function(){
                        scope.$eval(attrs.nwBrowsefolders, {
                            $event: {
                                value: input.val(),
                                originalEvent: event
                            }
                        });
                    });
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