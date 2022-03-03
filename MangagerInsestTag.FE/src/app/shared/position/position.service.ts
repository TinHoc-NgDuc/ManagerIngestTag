import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  constructor(private httpCilent: HttpClient) { }

  //init
  private REST_API_SERVER = 'https://localhost:5001';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }

  public GetAllPositions(): Observable<any> {
    let url = this.REST_API_SERVER + '/api/Positions';
    return this.httpCilent.get<any>(url, this.httpOptions);
  }

}
