import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ProgramShowService {
  constructor(private httpCilent: HttpClient) { }
  //init
  private REST_API_SERVER = environment.baseUrl;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }
  private url = this.REST_API_SERVER + '/api/ProgramShows';

  public GetAllProgramShow(): Observable<any> {
    return this.httpCilent.get<any>(this.url, this.httpOptions);
  }
}
