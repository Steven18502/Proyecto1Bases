import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ICliente } from './cliente';

@Injectable({
  providedIn: 'root'
})

export class ClientesService {

  constructor(private http : HttpClient) { }

  url : string = "https://localhost:5001/api/";

  // Metodo que invoca el metodo GET
  getClientes(): Observable<ICliente[]> {
    return this.http.get<ICliente[]>(this.url + "clientes");
  }

  // Metodo para crear una cliente proveniente de la web
  createCliente(cliente: ICliente): Observable<ICliente> {
    return this.http.post<ICliente>(this.url + "clientes", cliente);
  }

}
