import { PeliculasService } from './../peliculas.service';
import { IPelicula } from './../pelicula';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-peliculas-form',
  templateUrl: './peliculas-form.component.html',
  styleUrls: ['./peliculas-form.component.css']
})
export class PeliculasFormComponent  {

  // Injectar el Form Builder, que permite construir el modelo que representa los campos del formulario
  constructor(private fb: FormBuilder,
    private peliculasService : PeliculasService,
    private router: Router) { }

  // Modelo del formulario
  formGroup = new FormGroup({
    pnombre_original: new FormControl('', [Validators.required]),
    pnombre: new FormControl('', [Validators.required]),
    pduracion: new FormControl('', [Validators.required]),
    director: new FormControl('', [Validators.required]),
    clasificacion: new FormControl('', [Validators.required]),
    protagonistas: new FormControl('', [Validators.required])
  });

  get f(){

    return this.formGroup.controls;

  }


  /*
  ngOnInit(): void {
    this.formGroup = this.fb.group({
      pnombre_original: '',
      pnombre: '',
      pduracion: '',
      director: '',
      clasificacion: '',
      protagonistas: ''
    });
  }
  */

  save() {
    // Se crea un objeto de tipo IPelicula a partir del valor del formulario
    let pelicula : IPelicula = Object.assign({}, this.formGroup.value);
    console.table(pelicula);


    this.peliculasService.createPelicula(pelicula)
      .subscribe(pelicula => this.onSaveSuccess(),
              error => console.error(error));  
  }

  // Metodo que retorna al usuario a la ventana de visualizacion de peliculas una vez se agrega un componente nuevo
  onSaveSuccess() {
    this.router.navigate(["/peliculas"]);
  }

}
