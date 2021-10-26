import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IPelicula } from './pelicula';

@Injectable()
export class PeliculasService {
  
  private url : string = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  // Metodo que invoca el metodo GET
  getPeliculas(): Observable<IPelicula[]> {
    return this.http.get<IPelicula[]>(this.url + "peliculas");
  }

  getPelicula(peliculaId: string): Observable<IPelicula> {
    return this.http.get<IPelicula>(this.url + "peliculas" + "/" + peliculaId);
  }

  // Metodo para crear una pelicula proveniente de la web
  createPelicula(pelicula: IPelicula): Observable<IPelicula> {
    return this.http.post<IPelicula>(this.url + "peliculas", pelicula);
  }

  updatePelicula(pelicula: IPelicula): Observable<IPelicula> {
    return this.http.put<IPelicula>(this.url + "peliculas" + "/" + pelicula.pnombre_original.toString(), pelicula);
  }

  deletePelicula(peliculaId: string): Observable<IPelicula> {
    return this.http.delete<IPelicula>(this.url + "peliculas" + "/" + peliculaId);
  }

}
