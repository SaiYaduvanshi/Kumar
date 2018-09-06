$("#sehir").change(function () {
    adresGoster("", "", $(this).val());
});
$("#ilce").change(function () {
    adresGoster("", $(this).val(), $("#sehir").val());
});

$("#adres").keydown(function () {
    console.log($(this).val());
    adresGoster($("#adres").val(), $("#ilce").val(), $("#sehir").val());
});

$(document).ready(function () {
    DefaultHKmarker = new google.maps.LatLng(36.88331, 30.74012);

    myOptions = {
        zoom: 14,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        center: DefaultHKmarker,
        streetViewControl: false
    }

    map = new google.maps.Map(document.getElementById("harita"), myOptions);

    marker = new google.maps.Marker({
        position: DefaultHKmarker,
        title: ""
    });
    marker.setMap(map);
    marker.setDraggable(true);

    google.maps.event.addListener(marker, "dragend", function (event) {

        var point = marker.getPosition();

        document.getElementById("latitude").value = point.lat().toFixed(5);
        document.getElementById("longitude").value = point.lng().toFixed(5);

        map.panTo(point);

    });
});

function adresGoster(adres, ilce, il) {

    geocoder = new google.maps.Geocoder();
    //var latlng = new google.maps.LatLng(40.98014, 29.082278);
    var address = adres + ' , ' + ilce + ',' + il;
    geocoder.geocode({
        'address': address
    }, function (results, status) {

        //eger sonuc bulundu ise
        if (status == google.maps.GeocoderStatus.OK) {

            var mapOptions = {
                zoom: 15,
                center: results[0].geometry.location,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }
            map = new google.maps.Map(document.getElementById('harita'), mapOptions);

            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });

            var point = marker.getPosition();

            document.getElementById("latitude").value = point.lat().toFixed(5);
            document.getElementById("longitude").value = point.lng().toFixed(5);

            marker.setMap(map);
            marker.setDraggable(true);

            google.maps.event.addListener(marker, "dragend", function (event) {

                var point = marker.getPosition();

                document.getElementById("latitude").value = point.lat().toFixed(5);
                document.getElementById("longitude").value = point.lng().toFixed(5);

                map.panTo(point);
            });
        } else {
            //alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}
