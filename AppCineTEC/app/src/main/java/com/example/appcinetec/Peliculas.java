package com.example.appcinetec;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.ImageRequest;
import com.android.volley.toolbox.Volley;

public class Peliculas extends AppCompatActivity {

    private Spinner spinner;
    private ImageView movieImageView;
    private RequestQueue request;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_peliculas);

        String cine = getIntent().getStringExtra("cine");
        Toast.makeText(this, "Cine seleccionado:" + cine, Toast.LENGTH_SHORT ).show();

        spinner = (Spinner)findViewById(R.id.spinner);
        String [] opciones = MostrarPeliculas(cine);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, R.layout.spinner_item_cines, opciones);
        spinner.setAdapter(adapter);

        movieImageView = (ImageView) findViewById(R.id.imagen_pelis);

        request = Volley.newRequestQueue(getApplicationContext());

        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                if (i==0){
                    Toast.makeText(Peliculas.this, "Entrooo ", Toast.LENGTH_SHORT ).show();
                    String url = "https://fantasyvideostore.com/wp-content/uploads/2021/04/4K82-1.jpg";
                    cargarImagen(url);
                }
                else if (i==1){
                    movieImageView.setImageDrawable(ContextCompat.getDrawable(Peliculas.this,R.drawable.spiderman));
                }
                else if (i==2){
                    movieImageView.setImageDrawable(ContextCompat.getDrawable(Peliculas.this,R.drawable.fyf));
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });

    }

    public String[] MostrarPeliculas(String Cine) {
        String peliculas[];
        peliculas = new String[3];
        if (Cine.equals("Cine1")) {
            peliculas[0]="Iron man";
            peliculas[1]="Spiderman";
            peliculas[2]="Fast and Furious";
            //Toast.makeText(this, "sirve1",Toast.LENGTH_LONG ).show();

        }
        else if (Cine.equals("Cine2")) {
            peliculas[0]="Iron man2";
            peliculas[1]="Spiderman2";
            peliculas[2]="Fast and Furious2";
            //Toast.makeText(this, "sirve2",Toast.LENGTH_LONG ).show();

        }
        else if (Cine.equals("Cine3")){
            peliculas[0]="Iron man3";
            peliculas[1]="Spiderman3";
            peliculas[2]="Fast and Furious3";
            //Toast.makeText(this, "sirve3",Toast.LENGTH_LONG ).show();

        }
        return peliculas;
    }

    public void Continuar(View view) {
        String seleccion = spinner.getSelectedItem().toString();

        Intent i = new Intent(this,Proyecciones.class);
        i.putExtra("pelicula", spinner.getSelectedItem().toString());
        startActivity(i);

    }

    public void imagen(){
        String seleccion = spinner.getSelectedItem().toString();
        if (seleccion.equals("Iron man")){
            movieImageView.setImageDrawable(ContextCompat.getDrawable(this,R.drawable.iron_man_1));
        }
        else if (seleccion.equals("Iron man2")){
            movieImageView.setImageDrawable(ContextCompat.getDrawable(this,R.drawable.peli));
        }

    }

    public void cargarImagen(String url){
        url=url.replace(" ","%20");
        ImageRequest ImageRequest = new ImageRequest(url,
                new Response.Listener<Bitmap>() {
                    @Override
                    public void onResponse(Bitmap response) {
                        movieImageView.setImageBitmap(response);

                    }
                }, 0, 0, ImageView.ScaleType.CENTER, null, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Toast.makeText(Peliculas.this, "Imagen no disponible en este momento", Toast.LENGTH_SHORT ).show();

            }
        });
        request.add(ImageRequest);
    }

}