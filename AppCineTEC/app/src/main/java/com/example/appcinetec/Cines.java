package com.example.appcinetec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class Cines extends AppCompatActivity {

    private Spinner spinner;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cines);

        spinner = (Spinner)findViewById(R.id.spinner);
        String [] opciones = Buscar();
        ArrayAdapter <String> adapter = new ArrayAdapter<String>(this, R.layout.spinner_item_cines, opciones);
        spinner.setAdapter(adapter);

    }



//metodo que se encarga de pasar el nombre del cine seleccionado al siguiente activity
    public void Continuar(View view) {
        String seleccion = spinner.getSelectedItem().toString();

        Intent i = new Intent(this,Peliculas.class);
        i.putExtra("cine", spinner.getSelectedItem().toString());
        startActivity(i);

    }

    public String[] Buscar (){
        AdminSQLiteOpenHelper admin = new AdminSQLiteOpenHelper(this,"administracion", null,1);
        SQLiteDatabase BaseDePrueba = admin.getWritableDatabase();

        Cursor fila = BaseDePrueba.rawQuery("select nombre from cines", null);
        if(fila.getCount()==0){
            Toast.makeText(this, "No hay datos",Toast.LENGTH_LONG ).show();
        }
        List<String> cines = new ArrayList<String>();
        while(fila.moveToNext()){
            cines.add(fila.getString(0));
        }
        String array [] = new String[cines.size()];
        cines.toArray(array);

        BaseDePrueba.close();

        return array;
    }

}