import { CinetecService } from 'src/app/cinetec.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-proyeccion',
  templateUrl: './proyeccion.component.html',
  styleUrls: ['./proyeccion.component.css']
})
export class ProyeccionComponent implements OnInit {

  proyeccion_actual = "";
  proyecciones: string[] = ["5:30 pm Sala 3", "6:15 pm Sala 2","10:30am Sala 3"];
  pelicula:string = "";
  cinema:string = "";
  constructor(private service:CinetecService) { }

  ngOnInit(): void {
    this.service.cinemaAux.subscribe(c => {this.cinema = c});
    console.log(this.cinema);
    this.service.peliculaAux.subscribe(p => {this.pelicula = p});
    console.log(this.pelicula);
  }

  seleccionar(proyeccion:string){
    this.proyeccion_actual = proyeccion;
    this.service.setSala(this.proyeccion_actual);
  }

}
