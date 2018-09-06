(function(A) {

	if (!Array.prototype.forEach)
		A.forEach = A.forEach || function(action, that) {
			for (var i = 0, l = this.length; i < l; i++)
				if (i in this)
					action.call(that, this[i], i, this);
			};

		})(Array.prototype);

		var
		mapObject,
		markers = [],
		markersData = {
			'Shop': [
			{
				name: 'Bondi Beach',
				location_latitude: 41.155135, 
				location_longitude: 27.812193,
				map_image_url: 'img/img.png',
				name_point: 'Kahve Deryası',
				description_point: 'Çeşitli kahvelerimizle hizmetinizdeyiz...',
				url_point: '02.html'
			},
			{
				name: 'Coogee Beach',
				location_latitude: 41.155676, 
				location_longitude: 27.816136,
				map_image_url: 'img/img2.png',
				name_point: 'Piknik Restaurant',
				description_point: '',
				url_point: '02.html'
			},
			{
				name: 'Cronulla Beach',
				location_latitude: 41.155527, 
				location_longitude: 27.811699,
				map_image_url: 'img/img3.png',
				name_point: 'Vogue Cafe',
				description_point: '',
				url_point: '02.html'
			},
			{
				name: 'Manly Beach',
				location_latitude: 41.154840, 
				location_longitude: 27.812311,
				map_image_url: 'img/img4.png',
				name_point: 'İskender Kebapçısı',
				description_point: '',
				url_point: '02.html'
			},
			{
				name: 'Maroubra Beach',
				location_latitude: 41.153830, 
				location_longitude: 27.815782,
				map_image_url: 'img/img.png',
				name_point: 'Miniço',
				description_point: 'Çocukların Renkli Dünyası',
				url_point: '02.html'
			},
			
			
			],
			'Cafe': [
			{
				name: 'Bondi Beach',
				location_latitude: 41.151895, 
				location_longitude: 27.809806,
				map_image_url: 'img/img.png',
				name_point: 'Lalezar Pastanesi',
				description_point: 'Lezetli pastaların adresi',
				url_point: '02.html'
			},
			{
				name: 'Coogee Beach',
				location_latitude: 41.154606, 
				location_longitude: 27.810460,
				map_image_url: 'img/img2.png',
				name_point: 'Bağdat Pastanesi',
				description_point: '',
				url_point: '02.html'
			},
			{
				name: 'Cronulla Beach',
				location_latitude: 41.154307, 
				location_longitude: 27.814274,
				map_image_url: 'img/img3.png',
				name_point: 'Simit sarayı',
				description_point: '',
				url_point: '02.html'
			},
			{
				name: 'Manly Beach',
				location_latitude: 41.152804, 
				location_longitude: 27.816146,
				map_image_url: 'img/img.png',
				name_point: 'Layla Cafe',
				description_point: '',
				url_point: '02.html'
			},
			{
				name: 'Maroubra Beach',
				location_latitude: 41.157025, 
				location_longitude: 27.811173,
				map_image_url: 'img/img.png',
				name_point: 'Urfa Kebapçısı',
				description_point: '',
				url_point: '02.html'
			}
			],
		};

		function initialize () {
			
			if(!!navigator.geolocation) {
    
        var mapOptions = {
            zoom: 16,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
					
        };
        
        mapObject = new google.maps.Map(document.getElementById('map'), mapOptions);
    
        navigator.geolocation.getCurrentPosition(function(position) {
        
            var geolocate = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            
            
            
            mapObject.setCenter(geolocate);
            
        });
        
    } else {
        var mapOptions = {
				zoom: 16,
				center: new google.maps.LatLng(43.119, 131.883),
				mapTypeId: google.maps.MapTypeId.ROADMAP,

				mapTypeControl: false,
				mapTypeControlOptions: {
					style: google.maps.MapTypeControlStyle.DROPDOWN_MENU,
					position: google.maps.ControlPosition.LEFT_CENTER
				},
				panControl: false,
				
				MyLocationButton:true,
				zoomControl: false,
				zoomControlOptions: {
					style: google.maps.ZoomControlStyle.LARGE,
					position: google.maps.ControlPosition.TOP_RIGHT
				},
				scaleControl: false,
				scaleControlOptions: {
					position: google.maps.ControlPosition.TOP_LEFT
				},
				styles: [/*insert your map styles*/]
			};
    }
			var
			marker;
			mapObject = new google.maps.Map(document.getElementById('map'), mapOptions);
			for (var key in markersData)
				markersData[key].forEach(function (item) {
					marker = new google.maps.Marker({
						position: new google.maps.LatLng(item.location_latitude, item.location_longitude),
						map: mapObject,
						/*icon: 'img/icon/' + key + '.png',*/
						icon: 'img/icon/adres_pin.png',
					});

					if ('undefined' === typeof markers[key])
						markers[key] = [];
					markers[key].push(marker);
					google.maps.event.addListener(marker, 'click', (function () {
      closeInfoBox();
      getInfoBox(item).open(mapObject, this);
      mapObject.setCenter(new google.maps.LatLng(item.location_latitude, item.location_longitude));
     }));

					
				});
		};

		function hideAllMarkers () {
			for (var key in markers)
				markers[key].forEach(function (marker) {
					marker.setMap(null);
				});
		};

		function toggleMarkers (category) {
			hideAllMarkers();
			closeInfoBox();

			if ('undefined' === typeof markers[category])
				return false;
			markers[category].forEach(function (marker) {
				marker.setMap(mapObject);
				marker.setAnimation(google.maps.Animation.DROP);

			});
		};
		
		function closeInfoBox() {
			$('div.infoBox').remove();
		};

		function getInfoBox(item) {
			return new InfoBox({
				content:
				'<div class="marker_info none" id="marker_info">' +
				'<div class="info" id="info">'+
				'<img src="' + item.map_image_url + '" class="logotype" alt=""/>' +
				'<h2>'+ item.name_point +'<span></span></h2>' +
				'<span>'+ item.description_point +'</span>' +
				'<a href="'+ item.url_point + '" class="green_btn">Detaylı Bilgi</a>' +
				'<span class="arrow"></span>' +
				'</div>' +
				'</div>',
				disableAutoPan: true,
				maxWidth: 0,
				pixelOffset: new google.maps.Size(40, -210),
				closeBoxMargin: '50px 200px',
				closeBoxURL: '',
				isHidden: false,
				pane: 'floatPane',
				enableEventPropagation: true
			});


		};




