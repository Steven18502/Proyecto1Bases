import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ISucursal } from './sucursal';

@Injectable()
export class SucursalesService {
  
  private url : string = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  // Metodo que invoca el metodo GET
  getSucursales(): Observable<ISucursal[]> {
    return this.http.get<ISucursal[]>(this.url + "sucursales");
  }

  getSucursal (nombre_cine: string): Observable<ISucursal> {
    return this.http.get<ISucursal>(this.url + "sucursales" + "/" + nombre_cine);
  }

  // Metodo para crear una sucursal proveniente de la web
  createSucursal(sucursal: ISucursal): Observable<ISucursal> {
    return this.http.post<ISucursal>(this.url + "sucursales", sucursal);
  }

  updateSucursal(sucursal: ISucursal): Observable<ISucursal> {
    return this.http.put<ISucursal>(this.url + "sucursales" + "/" + sucursal.nombre_cine, sucursal);
  }

  deleteSucursal(sucursalId: string): Observable<ISucursal> {
    return this.http.delete<ISucursal>(this.url + "sucursales" + "/" + sucursalId);
  }

}
