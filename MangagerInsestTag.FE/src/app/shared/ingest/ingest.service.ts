import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ingest } from './ingest.model';

@Injectable({
  providedIn: 'root'
})
export class IngestService {


  constructor(private httpCilent: HttpClient) { }
  //init
  private REST_API_SERVER = 'https://localhost:5001';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }
  private url = this.REST_API_SERVER + '/api/IngestTags';

  public GetAllIngest(): Observable<any> {
    return this.httpCilent.get<any>(this.url, this.httpOptions);
  }

  public PostIngest(ingest: any): Observable<any> {
    return this.httpCilent.post<any>(this.url, ingest, this.httpOptions);
  }

  public PutIngest(ingest: any): Observable<any> {
    return this.httpCilent.put<any>(this.url + "/" + ingest.IngestTagId, ingest, this.httpOptions);
  }
  public GetFilter(filter: any): Observable<any> {
    return this.httpCilent.post<any>(this.url + "/getfilter", filter, this.httpOptions);
  }
  public GetNumberPage(filter: any){
    return this.httpCilent.post<any>(this.url + "/getNumberPage", filter, this.httpOptions);
  }
  public DeleteIngest(ingestId: any): Observable<any> {
    return this.httpCilent.delete<any>(this.url + "/" + ingestId, this.httpOptions);
  }
}
