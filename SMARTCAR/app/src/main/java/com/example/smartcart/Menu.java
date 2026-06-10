package com.example.smartcart;
import java.io.File;
import java.math.BigInteger;

import  androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.helper.widget.Layer;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Bundle;
import android.os.Message;
import android.provider.MediaStore;
import android.text.SpannableStringBuilder;
import android.view.LayoutInflater;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.MediaController;
import android.widget.TextView;
import android.widget.Toast;

import com.example.smartcart.event.UiToastEvent;
import com.example.smartcart.util.Config;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

import org.greenrobot.eventbus.EventBus;
import org.greenrobot.eventbus.Subscribe;
import org.greenrobot.eventbus.ThreadMode;
import org.w3c.dom.Text;

import static java.sql.DriverManager.println;
import android.view.View;
import android.widget.VideoView;
import org.mariuszgromada.math.mxparser.*;

public class Menu extends AppCompatActivity {
    //Initialize variable
    ImageButton btScan;
    //Cambio de imagenes
    Button b1,btnpagar;
    Button b2;
    Button b3;
    Button turno;
    ImageView iv1;
    VideoView video1;
    LinearLayout Calculadora;
    LinearLayout Carniceria;
    LinearLayout Turno_L;
    Button pagar;
    boolean flag;
    //int images[]={R.drawable.ejem_1,R.drawable.ejem_2,R.drawable.ejem_3};
    int i=0;
    int codigo;
    //Bluetooth
    BluetoothAdapter bluetoothAdapter = null;

    //CALCULADORA
    Button number1;
    Button number2;
    Button number3;
    Button number4;
    Button number5;
    Button number6;
    Button number7;
    Button number8;
    Button number9;
    Button number0;
    Button suma;
    Button resta;
    Button multiplicacion;
    Button divicion;
    Button punto;
    Button borrar;
    Button igual;
    Button retro;
    private EditText operacion;

    public Menu() {
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);
        getSupportActionBar().hide();
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        BluetoothAdapter bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        //Cambio de imagenes
        iv1=(ImageView) findViewById(R.id.imageView5);
        iv1.setVisibility(View.GONE);

        //CALCULADORA
        final LinearLayout Calculadora = (LinearLayout) findViewById(R.id.calculadora);
        Calculadora.setVisibility(View.GONE);
        //CARNICERIA
        final LinearLayout Carniceria = (LinearLayout) findViewById(R.id.carniceria);
        Carniceria.setVisibility(View.GONE);
        final LinearLayout Turno_L = (LinearLayout) findViewById(R.id.turno_layaut);
        Turno_L.setVisibility(View.GONE);
        //VIDEO
        MediaController mediaController = new MediaController(this);
        final VideoView video1 = (VideoView) findViewById(R.id.VideoView);
        Uri uri = Uri.parse("https://drive.google.com/uc?id=1p4xY7TooFB0tIEPwQJRnkPKXJiTRLZ7J"); //https://www.youtube.com/embed/P2gNbsr1YHI
        video1.setVideoURI(uri);
        video1.start();

        //------------------------------------------------------------------------------------------------------
        //BOTONES
        //------------------------------------------------------------------------------------------------------
        b1=(Button) findViewById(R.id.button2);
        flag=true;
        b1.setOnClickListener(new View.OnClickListener() {
            @Override

            public void onClick(View v) {
                b1.setBackground(getResources().getDrawable(R.drawable.borde_redondo_amarillo));
                b2.setBackground(getResources().getDrawable(R.drawable.borde_gris));
                b3.setBackground(getResources().getDrawable(R.drawable.borde_gris));
                iv1.setImageResource(R.drawable.ejem_1);
                iv1.setVisibility(View.VISIBLE);
                video1.setVisibility(View.GONE);
                Calculadora.setVisibility(View.GONE);
                Carniceria.setVisibility(View.GONE);
                Turno_L.setVisibility(View.GONE);
                //Para que vuelva al video cada vez que se preciona el boton
                /*
                    if(i==0) {
                        iv1.setImageResource(R.drawable.ejem_1);
                        iv1.setVisibility(View.VISIBLE);
                        video1.setVisibility(View.GONE);
                        Calculadora.setVisibility(View.GONE);
                        i=1;
                    }
                    else{
                        iv1.setVisibility(View.GONE);
                        video1.setVisibility(View.VISIBLE);
                        video1.setVideoURI(uri);
                        video1.start();
                        i=0;
                    }*/
            }
        });
        b2=(Button) findViewById(R.id.button3);
        b2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                b1.setBackground(getResources().getDrawable(R.drawable.borde_gris));
                b2.setBackground(getResources().getDrawable(R.drawable.borde_redondo_amarillo));
                b3.setBackground(getResources().getDrawable(R.drawable.borde_gris));
                video1.setVisibility(View.GONE);
                Calculadora.setVisibility(View.GONE);
                Carniceria.setVisibility(View.VISIBLE);
                iv1.setVisibility(View.GONE);
                Turno_L.setVisibility(View.GONE);

