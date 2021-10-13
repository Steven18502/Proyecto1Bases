package com.example.appcinetec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

public class Proyecciones extends AppCompatActivity {

    private Spinner spinner;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_proyecciones);

        String pelicula = getIntent().getStringExtra("pelicula");
        Toast.makeText(this, "Pelicula seleccionada: " + pelicula, Toast.LENGTH_SHORT ).show();

        spinner = (Spinner)findViewById(R.id.spinner);
        String [] opciones = MostrarProyecciones(pelicula);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, R.layout.spinner_item_cines, opciones);
        spinner.setAdapter(adapter);
    }

    public String[] MostrarProyecciones(String Pelicula) {
        String proyecciones[];
        proyecciones = new String[3];
        if (Pelicula.equals("Iron man")) {
            proyecciones[0]="1:00 pm";
            proyecciones[1]="2:00 pm";
            proyecciones[2]="3:00 pm";
            //Toast.makeText(this, "sirve1",Toast.LENGTH_LONG ).show();

        }
        else if (Pelicula.equals("Spiderman")) {
            proyecciones[0]="4:00 pm";
            proyecciones[1]="5:00 pm";
            proyecciones[2]="6:00 pm";
            //Toast.makeText(this, "sirve2",Toast.LENGTH_LONG ).show();

        }
        else if (Pelicula.equals("Fast and Furious")){
            proyecciones[0]="7:00 pm";
            proyecciones[1]="8:00 pm";
            proyecciones[2]="9:00 pm";
            //Toast.makeText(this, "sirve3",Toast.LENGTH_LONG ).show();

        }
        return proyecciones;
    }

    public void Continuar(View view) {
        String seleccion = spinner.getSelectedItem().toString();

        Intent i = new Intent(this,Asientos.class);
        i.putExtra("proyeccion", spinner.getSelectedItem().toString());
        startActivity(i);

    }

}