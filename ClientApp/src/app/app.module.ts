import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomepageComponent } from './Components/homepage/homepage.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { HeaderComponent } from './Components/header/header.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { EmpleadosComponent } from './Components/empleados/empleados.component';
import { ClientesComponent } from './Components/clientes/clientes.component';
import { PeliculasComponent } from './Components/peliculas/peliculas.component';
import { SucursalesComponent } from './Components/sucursales/sucursales.component';
import { SalasComponent } from './Components/salas/salas.component';
import { CinemaComponent } from './Components/cinema/cinema.component';
import { BreadcrumbComponent } from './Components/breadcrumb/breadcrumb.component';
import { PeliculaComponent } from './Components/pelicula/pelicula.component';
import { ProyeccionComponent } from './Components/proyeccion/proyeccion.component';
import { AsientosComponent } from './Components/asientos/asientos.component';
import { PeliculasService } from './Components/peliculas/peliculas.service';
import { PeliculasFormComponent } from './Components/peliculas/peliculas-form/peliculas-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    NavbarComponent,
    HeaderComponent,
    LoginComponent,
    RegisterComponent,
    EmpleadosComponent,
    ClientesComponent,
    PeliculasComponent,
    SucursalesComponent,
    SalasComponent,
    CinemaComponent,
    BreadcrumbComponent,
    PeliculaComponent,
    ProyeccionComponent,
    AsientosComponent,
    PeliculasFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [PeliculasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
