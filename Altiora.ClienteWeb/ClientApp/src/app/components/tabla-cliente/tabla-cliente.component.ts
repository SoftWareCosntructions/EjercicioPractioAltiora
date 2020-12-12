import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../servicios/cliente.service';
import { faCircleNotch, faTrash, faPen } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-tabla-cliente',
  templateUrl: './tabla-cliente.component.html',
  styleUrls: ['./tabla-cliente.component.css']
})
export class TablaClienteComponent implements OnInit {
  clientes: ICliente[];
  cabeceras: string[] = ['IdCliente', 'DniCliente', 'Nombre', 'Apellido'];
  faCircleNotch = faCircleNotch;
  faPen = faPen;
  faTrash = faTrash;
  cargando: boolean = false;
  constructor(private clienteSvc: ClienteService) { }

  ngOnInit(): void {
    this.getClientes();
  }

  getClientes(): void {
    this.clienteSvc.obtenerClientes()
      .subscribe(clientes => {
        this.clientes = clientes;
        this.cargando = true;
      });
  }

}
