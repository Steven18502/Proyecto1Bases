import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-asientos',
  templateUrl: './asientos.component.html',
  styleUrls: ['./asientos.component.css']
})
export class AsientosComponent implements OnInit {

  asientos:boolean[] = [true,false,false,true,false,false,false,false,false,true,false,false,true,false,false,true];
  filas:string[] = ["1","2","3","4","5"]
  constructor() { }

  ngOnInit(): void {
  }

}
