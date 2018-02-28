import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PersonDescription } from './person-description';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable()
export class FaceService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getData(data: string) {
    return this.httpClient.post<PersonDescription>(this.baseUrl + 'api/FaceApi', data, httpOptions);
  }
}