                //Para que vuelva al video cada vez que se preciona el boton
                /*
                if(i==0) {
                    iv1.setImageResource(R.drawable.ejem_2);
                    iv1.setVisibility(View.VISIBLE);
                    video1.setVisibility(View.GONE);
                    Calculadora.setVisibility(View.GONE);
                    i=1;
                }
                else{
                    iv1.setVisibility(View.GONE);
                    video1.setVisibility(View.VISIBLE);
                    video1.setVideoURI(uri);
                    video1.start();
                    i=0;
                }*/
            }

        });
        b3=(Button) findViewById(R.id.button4);
        b3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                b1.setBackground(getResources().getDrawable(R.drawable.borde_gris));
                b2.setBackground(getResources().getDrawable(R.drawable.borde_gris));
                b3.setBackground(getResources().getDrawable(R.drawable.borde_redondo_amarillo));
                iv1.setImageResource(R.drawable.ejem_3);
                iv1.setVisibility(View.GONE);
                video1.setVisibility(View.GONE);
                Calculadora.setVisibility(View.VISIBLE);
                Turno_L.setVisibility(View.GONE);
                Carniceria.setVisibility(View.GONE);
                //Para que vuelva al video cada vez que se preciona el boton
                /*
                if(i==0) {
                    iv1.setImageResource(R.drawable.ejem_3);
                    iv1.setVisibility(View.GONE);
                    video1.setVisibility(View.GONE);
                    Calculadora.setVisibility(View.VISIBLE);
                    i=1;
                }
                else{
                    iv1.setVisibility(View.GONE);
                    Calculadora.setVisibility(View.GONE);
                    video1.setVisibility(View.VISIBLE);
                    video1.setVideoURI(uri);
                    video1.start();
                    i=0;
                }*/
                    //EventBus.getDefault().post(new UiToastEvent("Hola",true,false));
            }
        });

        turno=(Button) findViewById(R.id.Turno);
        turno.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                iv1.setVisibility(View.GONE);
                video1.setVisibility(View.GONE);
                Calculadora.setVisibility(View.GONE);
                Turno_L.setVisibility(View.VISIBLE);
                Carniceria.setVisibility(View.GONE);
            }
        });
        //Fin cambio de imagenes
        //------------------------------------------------------------------------------------------------------
        //BOTON SCANNER
        //------------------------------------------------------------------------------------------------------
        btScan = findViewById(R.id.bt_scan);
        btScan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                IntentIntegrator intentIntegrator = new IntentIntegrator(
                        Menu.this
                );
                intentIntegrator.setPrompt("Para usar Flah use la tecalde subir volumen");
                intentIntegrator.setBeepEnabled(true);
                intentIntegrator.setOrientationLocked(true);
                intentIntegrator.setCaptureActivity(Capture.class);
                intentIntegrator.initiateScan();
            }
        });
        //Fin programa de Scanner
        //------------------------------------------------------------------------------------------------------
        //CALCULADORA
        //------------------------------------------------------------------------------------------------------
        operacion = (EditText) findViewById(R.id.pantalla);
        number0=(Button) findViewById(R.id.btn0);
        number0.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //operacion.setText("0");
                updateText("0");

            }
        });
        number1=(Button) findViewById(R.id.btn1);
        number1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //operacion.setText("1");
                updateText("1");
            }
        });
        number2=(Button) findViewById(R.id.btn2);
        number2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //operacion.setText("2");
                updateText("2");
            }
        });
        number3=(Button) findViewById(R.id.btn3);
        number3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("3");
            }
        });
        number4=(Button) findViewById(R.id.btn4);
        number4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("4");
            }
        });
        number5=(Button) findViewById(R.id.btn5);
        number5.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("5");
            }
        });
        number6=(Button) findViewById(R.id.btn6);
        number6.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("6");
            }
        });
        number7=(Button) findViewById(R.id.btn7);
        number7.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("7");
            }
        });
        number8=(Button) findViewById(R.id.btn8);
        number8.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("8");
            }
        });
        number9=(Button) findViewById(R.id.btn9);
        number9.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("9");
            }
        });
        suma=(Button) findViewById(R.id.btnsuma);
        suma.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("+");
            }
        });
        resta=(Button) findViewById(R.id.btnmenos);
        resta.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("-");
            }
        });
        multiplicacion=(Button) findViewById(R.id.btnpor);
        multiplicacion.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("x");
            }
        });
        divicion=(Button) findViewById(R.id.btndividir);
        divicion.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText("/");
            }
        });
        igual=(Button) findViewById(R.id.btnigual);
        igual.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String userExp = operacion.getText().toString();
                userExp = userExp.replaceAll("x","*");
                Expression exp = new Expression(userExp);
                String result = String.valueOf(exp.calculate());
                operacion.setText("");
                updateText(result);
                operacion.setSelection((operacion.getText().length()));
            }
        });
        borrar=(Button) findViewById(R.id.btnborrar);
        borrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                operacion.setText("");
            }
        });
        punto=(Button) findViewById(R.id.btnpunto);
        punto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                updateText(".");
            }
        });
        retro=(Button) findViewById(R.id.btnretro);
        retro.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int cursorPos = operacion.getSelectionStart();
                int TextLen = operacion.getText().length();

                if(cursorPos != 0 && TextLen !=0){
                    SpannableStringBuilder selection = (SpannableStringBuilder) operacion.getText();
                    selection.replace(cursorPos -1,cursorPos,"");
                    operacion.setText(selection);
                    operacion.setSelection(cursorPos-1);

                }
            }
        });
        //------------------------------------------------------------------------------------------------------
        //BOTON PAGAR
        //------------------------------------------------------------------------------------------------------
        btnpagar = (Button) findViewById(R.id.pagar);
        btnpagar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent   = new Intent(Menu.this, DeviceListActivity.class);
                startActivity((intent));
                bluetoothAdapter.enable();
                //Intent i = new Intent(Menu.this, PanelActivity.class);
                //startActivity(i);
            }
        });
        //Fin del boton de pago
    }
    //------------------------------------------------------------------------------------------------------
    //CALCULADORA OPERACION DE TEXTO
    //------------------------------------------------------------------------------------------------------
    private void updateText(String strToAdd){
        String oldStr = operacion.getText().toString();
        int cursosPos = operacion.getSelectionStart();
        String leftStr = oldStr.substring(0, cursosPos);
        String rightStr = oldStr.substring(cursosPos);
        operacion.setText(String.format("%s%s%s", leftStr,strToAdd,rightStr));
        operacion.setSelection((operacion.getText().length()));

    }

    //------------------------------------------------------------------------------------------------------
    //OPERACION DEL SCANNER
    //------------------------------------------------------------------------------------------------------
    @Override
    protected void onActivityResult(int requesCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requesCode, resultCode, data);

        IntentResult intentResult = IntentIntegrator.parseActivityResult(
                requesCode,resultCode,data
        );

        if (intentResult.getContents() != null){
            AlertDialog.Builder builder = new AlertDialog.Builder(
                    Menu.this
            );
            LayoutInflater factory = LayoutInflater.from(Menu.this);
            final View view = factory.inflate(R.layout.sample, null);
            //7703812013697 - Sal Parrillera Marina Refisal $9000
            //10044006024731 - Infusión frutal Kanpur $2000
            //codigo = intentResult.getContents();
            String codigo_big = intentResult.getContents();

            if (codigo_big ==  "7703812013697"){
                    builder.setTitle("Sal Parrillera Marina Refisal");
                    builder.setMessage(intentResult.getContents());
                    builder .setPositiveButton("AGREGAR PRODUCTO", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialogInterface, int i) {
                            dialogInterface.dismiss();
                        }
                    });
                builder.setNegativeButton("OMITIR", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.dismiss();
                    }
                });
                    builder.show();
            }
            else if (codigo_big ==  "10044006024731"){
                builder.setTitle("Infusion");
                builder.setMessage(intentResult.getContents());
                builder .setPositiveButton("AGREGAR PRODUCTO", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.dismiss();
                    }
                });
                builder.setNegativeButton("OMITIR", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.dismiss();
                    }
                });
                builder.show();
            }
            else {
                builder.setView(view);
                //builder.setTitle("No logramos encontrar el producto");
                //builder.setMessage(codigo_big);
                builder.setPositiveButton("Intentar de nuevo", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialogInterface, int i) {
                        dialogInterface.dismiss();
                    }
                });

                builder.show();
             }

        }else{
            Toast.makeText(getApplicationContext()
                    ,"Ops... intenta nuevamente", Toast.LENGTH_SHORT)
                    .show();
        }
    }

    //------------------------------------------------------------------------------------------------------
    //BOTON PAGAR
    //------------------------------------------------------------------------------------------------------
    @Override
    public void onStart() {
        super.onStart();
        EventBus.getDefault().register(this);
    }

    @Override
    public void onStop() {
        super.onStop();
        EventBus.getDefault().unregister(this);
    }

    @Subscribe(threadMode = ThreadMode.MAIN)
    public void onUiToastEvent(UiToastEvent event) {
        Config.Mensaje(Menu.this,event.getMessage(),event.getLongToast(),event.getIsWarning());
    };
    //------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------
}
