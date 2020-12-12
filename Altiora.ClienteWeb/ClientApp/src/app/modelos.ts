interface ICliente {
  idCliente: number;
  dniCliente: string;
  nombre: string;
  apellido: string;
  ordenes: IOrden[];
}

interface IOrden {
  idOrden: number;
  fechaOrden: Date;
  idCliente: number;
  cliente: ICliente;
  numeroOrden: string;
  subtotal: number;
  montoIva: number;
  montoTotal: number;
  detallesOrden: IDetalleOrden[];
}

interface IDetalleOrden {
  idDetalleOrden: number;
  idOrden: number;
  orden: IOrden;
  idArticulo: number;
  articulo: IArticulo;
  cantidad: number;
  precioTotal: number;
}

interface IArticulo{
  idArticulo: number;
  codigoArticulo: string;
  nombreArticulo: string;
  precioUnitarioArticulo: number;
  detallesOrden: IDetalleOrden[]
}
