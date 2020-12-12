import { Component, OnInit, Input } from '@angular/core';
import { OrdenService } from '../../servicios/orden.service';

@Component({
  selector: 'app-editar-orden',
  templateUrl: './editar-orden.component.html',
  styleUrls: ['./editar-orden.component.css']
})
export class EditarOrdenComponent implements OnInit {
  @Input() IdOrden = 1;
  orden: IOrden = {} as IOrden;

  constructor(private ordenSvc: OrdenService) { }

  ngOnInit() {
    if (this.IdOrden >= 1)
      this.ordenSvc.obtenerOrden(this.IdOrden).subscribe(orden => {
        this.orden = orden;
      });
  }
}
