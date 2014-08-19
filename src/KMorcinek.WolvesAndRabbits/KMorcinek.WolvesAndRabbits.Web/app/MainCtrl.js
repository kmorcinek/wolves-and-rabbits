angular.module('app').controller('MainCtrl',
    function($scope) {
        $(function () {
            var fieldHub = $.connection.fieldHub;

            var refresh = function() {
                fieldHub.server.getNextTurn().done(function(nextTurn) {
                    $scope.data = nextTurn;
                    $scope.$apply();
                });
            };

            $.connection.hub.start()
                .done(function () {
                    refresh();

                    $("#sendmessage").click(function () {
                        refresh();
                    })
                });
        });
    });