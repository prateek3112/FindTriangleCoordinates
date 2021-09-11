import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class DataService {

  myAppUrl: string;
  myApiUrl = "http://localhost:61106/getArea?row=c&column=5";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })

  }
  constructor(private http: HttpClient) { 

  }

  async getdata(request){
    const row = request.RowSelected;
    const col = request.ColSelected;
   const data = await this.http.get(`http://localhost:61106/getCordinates?row=${row}&column=${col}`).toPromise();
   
   return data;
  }

  async getLocation(request){
    const requestObject = request;
   const data = await this.http.post(`http://localhost:61106/getLocation`,requestObject).toPromise();
   
   return data;
  }
}
