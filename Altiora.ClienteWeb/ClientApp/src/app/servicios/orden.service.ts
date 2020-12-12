import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrdenService {
  urlBase: string = '';
  ordenesUrl = 'api/ordenes'

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;
  }

  obtenerOrdenes(): Observable<IOrden[]> {
    return this.http.get<IOrden[]>(this.ordenesUrl)
      .pipe(
        tap(),
        catchError(this.handleError<IOrden[]>('obtenerOrdenes', []))
      );
  }

  obtenerOrden(Id: number): Observable<IOrden> {
    return this.http.get<IOrden>(this.ordenesUrl + '/' + Id)
      .pipe(
        tap(),
        catchError(this.handleError<IOrden>('obtenerOrden'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
