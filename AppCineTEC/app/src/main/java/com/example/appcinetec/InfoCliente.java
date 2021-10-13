package com.example.appcinetec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class InfoCliente extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_info_cliente);

        Button btnCines = (Button)findViewById(R.id.button2);

        btnCines.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent menuCines = new Intent(InfoCliente.this, Cines.class);
                InfoCliente.this.startActivity(menuCines);

            }
        });
    }
}