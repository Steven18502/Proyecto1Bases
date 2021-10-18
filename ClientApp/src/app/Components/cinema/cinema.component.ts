import { DatosFacturaService } from './../../datos-factura.service';
import { ISucursal } from './../sucursales/sucursal';
import { SucursalesService } from '../sucursales/sucursales.service';
import { CinetecService } from 'src/app/cinetec.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cinema',
  templateUrl: './cinema.component.html',
  styleUrls: ['./cinema.component.css']
})
export class CinemaComponent implements OnInit {

  sucursales: ISucursal[] = [];
  cinema_actual: string = "";

  constructor(private sucursalesService: SucursalesService, private service:CinetecService,
      private datosFactura: DatosFacturaService) { }

  ngOnInit(): void {
    this.sucursalesService.getSucursales()
     .subscribe(sucursalesFromWS => this.sucursales = sucursalesFromWS,
            error => console.error(error));
  }

  seleccionar(cinema:string){
    this.cinema_actual = cinema
    this.service.setCinema(this.cinema_actual)
  }

}
