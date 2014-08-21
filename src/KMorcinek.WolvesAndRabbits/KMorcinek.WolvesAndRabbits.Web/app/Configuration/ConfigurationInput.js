angular.module('app').directive('configurationInput', function () {
    return {
        restrict: 'E',
        templateUrl: '/app/Configuration/ConfigurationInput.html',
        transclude: true,
        scope: {
            value: '=',
        },
    };
});