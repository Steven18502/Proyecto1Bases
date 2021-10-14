import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-clientinfo',
  templateUrl: './clientinfo.component.html',
  styleUrls: ['./clientinfo.component.css']
})
export class ClientinfoComponent implements OnInit {

  nombre:string = "Pedro"
  cedula:string = "888888888"
  telefono:string = "55556666"
  fecha:string = "14/08/2001"

  constructor() { }


  ngOnInit(): void {
  }

}
