import { CinetecService } from './../../cinetec.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  usuario:string = "";
  ruta:string = "";
  usuarioCliente:boolean = false;

  constructor(private service:CinetecService) { }

  ngOnInit(): void {   
    this.service.tipousuario.subscribe(u => {this.usuario = u});
    this.setRuta();
  }

  setRuta(){
    if (this.usuario == "Cliente"){
      this.ruta = "/cinema";
      this.usuarioCliente = true;
    }
    else if(this.usuario == "Admin"){
      this.ruta = "/empleados";
    }

  }
  

}
