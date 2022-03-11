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

  public GetAllEmployee(): Observable<any> {
    let url = this.REST_API_SERVER + '/api/Employees';
    return this.httpCilent.get<any>(url, this.httpOptions);
  }

  public GetAllEmployeeInRoomIngest(): Observable<any> {
    let url = this.REST_API_SERVER + '/api/Employees/InRoomIngest';
    return this.httpCilent.get<any>(url, this.httpOptions);
  }
  public GetAllEmployeeReporter(): Observable<any> {
    let url = this.REST_API_SERVER + '/api/Employees/reporter';
    return this.httpCilent.get<any>(url, this.httpOptions);
  }

  public GetAllEmployeeCameraman(): Observable<any> {
    let url = this.REST_API_SERVER + '/api/Employees/cameraman';
    return this.httpCilent.get<any>(url, this.httpOptions);
  }
  public GetEmployeeById(id: number): Observable<any> {
    let url = this.REST_API_SERVER + '/api/Employees/'+id;
    return this.httpCilent.get<any>(url, this.httpOptions);
  }

  // public PostEmployee(employee): Observable<any> {
  //   let url = this.REST_API_SERVER + '/api/Employees';
  //   return this.httpCilent.post<any>(url,{}, this.httpOptions);
  // }

}
