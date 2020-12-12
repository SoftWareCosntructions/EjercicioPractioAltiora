import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-tabla-detalle-orden',
  templateUrl: './tabla-detalle-orden.component.html',
  styleUrls: ['./tabla-detalle-orden.component.css']
})
export class TablaDetalleOrdenComponent implements OnInit {
  @Input() detalle: any;

  constructor() { }

  ngOnInit() {
    console.log(this.detalle);
  }

}
