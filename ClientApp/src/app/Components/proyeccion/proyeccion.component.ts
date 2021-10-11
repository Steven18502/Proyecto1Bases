import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-proyeccion',
  templateUrl: './proyeccion.component.html',
  styleUrls: ['./proyeccion.component.css']
})
export class ProyeccionComponent implements OnInit {

  proyeccion_actual = "";
  proyecciones: string[] = ["5:30 pm Sala 3", "6:15 pm Sala 2","10:30am Sala 3"]
  constructor() { }

  ngOnInit(): void {
  }

  seleccionar(proyeccion:string){
    this.proyeccion_actual = proyeccion
  }

}
