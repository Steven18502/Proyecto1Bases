package com.example.appcinetec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class Login extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        Button btnLogin = (Button)findViewById(R.id.btnLogin);

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent menuInfo = new Intent(Login.this, InfoCliente.class);
                Login.this.startActivity(menuInfo);
                finish();
            }
        });

        Registrar();
    }

    public void Registrar(){
        AdminSQLiteOpenHelper admin = new AdminSQLiteOpenHelper(this, "administracion",null,1);
        SQLiteDatabase BaseDePrueba = admin.getWritableDatabase();

        ContentValues registro = new ContentValues();
        registro.put("id",1);
        registro.put("nombre","Cine1");
        registro.put("ubicacion","Cartago");

        BaseDePrueba.insert("cines",null, registro);

        registro.clear();

        registro.put("id",2);
        registro.put("nombre","Cine2");
        registro.put("ubicacion","San Jose");

        BaseDePrueba.insert("cines",null, registro);

        registro.clear();

        registro.put("id",3);
        registro.put("nombre","Cine3");
        registro.put("ubicacion","Heredia");

        BaseDePrueba.insert("cines",null, registro);

        BaseDePrueba.close();
        Toast.makeText(this, "Datos agregados",Toast.LENGTH_LONG ).show();
    }
}