import { AsientosComponent } from './Components/asientos/asientos.component';
import { ProyeccionComponent } from './Components/proyeccion/proyeccion.component';
import { CinemaComponent } from './Components/cinema/cinema.component';
import { RegisterComponent } from './Components/register/register.component';
import { SalasComponent } from './Components/salas/salas.component';
import { SucursalesComponent } from './Components/sucursales/sucursales.component';
import { PeliculasComponent } from './Components/peliculas/peliculas.component';
import { ClientesComponent } from './Components/clientes/clientes.component';
import { EmpleadosComponent } from './Components/empleados/empleados.component';
import { LoginComponent } from './Components/login/login.component';
import { HomepageComponent } from './Components/homepage/homepage.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PeliculaComponent } from './Components/pelicula/pelicula.component';

const routes: Routes = [
  {
    path: "",
    component: HomepageComponent
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "empleados",
    component: EmpleadosComponent
  },
  {
    path: "clientes",
    component: ClientesComponent
  },
  {
    path: "peliculas",
    component: PeliculasComponent
  },
  {
    path: "sucursales",
    component: SucursalesComponent
  },
  {
    path: "salas",
    component: SalasComponent
  },
  {
    path: "register",
    component: RegisterComponent
  },  
  {
    path: "cinema",
    component: CinemaComponent
  },  
  {
    path: "pelicula",
    component: PeliculaComponent
  },  
  {
    path: "proyeccion",
    component: ProyeccionComponent
  },
  {
    path: "asientos",
    component: AsientosComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

