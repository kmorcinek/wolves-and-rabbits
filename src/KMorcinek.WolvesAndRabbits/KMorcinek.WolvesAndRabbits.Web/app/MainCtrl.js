angular.module('app').controller('MainCtrl',
    function ($scope) {
        $(function () {
            var fieldHub = $.connection.fieldHub;

            var getNextTurns = function (leftTurns) {
                leftTurns -= 1;
                fieldHub.server.getNextTurn().done(function (nextTurn) {
                    $scope.$apply(function() {
                        $scope.data = nextTurn.cellArrays;
                        $scope.iterationCount = nextTurn.iterationCount;
                    });

                    if (leftTurns === 0) {
                        return;
                    }

                    getNextTurns(leftTurns);
                });
            };

            var reset = function () {
                fieldHub.server.reset(null).done(function (nextTurn) {
                    $scope.$apply(function () {
                        $scope.data = nextTurn.cellArrays;
                        $scope.iterationCount = nextTurn.iterationCount;
                    });
                });
            };

            $.connection.hub.start()
                .done(function () {
                    reset();

                    fieldHub.server.getConfiguration().done(function (configuration) {
                        $scope.$apply(function() {
                            $scope.configuration = configuration;
                        });
                    });
                });

            $scope.nextTurns = function (count) {
                getNextTurns(count);
            }

            $scope.resetConfiguration = function () {
                fieldHub.server.reset($scope.configuration).done(function (nextTurn) {
                    $scope.$apply(function() {
                        $scope.data = nextTurn.cellArrays;
                        $scope.iterationCount = nextTurn.iterationCount;
                    });
                });
            }
        });
    });