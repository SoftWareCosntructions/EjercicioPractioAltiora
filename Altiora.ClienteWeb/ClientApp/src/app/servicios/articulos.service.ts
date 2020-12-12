import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArticulosService {
  urlBase: string = '';
  articulosUrl = 'api/articulos'

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.urlBase = baseUrl;
  }

  obtenerArticulos(): Observable<IArticulo[]> {
    return this.http.get<IArticulo[]>(this.articulosUrl)
      .pipe(
        tap(),
        catchError(this.handleError<IArticulo[]>('obtenerArticulos', []))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
