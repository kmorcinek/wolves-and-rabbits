// import citations from 'https://gist.githubusercontent.com/kmorcinek/83c20fe5044ce27abb15d11322678f11/raw/528f6ae671e7c46bc523723994db2db46e4f118f/citations.json' assert { type: 'json' };

$(document).ready(function () {
    console.log("ready!");

    // console.log(myJson);

    // let counter = -1;
    //
    function buildTable(bookDetails) {

        var parentDiv = $("#parentHolder");
        parentDiv.html("");
        var aTable = $("<table>", {
            "id": "newTable"
        }).appendTo(parentDiv);
        var rowCount = bookDetails.length;
        var colmCount = bookDetails[0].length;

        // For loop for adding header .i.e th to our table
        // for (var k = 0; k < 1; k++) {
        //     var fragTrow = $("<tr>", {
        //         "class": "trClass"
        //     }).appendTo(aTable);
        //     for (var j = 0; j < colmCount; j++) {
        //         // let bookDetailElement = bookDetails[k][j];
        //         let bookDetailElement = ""
        //         $("<th>", {
        //             "class": "thClass"
        //         }).prependTo(fragTrow).html(bookDetailElement);
        //     }
        // }

        //For loop for adding data .i.e td with data to our dynamic generated table
        for (var i = 1; i < rowCount; i < i++) {
            var fragTrow = $("<tr>", {
                "class": "trClass"
            }).appendTo(aTable);
            for (var j = 0; j < colmCount; j++) {
                const cell = bookDetails[i][j];
                let cellContent = 's';
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
        console.log("button ready!");

        $.get("next-turn", {name: "John", time: "2pm"})
            .done(function (data) {
                console.log("Data Loaded: ", data);
                const cellsData = JSON.parse(data);
                $('#txt-current-turn').val(cellsData.iterationCount);
                buildTable(cellsData.cellArrays);
            });


        // counter++;
        // const citation = citations[counter % citations.length];
        //
        // const citationText = "\"" + citation.phrase + "\"";
        //
        // $("#citation").text(citationText);
        // let imageUrl = citation.imageUrl
        // const imageUrlFromStorage = getCitationImage(citation.phrase);
        //
        // if (imageUrlFromStorage) {
        //     imageUrl = imageUrlFromStorage
        // }
        // setImageUrl(imageUrl);
        //
        // $("#assign-image").removeAttr("disabled");
    });
    //
    // $("#assign-image").click(function () {
    //     const citation = citations[counter % citations.length];
    //
    //     var citationImages = getCitationImages()
    //     const newImageUrl = $('#new-image-url').val();
    //
    //     console.log('citation.phrase', citation.phrase);
    //     console.log('newImageUrl ', newImageUrl);
    //     setImageUrl(newImageUrl)
    //     citationImages[citation.phrase] = newImageUrl
    //     setCitationImages(citationImages);
    //     $('#new-image-url').val('');
    // });
    //
    // function setImageUrl(imageUrl) {
    //     $("#citation-image").attr('src', imageUrl);
    // }
    //
    // var key = 'kmorcinek.czarna-ania.citations';
    // function setCitationImages(citationImages) {
    //     localStorage.setItem(key, JSON.stringify(citationImages));
    // }
    //
    // function getCitationImages() {
    //     var citationImages = localStorage.getItem(key);
    //     if (!citationImages) {
    //         return {}
    //     }
    //     return JSON.parse(citationImages);
    // }
    //
    // function getCitationImage(phrase) {
    //     return getCitationImages()[phrase];
    // }
});
