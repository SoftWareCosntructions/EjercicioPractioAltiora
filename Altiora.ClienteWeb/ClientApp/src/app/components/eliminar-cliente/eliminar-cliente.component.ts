import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../../servicios/cliente.service';

@Component({
  selector: 'app-eliminar-cliente',
  templateUrl: './eliminar-cliente.component.html',
  styleUrls: ['./eliminar-cliente.component.css']
})
export class EliminarClienteComponent implements OnInit {
  idCliente: string = "";
  cliente: ICliente;

  constructor(private clienteSvc: ClienteService, private activateRoute: ActivatedRoute, private router: Router) {
    this.activateRoute.params.subscribe(parametro => this.idCliente = parametro['Id']);
  }

  ngOnInit(): void {
    this.clienteSvc.obtenerCliente(this.idCliente).subscribe(cliente => this.cliente = cliente);
  }

  eliminar(): void {
    this.clienteSvc.eliminarCliente(this.cliente.idCliente.toString()).subscribe(data => this.router.navigate(['/clientes']));
  }
}
