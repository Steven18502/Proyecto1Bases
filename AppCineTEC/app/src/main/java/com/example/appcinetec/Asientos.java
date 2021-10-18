package com.example.appcinetec;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.Toast;

public class Asientos extends AppCompatActivity {

    private ImageView movieImageView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_asientos);

        String proyeccion = getIntent().getStringExtra("proyeccion");
        Toast.makeText(this, "Proyección seleccionada: " + proyeccion, Toast.LENGTH_SHORT ).show();

        movieImageView = (ImageView) findViewById(R.id.imagen_pelis);
        imagen();
    }

    public void imagen(){
        movieImageView.setImageDrawable(ContextCompat.getDrawable(this,R.drawable.asientos));


    }
}