import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IProyeccion } from './proyeccion';

@Injectable()
export class ProyeccionesService {
  
  private url : string = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  // Metodo que invoca el metodo GET
  getProyecciones(): Observable<IProyeccion[]> {
    return this.http.get<IProyeccion[]>(this.url + "proyecciones");
  }

  getProyeccion (proyeccionId: string): Observable<IProyeccion> {
    return this.http.get<IProyeccion>(this.url + "proyecciones" + "/" + proyeccionId);
  }

  // Metodo para crear una proyeccion proveniente de la web
  createProyeccion(proyeccion: IProyeccion): Observable<IProyeccion> {
    return this.http.post<IProyeccion>(this.url + "proyecciones", proyeccion);
  }

  updateProyeccion(proyeccion: IProyeccion): Observable<IProyeccion> {
    return this.http.put<IProyeccion>(this.url + "proyecciones" + "/" + proyeccion.proyeccionId.toString(), proyeccion);
  }

  deleteProyeccion(proyeccionId: number): Observable<IProyeccion> {
    return this.http.delete<IProyeccion>(this.url + "proyecciones" + "/" + proyeccionId);
  }

}
