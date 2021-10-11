import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pelicula',
  templateUrl: './pelicula.component.html',
  styleUrls: ['./pelicula.component.css']
})
export class PeliculaComponent implements OnInit {

  peliculas:string[] = ["Scary Movie","Avengers","Venom","El Santo","Jumanji"]; 

  constructor() { }

  ngOnInit(): void {
  }

}
