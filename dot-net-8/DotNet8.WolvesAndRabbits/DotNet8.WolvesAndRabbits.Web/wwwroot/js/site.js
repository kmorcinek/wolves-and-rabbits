angular.module('app', [])
    .config(function () {
    });

angular.module('app').controller('MainCtrl',
    function ($scope) {
        $(function () {
            var getNextTurns = function (leftTurns) {
                leftTurns -= 1;

                $(document).ready(function () {
                    $.ajax({
                        url: '/api/next-game',
                        type: 'GET',
                        success: function (nextTurn) {
                            $scope.$apply(function () {
                                $scope.data = nextTurn.cellArrays;
                                $scope.iterationCount = nextTurn.iterationCount;
                            });

                            if (leftTurns === 0) {
                                return;
                            }

                            getNextTurns(leftTurns);
                        },
                        error: function (xhr, status, error) {
                            console.error("Error: " + error);
                        }
                    });
                });
            };

            var reset = function () {
                $.ajax({
                    url: '/api/reset-game',
                    type: 'POST',
                    success: function (nextTurn) {
                        $scope.$apply(function () {
                            $scope.data = nextTurn.cellArrays;
                            $scope.iterationCount = nextTurn.iterationCount;
                        });
                    },
                    error: function (xhr, status, error) {
                        console.error("Error: " + error);
                    }
                });
            };

            reset();

            $scope.nextTurns = function (count) {
                getNextTurns(count);
            }

            $scope.reset = function () {
                reset()
            }

            $scope.resetConfiguration = function () {
                // fieldHub.server.reset($scope.configuration).done(function (nextTurn) {
                //     $scope.$apply(function () {
                //         $scope.data = nextTurn.cellArrays;
                //         $scope.iterationCount = nextTurn.iterationCount;
                //     });
                // });
            }
        });
    });