package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class RolActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_rol);
    }

    public void irUsuario(View view){
        Intent i = new Intent(this, PrincipalActivity.class);
        startActivity(i);
    }

    public void irTaxista(View view){
        Intent i = new Intent(this, MapsActivity1.class);
        startActivity(i);
    }

}