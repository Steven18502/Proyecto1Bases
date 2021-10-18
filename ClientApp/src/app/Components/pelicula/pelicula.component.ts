import { PeliculasService } from './../peliculas/peliculas.service';
import { DatosFacturaService } from './../../datos-factura.service';
import { CinetecService } from 'src/app/cinetec.service';
import { Component, OnInit } from '@angular/core';
import { IPelicula } from '../peliculas/pelicula';

@Component({
  selector: 'app-pelicula',
  templateUrl: './pelicula.component.html',
  styleUrls: ['./pelicula.component.css']
})
export class PeliculaComponent implements OnInit {

  peliculas: IPelicula[] = []; 
  pelicula_actual:string = "";

  constructor(private service:CinetecService, private peliculasService: PeliculasService, private datosFactura: DatosFacturaService) { }

  ngOnInit(): void {
    this.peliculasService.getPeliculas()
     .subscribe(peliculasFromWS => this.peliculas = peliculasFromWS,
            error => console.error(error));
  }

  seleccionarPelicula(pelicula:string){
    this.pelicula_actual = pelicula;
    this.service.setPelicula(this.pelicula_actual);
  }
}
