import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../servicios/cliente.service';
import { FormControl, FormGroup, Validators,  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Icon } from '@fortawesome/fontawesome-svg-core';

@Component({
  selector: 'app-editar-cliente',
  templateUrl: './editar-cliente.component.html',
  styleUrls: ['./editar-cliente.component.css']
})
export class EditarClienteComponent implements OnInit {
  titulo: string = "";
  idCliente: string = "";
  clienteForm: FormGroup;

  constructor(private clienteSvc: ClienteService, private activateRoute: ActivatedRoute, private router: Router) {
    this.clienteForm = new FormGroup({
      'idCliente': new FormControl("0"), 
      'dniCliente': new FormControl("", [Validators.required, Validators.maxLength(20)]), 
      'nombre': new FormControl("", [Validators.required, Validators.maxLength(50)]), 
      'apellido': new FormControl("", [Validators.required, Validators.maxLength(50)]), 
    });

    this.activateRoute.params.subscribe(parametro => {
      this.idCliente = parametro['Id'];
      if (this.idCliente == 'nuevo')
        this.titulo = 'Nuevo cliente'
      else
        this.titulo = "Actualizar cliente"
    });
  }

  ngOnInit() {
    if (this.idCliente != 'nuevo') {
      this.clienteSvc.obtenerCliente(this.idCliente).subscribe(cliente => {
        this.clienteForm.controls['idCliente'].setValue(cliente.idCliente);
        this.clienteForm.controls['dniCliente'].setValue(cliente.dniCliente);
        this.clienteForm.controls['nombre'].setValue(cliente.nombre);
        this.clienteForm.controls['apellido'].setValue(cliente.apellido);
      });
    }
  }

  guardarCliente(): void {
    if (this.clienteForm.valid) {
      let cliente: ICliente;
      cliente = this.clienteForm.value as ICliente;
      if (this.idCliente == 'nuevo') {
        this.clienteSvc.agregarCliente(cliente).subscribe(data => this.router.navigate(['/clientes']));
      }
      else {
        this.clienteSvc.actualizarCliente(cliente).subscribe(data => this.router.navigate(['/clientes']));
      }
    }
  }

}
