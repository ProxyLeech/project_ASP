<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planner.aspx.cs" Inherits="TouristHelp.Planner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src='https://api.mapbox.com/mapbox-gl-js/v1.7.0/mapbox-gl.js'></script>
    <link href='https://api.mapbox.com/mapbox-gl-js/v1.7.0/mapbox-gl.css' rel='stylesheet' />
    <style>
        .marker {
            background-image: url('Images/map-marker.png');
            background-size: cover;
            width: 30px;
            height: 30px;
            border-radius: 50%;
            cursor: pointer;
        }

        .mapboxgl-popup {
            max-width: 200px;
        }

        .mapboxgl-popup-content {
            text-align: center;
            font-family: 'Open Sans', sans-serif;
        }

        #instructions {
            position: absolute;
            margin: 20px;
            width: 25%;
            top: 0;
            bottom: 20%;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.9);
            overflow-y: scroll;
            font-family: sans-serif;
            font-size: 0.8em;
            line-height: 2em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-2">
        <div class="col-6">
            <form id="FormView1" runat="server">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblNoEntry" runat="server" Text="Add some places by visiting our list of Attractions! Meanwhile, enjoy this random selection!" ForeColor="Red" Visible="false"></asp:Label>
                        <asp:GridView ID="gvDirections" runat="server" AutoGenerateColumns="False" CssClass="table mw-100" OnSelectedIndexChanged="gvDirections_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" />
                                <asp:BoundField DataField="Location" HeaderText="Location" ReadOnly="True" Visible="False" />
                                <asp:BoundField DataField="Type" HeaderText="Type" ReadOnly="True" />
                                <asp:CommandField SelectText="Delete" ShowSelectButton="True">
                                    <ItemStyle CssClass="btn btn-danger" ForeColor="White" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle CssClass="thead-dark" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <p>Add attractions to your favorites! :</p>
                    </div>
                    <div class="col-5">
                        <asp:DropDownList ID="DropDownListAttractions" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col">
                        <asp:Button ID="BtnAddAttraction" runat="server" Text="Add to Favorites" OnClick="BtnAddAttraction_Click" CssClass="btn btn-info" />
                    </div>
                </div>
                <hr class="my-4" style="border: 1px dashed black" />
                <div class="row">
                    <div class="col-12">
                        <h3>Get Directions!</h3>
                        <h4>Add locations in the order you want to visit them:</h4>
                    </div>
                    <div class="col">
                        <p>Saved locations:</p>
                    </div>
                    <div class="col-5">
                        <asp:DropDownList ID="DropDownListSaved" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="col">
                        <button type="button" class="btn btn-info" onclick="addToList();">Add to Directions</button>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-5 form-group">
                        <select id="listForDir" class="form-control mb-3" multiple></select>
                        <button type="button" class="btn btn-warning" onclick="removeFromList();">Remove from list</button>
                    </div>
                    <div class="col-3 ml-3">
                        <div class="form-check">
                            <input class="form-check-input" type="radio" name="transportMode" id="walkingRB" value="walking" checked />
                            <label class="form-check-label" for="walkingRB">Walking</label>
                        </div>
                        <div class="form-check">
                            <input class="form-check-input" type="radio" name="transportMode" id="drivingRB" value="driving" />
                            <label class="form-check-label" for="drivingRB">Driving</label>
                        </div>
                        <br />
                        <button type="button" class="btn btn-success" onclick="getDirections();">Get directions</button>
                    </div>
                </div>

                <asp:HiddenField ID="GeoJsonHidden" runat="server" Value="" />
            </form>
        </div>
        <div class="col-6">
            <div id='map' style='width: auto; height: 80vh;'></div>
            <div id="instructions" style="visibility: hidden"></div>
        </div>
    </div>
    <script>
        mapboxgl.accessToken = 'pk.eyJ1IjoiMTg0NDUxai1ueXAiLCJhIjoiY2szbmJobTJuMWI1MTNnbWlta3QwZ3BqZSJ9.PbaZ3Kq-_qUDjV9qMUdIWQ';
        var map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v11?optimize=true',
            center: [103.8198, 1.3521]
        });

        map.setMaxBounds([[103.560239, 1.182667], [104.093586, 1.511393]]);

        map.addControl(new mapboxgl.NavigationControl());
        map.setRenderWorldCopies(false);

        var geo = JSON.parse(document.getElementById("<%= GeoJsonHidden.ClientID %>").value);

        map.on('load', function () {
            geo.forEach(function (marker) {
                // create a HTML element for each feature
                var el = document.createElement('div');
                el.className = 'marker';

                // make a marker for each feature and add to the map
                new mapboxgl.Marker(el)
                    .setLngLat(marker.geometry.coordinates).
                    setPopup(new mapboxgl.Popup({ offset: 25 })
                        .setHTML("<h3>" + marker.properties.title + "</h3><p>" + marker.properties.description + "</p>"))
                    .addTo(map);
            });
        });
        
        function addToList() {
            var e = document.getElementById("<%= DropDownListSaved.ClientID %>");
            var place = e.options[e.selectedIndex].text;

            var opt = document.createElement("option");
            opt.appendChild(document.createTextNode(place));
            opt.value = place;
            document.getElementById("listForDir").appendChild(opt);
        }

        function removeFromList() {
            $("#listForDir option:selected").remove();
        }

        function getDirections() {
            var arr = []; //names of places selected for directions
            var coords = []; //coordinates of places in [y, x] form
            var ddl = document.getElementById("listForDir");
            for (var i = 0; i < ddl.options.length; i++) {
                arr.push(ddl.options[i].value);
            }
            if (arr.length < 2) {
                alert("You need to select more than 2 places for directions!");
                return;
            }

            geo.forEach(function (obj) {
                if (arr.includes(obj.properties.title)) {
                    coords.push(obj.geometry.coordinates);
                }
            });

            var url = "https://api.mapbox.com/directions/v5/mapbox/" + $("input[name=transportMode]:checked").val() + "/";
            for (var i = 0; i < coords.length; i++) {
                url += coords[i][0] + "," + coords[i][1];
                if (i != coords.length - 1) {
                    url += ";";
                }
            }
            url += "?steps=true&geometries=geojson&access_token=" + mapboxgl.accessToken;

            var req = new XMLHttpRequest();
            req.open('GET', url, true);
            req.onload = function () {
                var json = JSON.parse(req.response);
                var data = json.routes[0];
                var route = data.geometry.coordinates;
                var geojson = {
                    type: 'Feature',
                    properties: {},
                    geometry: {
                        type: 'LineString',
                        coordinates: route
                    }
                };
                // if the route already exists on the map, reset it using setData
                if (map.getSource('route')) {
                    map.getSource('route').setData(geojson);
                } else { // otherwise, make a new request
                    map.addLayer({
                        id: 'route',
                        type: 'line',
                        source: {
                            type: 'geojson',
                            data: {
                                type: 'Feature',
                                properties: {},
                                geometry: {
                                    type: 'LineString',
                                    coordinates: geojson
                                }
                            }
                        },
                        layout: {
                            'line-join': 'round',
                            'line-cap': 'round'
                        },
                        paint: {
                            'line-color': '#e60000',
                            'line-width': 5,
                            'line-opacity': 0.75
                        }
                    });
                }
                var instructions = document.getElementById('instructions');
                instructions.style.visibility = "visible";
                var steps = data.legs[0].steps;

                var tripInstructions = [];
                for (var i = 0; i < steps.length; i++) {
                    tripInstructions.push('<br><li>' + steps[i].maneuver.instruction) + '</li>';
                    instructions.innerHTML = '<br><h4 class="duration">Trip duration: ' + Math.floor(data.duration / 60) + ' min </h4>' + tripInstructions;
                }
            }
            req.send();

            map.setCenter(coords[0]);
            map.setZoom(14);
        }
    </script>
</asp:Content>