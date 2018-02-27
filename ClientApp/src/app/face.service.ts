import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Face } from './face'; 

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable()
export class FaceService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getData(data: string) {
    return this.httpClient.post<Face>(this.baseUrl + 'api/FaceApi', data, httpOptions);
  }
}
