import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};


@Injectable()
export class RegistrationService {

  constructor(private httpClient:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public registerUser(data: string){
    return this.httpClient.post(this.baseUrl + 'api/RegistrationApi/createPerson', data, httpOptions);
  }

}
