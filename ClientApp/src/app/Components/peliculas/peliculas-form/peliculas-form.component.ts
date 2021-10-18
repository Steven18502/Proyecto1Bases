import { PeliculasService } from './../peliculas.service';
import { IPelicula } from './../pelicula';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-peliculas-form',
  templateUrl: './peliculas-form.component.html',
  styleUrls: ['./peliculas-form.component.css']
})
export class PeliculasFormComponent implements OnInit {

  // Inyectar el Form Builder, que permite construir el modelo que representa los campos del formulario
  constructor(private fb: FormBuilder,
    private peliculasService : PeliculasService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {}

    // variable que dice si se encuentra en modo edicion o no
    modoEdicion: boolean = false;
    peliculaId: string;

    // Modelo del formulario
    formGroup = new FormGroup({
      pnombre_original: new FormControl('', [Validators.required]),
      pnombre: new FormControl('', [Validators.required]),
      pduracion: new FormControl('', [Validators.required]),
      director: new FormControl('', [Validators.required]),
      clasificacion: new FormControl('', [Validators.required]),
      protagonistas: new FormControl('', [Validators.required]),
      pimagen: new FormControl('', [Validators.required])
    });

  ngOnInit() {
    
  this.activatedRoute.params.subscribe(params => {
    if (params["pnombre_original"] == undefined) {
      return; 
    }

      this.modoEdicion = true;

      //this.peliculaId = params["pnombre_original"];
      this.peliculaId = "pnombre_original";

      this.peliculasService.getPelicula(this.peliculaId)
        .subscribe(pelicula => this.cargarFormulario(pelicula),
        error => this.router.navigate(["/peliculas"]));
    });
  }

  get f(){

    return this.formGroup.controls;

  }

  cargarFormulario(pelicula: IPelicula) {
    this.formGroup.setValue({
      pnombre_original: pelicula.pnombre_original,
      pnombre: pelicula.pnombre,
      pduracion: pelicula.pduracion,
      director: pelicula.director,
      clasificacion: pelicula.clasificacion,
      protagonistas: pelicula.protagonistas,
      pimagen: pelicula.pimagen
    });
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
