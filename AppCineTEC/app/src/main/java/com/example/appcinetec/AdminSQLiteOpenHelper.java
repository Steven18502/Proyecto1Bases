package com.example.appcinetec;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

public class AdminSQLiteOpenHelper extends SQLiteOpenHelper{


    public AdminSQLiteOpenHelper(@Nullable Context context, @Nullable String name, @Nullable SQLiteDatabase.CursorFactory factory, int version) {
        super(context, name, factory, version);
    }

    @Override
    public void onCreate(SQLiteDatabase BaseDePrueba) {
        BaseDePrueba.execSQL("create table cines(id int primary key, nombre text, ubicacion text)");
        //BaseDePrueba.execSQL("create table peliculas(pnombre_original text primary key, pnombre text, pduracion text, director text,clasificacion text,protagonistas text,pimagen text)");
        BaseDePrueba.execSQL("create table peliculas(pnombre_original text primary key, pnombre text)");

    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {

    }
}
