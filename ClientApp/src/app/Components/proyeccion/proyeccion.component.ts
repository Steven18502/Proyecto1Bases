import { ProyeccionesService } from './proyecciones.service';
import { CinetecService } from 'src/app/cinetec.service';
import { Component, OnInit } from '@angular/core';
import { IProyeccion } from './proyeccion';

@Component({
  selector: 'app-proyeccion',
  templateUrl: './proyeccion.component.html',
  styleUrls: ['./proyeccion.component.css']
})
export class ProyeccionComponent implements OnInit {

  proyeccion_actual = "";
  pelicula:string = "";
  cinema:string = "";
  //proyecciones: string[] = ["5:30 pm Sala 3", "6:15 pm Sala 2","10:30am Sala 3"];
  proyecciones: IProyeccion[] =[];
  constructor(private service:CinetecService, private proyeccionesService: ProyeccionesService) { }

  ngOnInit(): void {
    /*this.service.cinemaAux.subscribe(c => {this.cinema = c});
    console.log(this.cinema);
    this.service.peliculaAux.subscribe(p => {this.pelicula = p});
    console.log(this.pelicula);*/
    this.proyeccionesService.getProyecciones()
     .subscribe(proyeccionesFromWS => this.proyecciones = proyeccionesFromWS,
            error => console.error(error));
  }

  seleccionar(proyeccion:string){
    this.proyeccion_actual = proyeccion;
    this.service.setSala(this.proyeccion_actual);
  }

}
