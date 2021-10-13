package com.example.appcinetec;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Toast;

public class Asientos extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_asientos);

        String proyeccion = getIntent().getStringExtra("proyeccion");
        Toast.makeText(this, "Proyección seleccionada: " + proyeccion, Toast.LENGTH_SHORT ).show();

    }
}