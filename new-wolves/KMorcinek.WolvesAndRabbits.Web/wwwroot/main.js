$(document).ready(function () {
    function clearTable() {
        $("#parentHolder").html("");
    }
    
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

    $("#btn-next-1-turn").click(function () {
        getNextTurns(1);
    });

    $("#btn-next-10-turn").click(function () {
        getNextTurns(10);
    });

    $("#btn-next-25-turn").click(function () {
        getNextTurns(25);
    });

    $("#btn-reset").click(function () {
        $.get("reset")
            .done(function () {
                console.log("reset done");
                clearTable();
            });
    });

    const getNextTurns = function (leftTurns) {
        leftTurns -= 1;
        
        $.get("next-turn")
            .done(function (data) {
                const cellsData = JSON.parse(data);
                $('#txt-current-turn').val(cellsData.iterationCount);
                buildTable(cellsData.cellArrays);

                if (leftTurns === 0) {
                    return;
                }
                
                getNextTurns(leftTurns);
            });
    };
});
