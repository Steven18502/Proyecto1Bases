import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { CinetecService } from 'src/app/cinetec.service';


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  constructor(private service:CinetecService) { }
  usuario:string = "";
  ngOnInit(): void {
  }
  
  setUserType(type:number){
    if (type == 1){
      this.usuario = "Admin"
      this.service.setUsuario(this.usuario)
    }
    if (type == 0){
      this.usuario = "Cliente"
      this.service.setUsuario(this.usuario)
    }
  }
}

