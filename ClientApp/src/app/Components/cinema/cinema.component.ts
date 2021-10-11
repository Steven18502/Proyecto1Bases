import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cinema',
  templateUrl: './cinema.component.html',
  styleUrls: ['./cinema.component.css']
})
export class CinemaComponent implements OnInit {

  cinemas: string[] = ["San Pedro","Occidente","Plaza"];
  cinema_actual: string = "";

  constructor() { }

  ngOnInit(): void {

  }

  seleccionar(cinema:string){
    this.cinema_actual = cinema
  }

}
