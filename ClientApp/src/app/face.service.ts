import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Face } from './face'; 

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};


@Injectable()
export class FaceService {
  public face: Face;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getData(data: string): void {
    this.httpClient.post<Face>(this.baseUrl + 'api/FaceApi', data, httpOptions).subscribe(result => {
      this.face = result;
    }, error => console.error(error));
  }
}
