package com.example.myapplication;

import android.Manifest;
import android.content.Context;
import android.content.pm.PackageManager;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.view.View;

import androidx.annotation.NonNull;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.FragmentActivity;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.CameraPosition;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;

public class MapsActivity1 extends FragmentActivity implements OnMapReadyCallback {

    private GoogleMap mMap;
    private LocationManager locationManager;
    private Location currentLocation;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_maps1);
        // Obtain the SupportMapFragment and get notified when the map is ready to be used.
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);
    }

    /**
     * Manipulates the map once available.
     * This callback is triggered when the map is ready to be used.
     * This is where we can add markers or lines, add listeners or move the camera. In this case,
     * we just add a marker near Sydney, Australia.
     * If Google Play services is not installed on the device, the user will be prompted to install
     * it inside the SupportMapFragment. This method will only be triggered once the user has
     * installed Google Play services and returned to the app.
     */
    @Override
    public void onMapReady(GoogleMap googleMap) {
        mMap = googleMap;

        LatLng bogota = new LatLng(4.636565282731868, -74.10438544309123);
        mMap.moveCamera(CameraUpdateFactory.newLatLng(bogota));
        CameraPosition cameraPosition = new CameraPosition.Builder().target(bogota).zoom(14).bearing(90).tilt(45).build();
        mMap.animateCamera(CameraUpdateFactory.newCameraPosition(cameraPosition));

        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            return;
        }
        mMap.setMyLocationEnabled(true);

        LocationManager locationManager = (LocationManager) MapsActivity1.this.getSystemService(Context.LOCATION_SERVICE);
        LocationListener locationListener = new LocationListener() {
            @Override
            public void onLocationChanged(@NonNull Location location) {
                LatLng miUbicacion = new LatLng(location.getLatitude(), location.getLongitude());
                mMap.addMarker(new MarkerOptions().position(miUbicacion).title("Estas aqui").icon(BitmapDescriptorFactory.fromResource(R.mipmap.ic_taxi)).anchor(0.0f,0.0f));
            }
        };
        int permiso = ContextCompat.checkSelfPermission(MapsActivity1.this, Manifest.permission.ACCESS_COARSE_LOCATION);
        locationManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, 0,0,locationListener);

    }

    public void buscarBanos(View view){
        mMap.clear();
        LatLng bano1 = new LatLng(4.59770083076164, -74.0697966646554);
        mMap.addMarker(new MarkerOptions().position(bano1).title("Baño Publico").snippet("Entrada Gratuita").icon(BitmapDescriptorFactory.fromResource(R.drawable.toilets)));

        LatLng bano2 = new LatLng(4.60676954914807, -74.0710412096324);
        mMap.addMarker(new MarkerOptions().position(bano2).title("Baño Publico").snippet("Entrada Gratuita").icon(BitmapDescriptorFactory.fromResource(R.drawable.toiletsw)));

        LatLng bano3 = new LatLng(4.59977017707939, -74.1005133221910);
        mMap.addMarker(new MarkerOptions().position(bano3).title("Baño Publico").snippet("Entrada Gratuita").icon(BitmapDescriptorFactory.fromResource(R.drawable.toilets)));

        LatLng bano4 = new LatLng(4.62068788190477, -74.0678976607255);
        mMap.addMarker(new MarkerOptions().position(bano4).title("Baño Publico").snippet("Entrada Gratuita").icon(BitmapDescriptorFactory.fromResource(R.drawable.toiletsw)));


    }

    public void buscarRestaurantes(View view){
        mMap.clear();
        LatLng rest1 = new LatLng(4.56711546927607,  -74.1141976270048);
        mMap.addMarker(new MarkerOptions().position(rest1).title("Taxi Restaurante").snippet("Platos desde $5000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest2 = new LatLng(4.71323631230588,  -74.2195241865184);
        mMap.addMarker(new MarkerOptions().position(rest2).title("Taxi Parrilla").snippet("Platos desde $7000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest3 = new LatLng(4.68155535174551,  -74.0872626135024);
        mMap.addMarker(new MarkerOptions().position(rest3).title("El gourmet del taxista").snippet("Platos desde $6500 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest4 = new LatLng(4.63637944906163,  -74.0896677453381);
        mMap.addMarker(new MarkerOptions().position(rest4).title("Restaurante Tip top").snippet("Platos desde $7000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest5 = new LatLng(4.67409563238408,  -74.0972332597138);
        mMap.addMarker(new MarkerOptions().position(rest5).title("Punto 69").snippet("Platos desde $4000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.fastfood)));

        LatLng rest6 = new LatLng(4.67372120573474,  -74.0972118338642);
        mMap.addMarker(new MarkerOptions().position(rest6).title("Caldo Parado").snippet("Platos desde $3000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest7 = new LatLng(4.68376462883259,  -74.0919834597140);
        mMap.addMarker(new MarkerOptions().position(rest7).title("La Playita y El Paisa").snippet("Platos desde $8000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest8 = new LatLng(4.71480573265367,  -74.1275066358174);
        mMap.addMarker(new MarkerOptions().position(rest8).title("Asadero Restaurante Carne Brava").snippet("Platos desde $10000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest9 = new LatLng(4.69016504065083,  -74.0842894155339);
        mMap.addMarker(new MarkerOptions().position(rest9).title("Doña Marlén").snippet("Platos desde $6500 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest10 = new LatLng(4.66627645147505,  -74.0566198757782);
        mMap.addMarker(new MarkerOptions().position(rest10).title("Arroz con pollo de la Zona Rosa").snippet("Platos desde $9000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest11 = new LatLng(4.65153766013421,  -74.0604589866978);
        mMap.addMarker(new MarkerOptions().position(rest11).title("Restaurante y desayunadero El taxista").snippet("Platos desde $4000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest12 = new LatLng(4.61176604812820,  -74.1298082568445);
        mMap.addMarker(new MarkerOptions().position(rest12).title("Carpa de carnes").snippet("Platos desde $11000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));

        LatLng rest13 = new LatLng(4.58326032209170,  -74.0893339187104);
        mMap.addMarker(new MarkerOptions().position(rest13).title("La gorda").snippet("Platos desde $8000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.fastfood)));

        LatLng rest14 = new LatLng(4.61519953119375,  -74.1626031155339);
        mMap.addMarker(new MarkerOptions().position(rest14).title("Comederos de Casablanca").snippet("Platos desde $7000 para taxistas").icon(BitmapDescriptorFactory.fromResource(R.drawable.restaurant)));


    }

    public void buscarZonas(View view){
        mMap.clear();
        LatLng zona1 = new LatLng(4.60027678787555, -74.0679507885499);
        mMap.addMarker(new MarkerOptions().position(zona1).title("Zona 1").snippet("Tiempo de espera aproximado: 3min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona2 = new LatLng(4.62201953928506, -74.0763670597139);
        mMap.addMarker(new MarkerOptions().position(zona2).title("Zona 2").snippet("Tiempo de espera aproximado: 10min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona3 = new LatLng(4.63022169099773, -74.0946704844884);
        mMap.addMarker(new MarkerOptions().position(zona3).title("Zona 3").snippet("Tiempo de espera aproximado: 10min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona4 = new LatLng(4.58439648692456, -74.1051203038940);
        mMap.addMarker(new MarkerOptions().position(zona4).title("Zona 4").snippet("Tiempo de espera aproximado: 5min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona5 = new LatLng(4.60825018559266, -74.0668436443699);
        mMap.addMarker(new MarkerOptions().position(zona5).title("Zona 5").snippet("Tiempo de espera aproximado: 6min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona6 = new LatLng(4.60724405673877, -74.0710662597139);
        mMap.addMarker(new MarkerOptions().position(zona6).title("Zona 6").snippet("Tiempo de espera aproximado: 10min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona7 = new LatLng(4.60428710643006, -74.0717099899544);
        mMap.addMarker(new MarkerOptions().position(zona7).title("Zona 7").snippet("Tiempo de espera aproximado: 15min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona8 = new LatLng(4.65292742488825, -74.1089937597140);
        mMap.addMarker(new MarkerOptions().position(zona8).title("Zona 8").snippet("Tiempo de espera aproximado: 3min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona9 = new LatLng(4.65256225561198, -74.0605593020419);
        mMap.addMarker(new MarkerOptions().position(zona9).title("Zona 9").snippet("Tiempo de espera aproximado: 5min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

        LatLng zona10 = new LatLng(4.65040282809549, -74.0847409443700);
        mMap.addMarker(new MarkerOptions().position(zona10).title("Zona 10").snippet("Tiempo de espera aproximado: 3min").icon(BitmapDescriptorFactory.fromResource(R.drawable.parking)));

    }
}