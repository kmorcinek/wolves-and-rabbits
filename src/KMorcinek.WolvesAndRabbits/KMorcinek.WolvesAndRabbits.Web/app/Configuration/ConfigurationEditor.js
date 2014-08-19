angular.module('app').directive('configurationEditor', function () {
    return {
        restrict: 'E',
        templateUrl: '/app/Configuration/ConfigurationEditor.html',
        scope: {
            configuration: '=',
            resetConfiguration: '&',
        },
        controller: function ($scope) {
            console.log($scope.configuration);
        },
    };
});