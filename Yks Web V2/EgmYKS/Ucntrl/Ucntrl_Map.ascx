<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucntrl_Map.ascx.cs" Inherits="EgmYKS.Ucntrl.Ucntrl_Map" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<link rel="Shortcut Icon" href="~/Logo/icon.png" type="image/x-icon" />
<link href="../css/themes/bootstrap.min.css" rel="stylesheet" />
<link href="../css/theme.min.css" rel="stylesheet" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
<link rel="stylesheet" href="https://openlayers.org/en/v4.4.1/css/ol.css" type="text/css">
 
<style>
    .olMarkerLabel {
        min-width: 150px;
        border: 1px solid;
        color: white;
        font-weight: bold;
        background-color: black;
        padding: 3px;
    }

    .buttonload {
        background-color: #4CAF50; /* Green background */
        border: none; /* Remove borders */
        color: white; /* White text */
        font-size: 10px; /* Set a font size */
    }
</style>

<div id="loadingDiv" style="display: none;">
    <i class="fa fa-spinner fa-spin"></i>Loading
                           
</div>
<div id="kanalMap" style="min-width: 550px; width: 100%; height: 550px;"></div>
 <dx:ASPxCallback ID="ASPxCallback1" ClientInstanceName="callbackKisayolListeGetir" runat="server" OnCallback="Callbackkisayollistegetir">
            <ClientSideEvents CallbackComplete="function(s,e) {KisayolListeCallbackComplete(s,e)}" />
        </dx:ASPxCallback>


  <!-- The line below is only needed for old environments like Internet Explorer and Android 4.x -->
    <script src="lib/Firebug/firebug.js"></script>
    <script type="text/javascript" src="lib/OpenLayers.js"></script>
    <!--<script type="text/javascript" src="test.js"></script>-->
    <script>

        var map;
        var drawControls, polygonLayer;
        var icon, marker, lonlat, markers;
        //YUSUF FONKSİYONLAR BAŞLANGIÇ
        OpenLayers.Marker.Label = OpenLayers.Class(OpenLayers.Marker, {
            /** 
             * Property: labelDiv
             * {DOMElement}
             */
            labelDiv: null,
            /** 
             * Property: label
             * {String}
             */
            label: null,
            /** 
             * Property: label
             * {Boolean}
             */
            mouseOver: false,
            /** 
             * Property: labelClass
             * {String}
             */
            labelClass: "olMarkerLabel",
            /** 
             * Property: events 
             * {<OpenLayers.Events>} the event handler.
             */
            events: null,
            /** 
             * Property: div
             * {DOMElement}
             */
            div: null,
            /** 
             * Property: onlyOnMouseOver
             * {Boolean}
             */
            onlyOnMouseOver: false,
            /** 
             * Property: mouseover
             * {Boolean}
             */
            mouseover: false,
            /** 
             * Property: labelOffset
             * {String}
             */
            labelOffset: "10px",
            /** 
             * Constructor: OpenLayers.Marker.Label
             * Parameters:
             * icon - {<OpenLayers.Icon>}  the icon for this marker
             * lonlat - {<OpenLayers.LonLat>} the position of this marker
             * label - {String} the position of this marker
             * options - {Object}
             */
            initialize: function (lonlat, icon, label, options) {
                var newArguments = [];
                OpenLayers.Util.extend(this, options);
                newArguments.push(lonlat, icon, label);
                OpenLayers.Marker.prototype.initialize.apply(this, newArguments);

                this.label = label;
                this.labelDiv = OpenLayers.Util.createDiv(this.icon.id + "_Text",
                    null, null);
                this.labelDiv.className = this.labelClass;
                this.labelDiv.innerHTML = label;
                this.labelDiv.style.marginTop = this.labelOffset;
                this.labelDiv.style.marginLeft = this.labelOffset;
            },

            /**
             * APIMethod: destroy
             * Destroy the marker. You must first remove the marker from any 
             * layer which it has been added to, or you will get buggy behavior.
             * (This can not be done within the marker since the marker does not
             * know which layer it is attached to.)
             */
            destroy: function () {
                this.label = null;
                this.labelDiv = null;
                OpenLayers.Marker.prototype.destroy.apply(this, arguments);
            },

            /** 
            * Method: draw
            * Calls draw on the icon, and returns that output.
            * 
            * Parameters:
            * px - {<OpenLayers.Pixel>}
            * 
            * Returns:
            * {DOMElement} A new DOM Image with this marker's icon set at the 
            * location passed-in
            */
            draw: function (px) {
                this.div = OpenLayers.Marker.prototype.draw.apply(this, arguments);
                this.div.appendChild(this.labelDiv, this.div.firstChild);

                if (this.mouseOver === true) {
                    this.setLabelVisibility(false);
                    this.events.register("mouseover", this, this.onmouseover);
                    this.events.register("mouseout", this, this.onmouseout);
                }
                else {
                    this.setLabelVisibility(true);
                }
                return this.div;
            },
            /** 
             * Method: onmouseover
             * When mouse comes up within the popup, after going down 
             * in it, reset the flag, and then (once again) do not 
             * propagate the event, but do so safely so that user can 
             * select text inside
             * 
             * Parameters:
             * evt - {Event} 
             */
            onmouseover: function (evt) {

                if (!this.mouseover) {
                    this.setLabelVisibility(true);
                    this.mouseover = true;
                }
                if (this.map.getSize().w -
                    this.map.getPixelFromLonLat(this.lonlat).x < 50) {
                    this.labelDiv.style.marginLeft = (-10 - this.icon.size.w) + "px";
                }
                if (this.map.getSize().h -
                    this.map.getPixelFromLonLat(this.lonlat).y < 50) {
                    this.labelDiv.style.marginTop = (-10 - this.icon.size.h) + "px";
                }
                OpenLayers.Event.stop(evt, true);
            },
            /** 
             * Method: onmouseout
             * When mouse goes out of the popup set the flag to false so that
             *   if they let go and then drag back in, we won't be confused.
             * 
             * Parameters:
             * evt - {Event} 
             */
            onmouseout: function (evt) {
                this.mouseover = false;
                this.setLabelVisibility(false);
                this.labelDiv.style.marginLeft = this.labelOffset;
                this.labelDiv.style.marginTop = this.labelOffset;
                OpenLayers.Event.stop(evt, true);
            },
            /** 
             * Method: setLabel
             * Set new label
             * 
             * Parameters:
             * label - {String} 
             */
            setLabel: function (label) {
                this.label = label;
                this.labelDiv.innerHTML = label;
            },
            /** 
             * Method: setLabelVisibility
             * Toggle label visibility
             * 
             * Parameters:
             * visibility - {Boolean} 
             */
            setLabelVisibility: function (visibility) {
                if (visibility) {
                    this.labelDiv.style.display = "block";
                }
                else {
                    this.labelDiv.style.display = "none";
                }
            },

            /** 
             * Method: getLabelVisibility
             * Get label visibility
             * 
             * Returns:
             *   visibility - {Boolean} 
             */
            getLabelVisibility: function () {
                if (this.labelDiv.style == "none") {
                    return false;
                }
                else {
                    return true;
                }
            },

            CLASS_NAME: "OpenLayers.Marker.Label"
        });


        function initold() {
            this.pj_epsg_900913 = new OpenLayers.Projection("EPSG:900913");
            this.pj_epsg_4326 = new OpenLayers.Projection("EPSG:4326");


            map = new OpenLayers.Map({
                div: "kanalMap",

                controls: [new OpenLayers.Control.LayerSwitcher(),
                           new OpenLayers.Control.Navigation(),
                           new OpenLayers.Control.ZoomPanel()],
                collapsible: false,
                collapsed: false,
                zoom: 5,
                units: 'm',
                projection: this.pj_epsg_900913,
                displayProjection: this.pj_epsg_4326,
                eventListeners: {
                    click: function (e) {

                        //var lonlat = map.getLonLatFromViewPortPx(e.xy);
                        //alert(map.getLonLatFromPixel(e.xy));
                        var lonlat = map.getLonLatFromPixel(e.xy);
                        var newPoint = new OpenLayers.Geometry.Point(lonlat.lon, lonlat.lat);

                        geometryLayer.removeFeatures([circleFeature]);
                        circle = OpenLayers.Geometry.Polygon.createRegularPolygon(
                          newPoint,
                          5000,
                          40,
                          0
                        );

                        circleFeature = new OpenLayers.Feature.Vector(circle);
                        geometryLayer.addFeatures([circleFeature]);

                    }

                }
            });


            this.osmLayer = new OpenLayers.Layer.OSM("OSM", null, {
                "tileOptions": {
                    "crossOriginKeyword": null
                }
            });

            this.map.addLayer(this.osmLayer);
            this.map.setCenter(new OpenLayers.LonLat(29.011077, 41.0783599).transform(
            this.pj_epsg_4326,
            this.pj_epsg_900913), 10);

            this.geometryLayer = new OpenLayers.Layer.Vector("Geometry");
            var lonlat_ = [29.011077, 41.078359];

            var circle = OpenLayers.Geometry.Polygon.createRegularPolygon(
                            new OpenLayers.Geometry.Point(lonlat_[0], lonlat_[1]).transform(
                            this.pj_epsg_4326,
                            this.pj_epsg_900913),
                            5000,
                            30);

            var circleFeatures = [];
            var circleFeature = new OpenLayers.Feature.Vector(circle);
            circleFeatures.push(circleFeature);
            // cleanup features first
            this.geometryLayer.removeAllFeatures();
            this.geometryLayer.addFeatures(circleFeatures);
            this.map.addLayer(this.geometryLayer);

            var road = new OpenLayers.Layer.OSM();
            map.addLayers([road]);
            markerspointer = new OpenLayers.Layer.Markers("MarkersPointer");
            map.addLayer(markerspointer);
            markers = new OpenLayers.Layer.Markers("Markers");
            map.addLayer(markers);
            var size = new OpenLayers.Size(21, 25);
            var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
            map.setCenter(new OpenLayers.LonLat(29.011077, 41.078359).transform(new OpenLayers.Projection("EPSG:4326"), map.getProjectionObject()), 12);

            map.events.register('moveend', map, UpdateMap);

        }

        var UpdateMap = function () {
            //var zoom = this.getZoom();
            var lonLat = map.getCenter().transform(new OpenLayers.Projection("EPSG:900913"), new OpenLayers.Projection("EPSG:4326")).toShortString(); //map.getCenter();
            var params = lonLat + "," + 10000;
            //alert(map.getCenter().transform(new OpenLayers.Projection("EPSG:900913"), new OpenLayers.Projection("EPSG:4326")).toShortString());//.transform(new OpenLayers.Projection("EPSG:900913"), new OpenLayers.Projection("EPSG:4326")).toShortString());

            gridTerminals.PerformCallback(params);
            circle.destroyFeatures();
            this.radiuslayer.destroyFeatures();
            // CircleMap(lonLat);
        }



        function OnGetSelectedFieldValues(selectedValues) {
            //alert(selectedValues[0]);
            if (selectedValues.length == 0) return;
            map.setCenter(new OpenLayers.LonLat(selectedValues[0], selectedValues[1]).transform(new OpenLayers.Projection("EPSG:4326"), map.getProjectionObject()), 12);
            pointerekle(selectedValues[1], selectedValues[0]);

        }
        function telefonFiltresiDoldur(value) {
            rTxtIhbarcitel.SetValue(value);
        }

        function ihbarciAdiFiltresiDoldur(value) {
            rTxtIhbarciAd.SetValue(value);
        }

        function benimIhbarlarimFiltreTemizle() {
            rTxtIhbarcitel.SetValue("");
            rTxtIhbarciAd.SetValue("");
            txtKullanici.SetValue("");
            lookKanal.SetValue(null);
        }
        function yuklemetamam(s, e) {
            var rowsCount = s.GetVisibleRowsOnPage();
            s.EndCallback.RemoveHandler(yuklemetamam);
            //alert(rowsCount);
            var i;
            if (rowsCount > 0) {
                markers.clearMarkers();
                for (i = 0; i < rowsCount; i++) {

                    s.GetRowValues(i, "KMRADI;KMRLON;KMRLAT", RecieveGridValues);
                    //alert(i + ". eklendi");
                }
            }
            //s.EndCallback.AddHandler(yuklemetamam);
        }
        function KisayolListeCallbackComplete(s, e) {
            $("#loadingDiv").hide();
            addmarkerfromlist(e.result);
        }
        function RecieveGridValues(values) {
            addmarkertolayer("/Resources/TouristicAndHistorical/agriculture.png", values[0], values[1], values[2]);
        }
        function addmarkerfromlist(mrklist) {
            markers.clearMarkers();
            var mrkobj = JSON.parse(mrklist);
            //alert(obj[0].markerTitle);
            mrkobj.forEach(function (mrk) {
                addmarkertolayer(mrk.markerIcon, mrk.markerTitle, mrk.markerLong, mrk.markerLat);
            });
        }
        function addmarkertolayer(ik, ttl, lng, lat) {
            var size = new OpenLayers.Size(21, 25);
            var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
            var icon = new OpenLayers.Icon(ik, size, offset);
            var marker = new OpenLayers.Marker.Label(new OpenLayers.LonLat(lng, lat).transform(new OpenLayers.Projection("EPSG:4326"), map.getProjectionObject()), icon, ttl, { mouseOver: true });
            markers.addMarker(marker);
        }
        function tabchanged(tbname) {
            if (tbname == "adresAra") {

            }
            else if (tbname == "hrtKsyl") {
                $("#loadingDiv").show();
                callbackKisayolListeGetir.PerformCallback(1);
            }
            else if (tbname == "kmrListe") {
                markers.clearMarkers();
            }
            else if (tbname == "ihbarListe") {

            }
        }
        function pointerekle(lng, lat) {
            markerspointer.clearMarkers();
            var size = new OpenLayers.Size(35, 25);
            var offset = new OpenLayers.Pixel(-(size.w / 2), -size.h);
            var icon = new OpenLayers.Icon("Resources/Squeeze_32x32.png", size, offset);
            //var marker = new OpenLayers.Marker.Label(new OpenLayers.LonLat(lng, lat).transform(new OpenLayers.Projection("EPSG:4326"), map.getProjectionObject()), icon, "", { mouseOver: true });
            var marker = new OpenLayers.Marker(new OpenLayers.LonLat(lng, lat).transform(new OpenLayers.Projection("EPSG:4326"), map.getProjectionObject()), icon);
            markerspointer.addMarker(marker);

        }
        //YUSUF FONKSİYONLAR BİTİŞ

        function OnGetRowValues(Values) {
            map.setCenter(new OpenLayers.LonLat(Values[2], Values[1]).transform(new OpenLayers.Projection("EPSG:4326"), map.getProjectionObject()), 12);
            gridKmrListe.EndCallback.AddHandler(function (s, e) { yuklemetamam(s, e); });
            gridKmrListe.PerformCallback(Values);

        }


        initold();
        tabchanged("hrtKsyl");

        //var circles = new OpenLayers.Layer.Vector("Kreise");
        ////var radiuslayer = new OpenLayers.Layer.Vector( );
        //var radiuslayer = new ol.layer.Vector({
        //    source: new ol.source.Vector(),
        //    style: styleFunction
        //});

        //var styleFunction = function (feature, resolution) {
        //    return [new ol.style.Style({ 
        //        fill: new ol.style.Fill({
        //            color: 'rgba(255, 0, 0, 0.1)'
        //        }) 
        //    })];
        //};

        //initialize a draw control
        //var my_polygonhandler = OpenLayers.Handler.RegularPolygon;

        //var polygonControl = new OpenLayers.Control.DrawFeature(circles,
        //my_polygonhandler, {
        //    handlerOptions: {
        //        sides: 100 
        //    }
        //});


        //initialize a map
        //var map = new OpenLayers.Map({
        //    div: 'kanalMap',
        //    projection: new OpenLayers.Projection('EPSG:900913'),
        //    displayProjection: new OpenLayers.Projection('EPSG:4326'),
        //    layers: [
        //    new OpenLayers.Layer.OSM(),
        //    circles, radiuslayer]
        //});
        //var mittelpunkt = new OpenLayers.LonLat(29.011077, 41.078359).transform(map.displayProjection, map.projection);
        //map.setCenter(mittelpunkt, 14);
        //map.addControl(polygonControl);
        //polygonControl.activate();

        //polygonControl.handler.callbacks.move = function (e) {

        //    var linearRing = new OpenLayers.Geometry.LinearRing(e.components[0].components);
        //    var geometry = new OpenLayers.Geometry.Polygon([linearRing]);
        //    var polygonFeature = new OpenLayers.Feature.Vector(geometry, null);
        //    var polybounds = polygonFeature.geometry.getBounds();

        //    var minX = polybounds.left;
        //    var minY = polybounds.bottom;
        //    var maxX = polybounds.right;
        //    var maxY = polybounds.top;

        //    //calculate the center coordinates

        //    var startX = (minX + maxX) / 2;
        //    var startY = (minY + maxY) / 2;

        //    //make two points at center and at the edge
        //    var startPoint = new OpenLayers.Geometry.Point(startX, startY);
        //    var endPoint = new OpenLayers.Geometry.Point(maxX, startY);
        //    var radius = new OpenLayers.Geometry.LineString([startPoint, endPoint]);
        //    var len = Math.round(radius.getLength()).toString();

        //    var laenge;
        //    if (len > 1000) {
        //        laenge = len / 1000;
        //        einheit = "km";
        //    } else {
        //        laenge = len;
        //        einheit = "m";
        //    }
        //    document.getElementById("radius").innerHTML = laenge;
        //    document.getElementById("einheit").innerHTML = einheit;
        //}

        //circles.events.on({
        //    'featureadded': function (e) {

        //        // DRY-principle not applied

        //        var f = e.feature;
        //        //calculate the min/max coordinates of a circle
        //        var minX = f.geometry.bounds.left;
        //        var minY = f.geometry.bounds.bottom;
        //        var maxX = f.geometry.bounds.right;
        //        var maxY = f.geometry.bounds.top;
        //        //calculate the center coordinates
        //        var startX = (minX + maxX) / 2;
        //        var startY = (minY + maxY) / 2;

        //        //make two points at center and at the edge
        //        var startPoint = new OpenLayers.Geometry.Point(startX, startY);
        //        var endPoint = new OpenLayers.Geometry.Point(maxX, startY);
        //        var radius = new OpenLayers.Geometry.LineString([startPoint, endPoint]);
        //        //calculate length. WARNING! The EPSG:900913 lengths are meaningless except around the equator. Either use a local coordinate system like UTM, or geodesic calculations.
        //        var len = Math.round(radius.getLength()).toString();
        //        //style the radius
        //        var fill = new Fill({ color: 'red' });
        //        var punktstyle = {
        //            strokeColor: "red",
        //            strokeWidth: 2,
        //            pointRadius: 5,
        //            fillOpacity: 0.2, 
        //        };


        //        var style = { 
        //            strokeColor: "#CC3333",
        //            strokeWidth: 3,
        //            label: len + " m",
        //            labelAlign: "left",
        //            labelXOffset: "20",
        //            labelYOffset: "10",
        //            labelOutlineColor: "white",
        //            labelOutlineWidth: 3
        //        };
        //        //add radius feature to radii layer
        //        var punkt1 = new OpenLayers.Feature.Vector(startPoint, {

        //        }, punktstyle);
        //        var fea = new OpenLayers.Feature.Vector(radius, {
        //            'length': len
        //        }, style);

        //        alert(startPoint+endPoint);
        //        radiuslayer.addFeatures([punkt1, fea]);
        //    }
        //});



    </script>