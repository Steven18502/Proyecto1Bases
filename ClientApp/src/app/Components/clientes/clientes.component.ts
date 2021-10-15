import { Component, OnInit } from '@angular/core';
import { ICliente } from './cliente';
import { ClientesService } from './clientes.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})

export class ClientesComponent implements OnInit {

  // Listado de clientes que se mostraran en la interfaz de usuario
  clientes: ICliente[] = [];  

  constructor(private clientesService: ClientesService) { }

  ngOnInit(): void {
    this.clientesService.getClientes()
     .subscribe(clientesFromWS => this.clientes = clientesFromWS,
            error => console.error(error));
  }

}

