import { Component, OnInit } from '@angular/core';
import { ArticulosService } from '../../servicios/articulos.service';
import { faCircleNotch } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-tabla-articulos',
  templateUrl: './tabla-articulos.component.html',
  styleUrls: ['./tabla-articulos.component.css']
})
export class TablaArticulosComponent implements OnInit {
  articulos: IArticulo[];
  cabeceras: string[] = ['IdArticulo', 'CodigoArticulo', 'Nombre', 'P. Unitario'];
  faCircleNotch = faCircleNotch;
  cargando: boolean = false;

  constructor(private articuloSvc: ArticulosService) { }

  ngOnInit(): void {
    this.getOrdenes();
  }

  getOrdenes(): void {
    this.articuloSvc.obtenerArticulos()
      .subscribe(articulos => {
        this.articulos = articulos;
        this.cargando = true;
      });
  }
}
