import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IPelicula } from './pelicula';

@Injectable({
  providedIn: 'root'
})

export class PeliculasService {

  constructor(private http : HttpClient) { }

  url : string = "https://localhost:5001/api/";

  // Metodo que invoca el metodo GET
  getPeliculas(): Observable<IPelicula[]> {
    return this.http.get<IPelicula[]>(this.url + "peliculas");
  }

  // Metodo para crear una pelicula proveniente de la web
  createPelicula(pelicula: IPelicula): Observable<IPelicula> {
    return this.http.post<IPelicula>(this.url + "peliculas", pelicula);
  }

}
