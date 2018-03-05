import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { PersonGroupApiModel } from "./person-group-api-model";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable()
export class PersonGroupService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public createGroup(data: string) {
    return this.httpClient.put<string>(this.baseUrl + 'api/RegistrationApi/Create', data, httpOptions);
  }

  public getGroupList() {
    return this.httpClient.get<PersonGroupApiModel[]>(this.baseUrl + 'api/RegistrationApi/List');
  }

}
