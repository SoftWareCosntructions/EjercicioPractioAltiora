import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  urlBase: string = '';
  clientesUrl = 'api/clientes'

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.urlBase = baseUrl;
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  obtenerClientes(): Observable<ICliente[]> {
    return this.http.get<ICliente[]>(this.clientesUrl)
      .pipe(catchError(this.handleError<ICliente[]>('ObtenerClientes', [])));
  }

  obtenerCliente(id: string): Observable<ICliente> {
    return this.http.get<ICliente>(this.clientesUrl + '/' + id)
      .pipe(catchError(this.handleError<ICliente>('ObtenerClientes')));
  }

  agregarCliente(cliente: any): Observable<any> {
    return this.http.post(this.clientesUrl, cliente, this.httpOptions)
      .pipe(catchError(this.handleError<ICliente>('agregarCliente')));
  }

  actualizarCliente(cliente: ICliente): Observable<ICliente> {
    return this.http.put<ICliente>(this.clientesUrl, cliente, this.httpOptions)
      .pipe(catchError(this.handleError<ICliente>('actualizarCliente')));
  }

  eliminarCliente(id: string): Observable<{}> {
    return this.http.delete(`${this.clientesUrl}/${id}`, this.httpOptions)
      .pipe(catchError(this.handleError('eliminarCliente')));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); 
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
