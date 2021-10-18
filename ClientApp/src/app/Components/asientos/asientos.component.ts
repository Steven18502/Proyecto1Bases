import { CinetecService } from 'src/app/cinetec.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-asientos',
  templateUrl: './asientos.component.html',
  styleUrls: ['./asientos.component.css']
})
export class AsientosComponent implements OnInit {

  asientos: Array<Array<number>> = [[0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0]]; 
  asientosAux: Array<Array<number>> = [[0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0]]; 
  pelicula:string = "";
  cinema:string = "";
  sala:string = "";
  cant: number = 0;

  constructor(private service:CinetecService) { }

  ngOnInit(): void {
    this.restringir(70);
    this.service.cinemaAux.subscribe(c => {this.cinema = c});
    this.service.peliculaAux.subscribe(p => {this.pelicula = p});
    this.service.salaAux.subscribe(s => {this.sala = s});
  }

  restringir(porcentaje:number){
    var fraccion:number = porcentaje/100;
    var disponibles:number = Math.round(this.asientos[0].length*fraccion);
    var restringidos:number = this.asientos[0].length - disponibles;
    var cont:number = 0;
    var dif:number = disponibles-restringidos;
    var cant_cont:number = (1 + Math.trunc(disponibles/restringidos))
    for (var i = 0; i<this.asientos.length; i++){
      for(var j = 0; j<this.asientos[0].length; j++){
        if (dif - (cant_cont - 1) < 0){
          cant_cont = dif + 1;
        }
        if (dif <= 0){
          cant_cont = 1;
        }
        if (cont == cant_cont){
          this.asientos[i][j] = 2;
          this.asientosAux[i][j] = 2;
          cont = 0;
          dif = dif - (cant_cont - 1);
        }
        else {
          cont++;
        }
      };
      cont = 0;
      dif = disponibles-restringidos;
      cant_cont = (1 + Math.trunc(disponibles/restringidos));
    };

  };

  seleccionar(x:number,y:number){ 
    if (this.asientosAux[x][y] == 0){
      this.asientosAux[x][y] = 1;
      this.cant++
    }
    else if (this.asientosAux[x][y] == 1){
      this.asientosAux[x][y] = 0;
      this.cant--
    }
  };

  finalizar(){
    this.asientos = this.asientosAux;
  };

}
