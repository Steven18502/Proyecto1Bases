import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CinetecService {

  // Variable usuario que almacena el tipo de usuario 
  // Variable tipousuario de tipo Behaivorsubject para manejar la variable usuario con la comunicacion del service   
  usuario:string = "";
  tipousuario: BehaviorSubject<string> = new BehaviorSubject(this.usuario);

  // Variable pelicula que almacena la pelicula seleccionada 
  // Variable pelicualAux de tipo Behaivorsubject para manejar la variable pelicula con la comunicacion del service   
  pelicula:string = "";
  peliculaAux: BehaviorSubject<string> = new BehaviorSubject(this.pelicula);

  // Variable cinema que almacena la surcusal seleccionada 
  // Variable pelicualAux de tipo Behaivorsubject para manejar la variable cinema con la comunicacion del service   
  cinema:string = "";
  cinemaAux: BehaviorSubject<string> = new BehaviorSubject(this.cinema);

  // Variable cinema que almacena la sala seleccionada 
  // Variable pelicualAux de tipo Behaivorsubject para manejar la variable sala con la comunicacion del service   
  sala:string = "";
  salaAux: BehaviorSubject<string> = new BehaviorSubject(this.sala);


  constructor() { }

  setUsuario(usuario:string){
    this.usuario = usuario;
    this.tipousuario.next(this.usuario);
  }
  setPelicula(pelicula:string){
    this.pelicula = pelicula;
    this.peliculaAux.next(this.pelicula);
  }
  setCinema(cinema:string){
    this.cinema = cinema;
    this.cinemaAux.next(this.cinema);
  }
  setSala(sala:string){
    this.sala = sala;
    this.salaAux.next(this.sala)

  }

}
