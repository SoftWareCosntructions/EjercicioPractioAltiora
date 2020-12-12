import { Component, OnInit } from '@angular/core';
import { faCircleNotch, faTrash, faEye } from '@fortawesome/free-solid-svg-icons';
import { OrdenService } from '../../servicios/orden.service';

@Component({
  selector: 'app-tabla-ordenes',
  templateUrl: './tabla-ordenes.component.html',
  styleUrls: ['./tabla-ordenes.component.css']
})
export class TablaOrdenesComponent implements OnInit {
  faCircleNotch = faCircleNotch;
  faTrash = faTrash;
  faPen = faEye;
  ordenes: IOrden[];
  cabeceras: string[] = ['IdOrden', 'Nº', 'Fecha', 'Cliente', 'Total'];
  cargando: boolean = false;

  constructor(private ordenesSvc: OrdenService) { }

  ngOnInit(): void {
    this.getOrdenes();
  }

  getOrdenes(): void {
    this.ordenesSvc.obtenerOrdenes()
      .subscribe(orden => {
        this.ordenes = orden;
        this.cargando = true;
      });
  }

}
