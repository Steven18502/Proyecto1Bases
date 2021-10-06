import { Component, OnInit, Input } from '@angular/core';
import { HomepageComponent } from '../homepage/homepage.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  @Input() ruta:string="/cinema";

  constructor() { }

  ngOnInit(): void {   
  console.log(this.ruta)
  }
  
  reciveRuta(ruta:string){
    console.log("ruta cambiada")
    this.ruta = ruta
  }

}
