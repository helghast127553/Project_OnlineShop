// This example displays a marker at the center of Australia.
// When the user clicks the marker, an info window opens.
//10.795323, 106.670481
function initMap() {
    var uluru = { lat: 10.795323, lng: 106.670481 };
    var map = new google.maps.Map(document.getElementById('mapCanvas'), {
        zoom: 18,
        center: uluru
    });
    var contentString = '@Html.Raw(Model.Content)';
    var infowindow = new google.maps.InfoWindow({
        content: contentString
    });
    var marker = new google.maps.Marker({
        position: uluru,
        map: map,
        title: 'Địa chỉ'
    });
    marker.addListener('click', function () {
        infowindow.open(map, marker);
    });
}
google.maps.event.addDomListener(window, 'load', initMap);