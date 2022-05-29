import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { UsersList } from '../models/UserList';
import { UserDetails } from '../models/UserDetails';

@Injectable({
  providedIn: 'root'
})
export class RestApiService {
  apiUrl = "https://localhost:7107/";

  constructor(private http: HttpClient) { }

  getUsersList(): Observable<UsersList> {
    return this.http.get<UsersList>(this.apiUrl + 'users')
      .pipe(retry(1), catchError(this.handleError));   
  }

  getUserDetails(id: number): Observable<UserDetails> {
    return this.http.get<UserDetails>(this.apiUrl + 'users/' + id.toString())
      .pipe(retry(1), catchError(this.handleError));
  }

  handleError(error: any) {
    let message = 'ERROR';
    return throwError(() => { return message });
  }
}
