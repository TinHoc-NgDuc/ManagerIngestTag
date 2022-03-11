import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class IngestDetailService {
  constructor(private httpCilent: HttpClient) { }
  //init
  private REST_API_SERVER = environment.baseUrl;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }
  private url = this.REST_API_SERVER + '/api/IngestDetails/';

  public PostIngestDetail(ticketIngest: any): Observable<any> {
    return this.httpCilent.post<any>(this.url, ticketIngest, this.httpOptions);
  }
}
