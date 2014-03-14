/**
 * Service which can be used for 'throttling' a function: this means that the supplied function is executed only once
 * every 'delay' ms.
 * This is achieved by postponing the execution for the 'delay' ms. If a new call arives within this 'delay' it cancels
 * the already waiting call.
 */
angular.module('WinLess')
    .factory('throttle', function($timeout){
        var promises = {};
        /**
         * @param {Function} fn - The (possibly anonymous) function which is to be throttled
         * @param {number} [delay=300] - The throttle delay.
         * @param {bool} [invokeApply=true] - Apply should be triggered after the function has executed. Default: true.
         */
        function throttle(fn, delay, invokeApply){
            if(invokeApply === undefined){
                invokeApply = true;
            }
            if(delay === undefined){
                delay = 300;
            }

            $timeout.cancel(promises[fn]);
            promises[fn] = $timeout(fn, delay, invokeApply);
        }

        return throttle;
    });