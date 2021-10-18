package com.example.appcinetec;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.Toast;

import com.android.volley.NoConnectionError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.ServerError;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.ImageRequest;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class Peliculas extends AppCompatActivity {

    private RequestQueue queue;
    private Spinner spinner;
    private ImageView movieImageView;

    private static final String url="https://10.0.2.2:5001/api/peliculas";
    private static final String url2 = "https://my-json-server.typicode.com/typicode/demo/posts";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_peliculas);

        queue = Volley.newRequestQueue(this);
        //JsonArrayRequestPeliculas();

        String cine = getIntent().getStringExtra("cine");
        Toast.makeText(this, "Cine seleccionado: " + cine, Toast.LENGTH_SHORT ).show();

        spinner = (Spinner)findViewById(R.id.spinner);
        String [] opciones = MostrarPeliculas(cine);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, R.layout.spinner_item_cines, opciones);
        spinner.setAdapter(adapter);

        movieImageView = (ImageView) findViewById(R.id.imagen_pelis);


        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                if (i==0){
                    //Toast.makeText(Peliculas.this, "Entrooo ", Toast.LENGTH_SHORT ).show();
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
        queue.add(ImageRequest);
    }



    public String[] BuscarPeliculas (){
        AdminSQLiteOpenHelper admin = new AdminSQLiteOpenHelper(this,"administracion", null,1);
        SQLiteDatabase BaseDePrueba = admin.getWritableDatabase();

        Cursor fila = BaseDePrueba.rawQuery("select pnombre from peliculas", null);
        if(fila.getCount()==0){
            Toast.makeText(this, "No hay datos",Toast.LENGTH_LONG ).show();
        }
        List<String> pelis = new ArrayList<String>();
        while(fila.moveToNext()){
            pelis.add(fila.getString(0));
        }
        String array [] = new String[pelis.size()];
        pelis.toArray(array);

        BaseDePrueba.close();

        return array;
    }


    public void RegistrarPelicula(String id, String pnombre){
        AdminSQLiteOpenHelper admin = new AdminSQLiteOpenHelper(this, "administracion",null,1);
        SQLiteDatabase BaseDePrueba = admin.getWritableDatabase();

        ContentValues registro = new ContentValues();
        registro.put("pnombre_original",id);
        registro.put("pnombre",pnombre);

        BaseDePrueba.insert("peliculas",null, registro);

        registro.clear();

        BaseDePrueba.close();
        Toast.makeText(this, "Datos agregados peli",Toast.LENGTH_LONG ).show();
    }

    private void JsonArrayRequestPeliculas(){

        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                int size = response.length();
                Toast.makeText(Peliculas.this, "entra al on response", Toast.LENGTH_SHORT ).show();
                for (int i=0;i<size;i++){
                    try {
                        JSONObject jsonObject = new JSONObject(response.get(i).toString());
                        String id = jsonObject.getString("pnombre");
                        String pelinombre = jsonObject.getString("pduracion");
                        RegistrarPelicula(id,pelinombre);

                        Toast.makeText(Peliculas.this,"Nombre: "+pelinombre,Toast.LENGTH_SHORT).show();
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                if (error instanceof ServerError){
                    Toast.makeText(Peliculas.this,"SERVER ERROR" ,Toast.LENGTH_SHORT).show();
                }
                if (error instanceof NoConnectionError){
                    Toast.makeText(Peliculas.this,"No hay conexión a internet" ,Toast.LENGTH_SHORT).show();
                    Toast.makeText(Peliculas.this,"error: "+error.getMessage() ,Toast.LENGTH_LONG).show();
                }

            }
        });
        queue.add(request);

    }

}