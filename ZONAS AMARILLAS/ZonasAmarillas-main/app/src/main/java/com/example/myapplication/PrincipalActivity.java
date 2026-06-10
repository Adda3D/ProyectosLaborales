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

public class PrincipalActivity extends FragmentActivity implements OnMapReadyCallback {

    private GoogleMap mMap;
    private LocationManager locationManager;
    private Location currentLocation;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_principal);
        // Obtain the SupportMapFragment and get notified when the map is ready to be used.
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);
    }


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

        LocationManager locationManager = (LocationManager) PrincipalActivity.this.getSystemService(Context.LOCATION_SERVICE);
        LocationListener locationListener = new LocationListener() {
            @Override
            public void onLocationChanged(@NonNull Location location) {
                LatLng miUbicacion = new LatLng(location.getLatitude(), location.getLongitude());
                mMap.addMarker(new MarkerOptions().position(miUbicacion).title("Estas aqui").icon(BitmapDescriptorFactory.fromResource(R.mipmap.ic_taxi)).anchor(0.0f,0.0f));
            }
        };
        int permiso = ContextCompat.checkSelfPermission(PrincipalActivity.this, Manifest.permission.ACCESS_COARSE_LOCATION);
        locationManager.requestLocationUpdates(LocationManager.NETWORK_PROVIDER, 0,0,locationListener);

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