import { ClientesService } from '../../clientes/clientes.service';
import { ICliente } from '../../clientes/cliente';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-clientes-form',
  templateUrl: './clientes-form.component.html',
  styleUrls: ['./clientes-form.component.css']
})
export class ClientesFormComponent implements OnInit{

  // Injectar el Form Builder, que permite construir el modelo que representa los campos del formulario
  constructor(private fb: FormBuilder,
    private clientesService : ClientesService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {}

    // variable que dice si se encuentra en modo edicion o no
    modoEdicion: boolean = false;
    clienteId: string;

  // Modelo del formulario
  formGroup = new FormGroup({
    ccedula: new FormControl('', [Validators.required]),
    cusuario: new FormControl('', [Validators.required]),
    ccontrasenia: new FormControl('', [Validators.required]),
    cnombre_completo: new FormControl('', [Validators.required]),
    cedad: new FormControl('', [Validators.required]),
    cfecha_nacimiento: new FormControl('', [Validators.required]),
    ctelefono: new FormControl('', [Validators.required])
  });

  get f(){

    return this.formGroup.controls;

  }

  ngOnInit() {

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;

      /*
      this.personaId = params["id"];

      this.personasService.getPersona(this.personaId.toString())
        .subscribe(persona => this.cargarFormulario(persona),
          error => this.router.navigate(["/personas"]));*/

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
    // Se crea un objeto de tipo ICliente a partir del valor del formulario
    let cliente : ICliente = Object.assign({}, this.formGroup.value);
    console.table(cliente);


    this.clientesService.createCliente(cliente)
      .subscribe(cliente => this.onSaveSuccess(),
              error => console.error(error));  
  }

  // Metodo que retorna al usuario a la ventana de visualizacion de clientes una vez se agrega un componente nuevo
  onSaveSuccess() {
    this.router.navigate(["/clientes"]);
  }

}
