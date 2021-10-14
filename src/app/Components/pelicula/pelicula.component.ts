import { CinetecService } from 'src/app/cinetec.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pelicula',
  templateUrl: './pelicula.component.html',
  styleUrls: ['./pelicula.component.css']
})
export class PeliculaComponent implements OnInit {

  peliculas:string[] = ["Scary Movie","Avengers","Venom","El Santo","Jumanji"]; 
  pelicula_actual:string = "";

  constructor(private service:CinetecService) { }

  ngOnInit(): void {
  }

  seleccionarPelicula(pelicula:string){
    this.pelicula_actual = pelicula;
    this.service.setPelicula(this.pelicula_actual);
  }
}
