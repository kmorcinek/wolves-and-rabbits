﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
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
                            console.log(nextTurn);
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
                            alert("Error: " + error);
                        }
                    });
                });

                // fieldHub.server.getNextTurn().done(function (nextTurn) {
                // });
            };

            var reset = function () {
                fieldHub.server.reset(null).done(function (nextTurn) {
                    $scope.$apply(function () {
                        $scope.data = nextTurn.cellArrays;
                        $scope.iterationCount = nextTurn.iterationCount;
                    });
                });
            };

            // $.connection.hub.start()
            //     .done(function () {
            //         reset();
            //
            //         fieldHub.server.getConfiguration().done(function (configuration) {
            //             $scope.$apply(function() {
            //                 $scope.configuration = configuration;
            //             });
            //         });
            //     });

            $scope.nextTurns = function (count) {
                getNextTurns(count);
            }

            $scope.resetConfiguration = function () {
                fieldHub.server.reset($scope.configuration).done(function (nextTurn) {
                    $scope.$apply(function () {
                        $scope.data = nextTurn.cellArrays;
                        $scope.iterationCount = nextTurn.iterationCount;
                    });
                });
            }
        });
    });