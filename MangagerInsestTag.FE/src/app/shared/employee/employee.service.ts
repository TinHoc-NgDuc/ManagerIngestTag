import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpCilent: HttpClient) { }

  //init
  private REST_API_SERVER = environment.baseUrl;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }
  private url = this.REST_API_SERVER + '/api/Employees/';
  public GetAllEmployee(): Observable<any> {
    return this.httpCilent.get<any>(this.url, this.httpOptions);
  }

  public GetAllEmployeeInRoomIngest(): Observable<any> {
    return this.httpCilent.get<any>(this.url + 'InRoomIngest', this.httpOptions);
  }
  public GetAllEmployeeReporter(): Observable<any> {
    return this.httpCilent.get<any>(this.url + 'reporter', this.httpOptions);
  }

  public GetAllEmployeeCameraman(): Observable<any> {
    return this.httpCilent.get<any>(this.url + 'cameraman', this.httpOptions);
  }
  public GetEmployeeById(id: number): Observable<any> {
    return this.httpCilent.get<any>(this.url + id, this.httpOptions);
  }
  //reporterOrEditor
  public GetAllReporterOrEditor(): Observable<any> {
    return this.httpCilent.get<any>(this.url+'reporterOrEditor', this.httpOptions);
  }
  //checkuser
  public PostCheckUser(employee: any): Observable<any> {
    return this.httpCilent.post<any>(this.url + 'checkuser', employee, this.httpOptions);
  }
}
