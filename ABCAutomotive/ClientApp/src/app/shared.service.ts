import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:5000/api";

  constructor(private http: HttpClient) { }

  getCarList(val: any): Observable < any[] > {
      return this.http.post<any>(this.APIUrl + '/car',val);
    }
  
}
