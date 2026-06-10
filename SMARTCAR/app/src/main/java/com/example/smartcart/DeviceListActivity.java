package com.example.smartcart;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import androidx.annotation.Nullable;
import org.greenrobot.eventbus.EventBus;

import java.io.IOException;
import java.util.Collections;
import java.util.Set;
import java.util.UUID;

import com.example.smartcart.event.UiToastEvent;

import org.greenrobot.eventbus.EventBus;

import static android.content.ContentValues.TAG;

public class DeviceListActivity extends Activity {

    public static final String EXTRA_DEVICE_ADDRESS = "device_address";
    private BluetoothAdapter mBtAdapter;
    private  BluetoothSocket mmSocket;
    private BluetoothDevice device;
    private  BluetoothDevice mmDevice;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_device_list);
        getWindow().setBackgroundDrawable(new ColorDrawable(android.graphics.Color.TRANSPARENT));
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        mBtAdapter = BluetoothAdapter.getDefaultAdapter(); //Retorna el adaptador del bluetooth
        if(mBtAdapter == null){
            EventBus.getDefault().post(new UiToastEvent("Error de conexion", true, true));
            finish();
        }

        String Address = "54:E1:40:FA:BC:10";
    }
}
