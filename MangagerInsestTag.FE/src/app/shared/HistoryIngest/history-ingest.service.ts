import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class HistoryIngestService {
  constructor(private httpCilent: HttpClient) { }
  //init
  private REST_API_SERVER = environment.baseUrl;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }
  private url = this.REST_API_SERVER + '/api/HistoryIngests';

  public PostHistoryIngest(HistoryIngest: any): Observable<any> {
    return this.httpCilent.post<any>(this.url, HistoryIngest, this.httpOptions);
  }
}
