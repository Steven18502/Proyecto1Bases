import { CinetecService } from 'src/app/cinetec.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-exitpage',
  templateUrl: './exitpage.component.html',
  styleUrls: ['./exitpage.component.css']
})
export class ExitpageComponent implements OnInit {

  asientos:boolean[] = [true,false,false,true,false,false,false,false,false,true,false,false,true,false,false,true];
  filas:string[] = ["1","2","3","4","5"];
  pelicula:string = "";
  cinema:string = "";
  sala:string = "";

  constructor(private service:CinetecService) { }

  ngOnInit(): void {
    this.service.cinemaAux.subscribe(c => {this.cinema = c});
    console.log(this.cinema);
    this.service.peliculaAux.subscribe(p => {this.pelicula = p});
    console.log(this.pelicula);
    this.service.salaAux.subscribe(s => {this.sala = s});
    console.log(this.sala);
  }

}
