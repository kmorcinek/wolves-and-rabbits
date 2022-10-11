// import citations from 'https://gist.githubusercontent.com/kmorcinek/83c20fe5044ce27abb15d11322678f11/raw/528f6ae671e7c46bc523723994db2db46e4f118f/citations.json' assert { type: 'json' };

$(document).ready(function () {
    console.log("ready!");

    // console.log(myJson);

    // let counter = -1;
    //
    // $("#what-button").click(function () {
    //     counter++;
    //     const citation = citations[counter % citations.length];
    //
    //     const citationText = "\"" + citation.phrase + "\"";
    //
    //     $("#citation").text(citationText);
    //     let imageUrl = citation.imageUrl
    //     const imageUrlFromStorage = getCitationImage(citation.phrase);
    //
    //     if (imageUrlFromStorage) {
    //         imageUrl = imageUrlFromStorage
    //     }
    //     setImageUrl(imageUrl);
    //
    //     $("#assign-image").removeAttr("disabled");
    // });
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
