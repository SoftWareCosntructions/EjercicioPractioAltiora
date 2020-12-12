import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TablaClienteComponent } from './components/tabla-cliente/tabla-cliente.component';
import { TablaOrdenesComponent } from './components/tabla-ordenes/tabla-ordenes.component';
import { TablaArticulosComponent } from './components/tabla-articulos/tabla-articulos.component';

import { EditarOrdenComponent } from './components/editar-orden/editar-orden.component';

import { ClientesComponent } from './clientes/clientes.component';
import { OrdenesComponent } from './ordenes/ordenes.component';
import { ArticulosComponent } from './articulos/articulos.component';

import { ClienteService } from './servicios/cliente.service';
import { OrdenService } from './servicios/orden.service';
import { ArticulosService } from './servicios/articulos.service';
import { EditarClienteComponent } from './components/editar-cliente/editar-cliente.component';
import { EliminarClienteComponent } from './components/eliminar-cliente/eliminar-cliente.component';
import { TablaDetalleOrdenComponent } from './components/tabla-detalle-orden/tabla-detalle-orden.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TablaClienteComponent,
    ClientesComponent,
    OrdenesComponent,
    ArticulosComponent,
    TablaOrdenesComponent,
    TablaArticulosComponent,
    EditarOrdenComponent,
    EditarClienteComponent,
    EliminarClienteComponent,
    TablaDetalleOrdenComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'clientes', component: ClientesComponent },
      { path: 'ordenes', component: OrdenesComponent },
      { path: 'articulos', component: ArticulosComponent },
      { path: 'editar-orden', component: EditarOrdenComponent },
      { path: 'editar-orden/:IdOrden', component: EditarOrdenComponent },
      { path: 'editar-cliente/:Id', component: EditarClienteComponent },
      { path: 'eliminar-cliente/:Id', component: EliminarClienteComponent },
    ])
  ],
  providers: [
    ClienteService,
    OrdenService,
    ArticulosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
