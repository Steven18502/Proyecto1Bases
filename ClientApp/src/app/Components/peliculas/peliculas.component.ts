import { Component, OnInit } from '@angular/core';
import { IPelicula } from './pelicula';
import { PeliculasService } from './peliculas.service';

@Component({
  selector: 'app-peliculas',
  templateUrl: './peliculas.component.html',
  styleUrls: ['./peliculas.component.css']
})
export class PeliculasComponent implements OnInit {

  // Listado de peliculas que se mostraran en la interfaz de usuario
  peliculas: IPelicula[] = [];  

  constructor(private peliculasService: PeliculasService) { }

  ngOnInit(): void {
    this.peliculasService.getPeliculas()
     .subscribe(peliculasFromWS => this.peliculas = peliculasFromWS,
            error => console.error(error));
  }

}
