package com.example.smartcart;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.provider.Settings;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.Toast;

public class PanelActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_panel);
        getSupportActionBar().hide();
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

        /*new AlertDialog.Builder(PanelActivity.this)
                .setTitle("Deconectar")
                .setMessage("Confirmación desconexión")
                .setPositiveButton("Confirmar",
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                Toast.makeText(PanelActivity.this, "Boton Confirmar", Toast.LENGTH_LONG).show();
                            }
                        })
               .setNegativeButton(("Cancelar"),null).show();*/
        Intent intent   = new Intent(PanelActivity.this, DeviceListActivity.class);
        startActivity((intent));
    }
}
