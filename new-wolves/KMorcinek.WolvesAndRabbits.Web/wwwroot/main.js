// import citations from 'https://gist.githubusercontent.com/kmorcinek/83c20fe5044ce27abb15d11322678f11/raw/528f6ae671e7c46bc523723994db2db46e4f118f/citations.json' assert { type: 'json' };

$(document).ready(function () {
    console.log("ready!");

    function buildTable(bookDetails) {

        var parentDiv = $("#parentHolder");
        parentDiv.html("");
        var aTable = $("<table>", {
            "id": "newTable"
        }).appendTo(parentDiv);
        var rowCount = bookDetails.length;
        var colmCount = bookDetails[0].length;

        //For loop for adding data .i.e td with data to our dynamic generated table
        for (var i = 1; i < rowCount; i < i++) {
            var fragTrow = $("<tr>", {
                "class": "trClass"
            }).appendTo(aTable);
            for (var j = 0; j < colmCount; j++) {
                const cell = bookDetails[i][j];
                let cellContent = '<span>&nbsp;</span>';
                if (cell.l === "R") {
                    cellContent = '<img src="/images/rabbit_hare.png" alt="" height="25"/>';
                } else if (cell.l === "W") {
                    cellContent = '<img src="/images/wolf.png" alt="" height="25"/>';
                }

                $("<td>", {
                    "class": "tdClass"
                }).appendTo(fragTrow).html(cellContent);
            }
        }
    }

    $("#btn-build-table").on('click', function (e) {
        e.preventDefault();
        alert(1);
        var parentDiv = $("#parentHolder");
        parentDiv.html("");
        var aTable = $("<table>", {
            "id": "newTable"
        }).appendTo(parentDiv);
        var rowCount = bookDetails.length;
        var colmCount = bookDetails[0].length;

        // For loop for adding header .i.e th to our table
        for (var k = 0; k < 1; k++) {
            var fragTrow = $("<tr>", {
                "class": "trClass"
            }).appendTo(aTable);
            for (var j = 0; j < colmCount; j++) {
                $("<th>", {
                    "class": "thClass"
                }).prependTo(fragTrow).html(bookDetails[k][j]);
            }
        }

        //For loop for adding data .i.e td with data to our dynamic generated table
        for (var i = 1; i < rowCount; i < i++) {
            var fragTrow = $("<tr>", {
                "class": "trClass"
            }).appendTo(aTable);
            for (var j = 0; j < colmCount; j++) {
                $("<td>", {
                    "class": "tdClass"
                }).appendTo(fragTrow).html(bookDetails[i][j]);
            }
        }
    });

    $("#btn-next-1-turn").click(function () {
        getNextTurns(1);
    });

    $("#btn-next-10-turn").click(function () {
        getNextTurns(10);
    });

    $("#btn-next-25-turn").click(function () {
        getNextTurns(25);
    });

    const getNextTurns = function (leftTurns) {
        leftTurns -= 1;
        
        $.get("next-turn")
            .done(function (data) {
                // console.log("Data Loaded: ", data);
                const cellsData = JSON.parse(data);
                $('#txt-current-turn').val(cellsData.iterationCount);
                buildTable(cellsData.cellArrays);

                if (leftTurns === 0) {
                    return;
                }
                
                getNextTurns(leftTurns);
            });

        // fieldHub.server.getNextTurn().done(function (nextTurn) {
        //     $scope.$apply(function() {
        //         $scope.data = nextTurn.cellArrays;
        //         $scope.iterationCount = nextTurn.iterationCount;
        //     });
        //
        //     if (leftTurns === 0) {
        //         return;
        //     }
        //
        //     getNextTurns(leftTurns);
        // });
    };
});
