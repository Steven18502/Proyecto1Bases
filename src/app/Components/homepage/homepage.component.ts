import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { LoginComponent } from '../login/login.component';


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  constructor() { }
  @Output() sendRuta = new EventEmitter<string>();
  setRuta:string = "/empleados";
  ngOnInit(): void {
  }
  
  setUserType(type:number){
    if (type == 0){
      this.sendRuta.emit("/salas")
    }
    if (type == 1){
      this.sendRuta.emit("/empleados")
    }
  }
}

