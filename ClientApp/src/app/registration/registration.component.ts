import { Component, OnInit } from '@angular/core';
import {PersonGroupService} from '../person-group.service';
import {DataApiModel} from "../data-api-model";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  str: string;

  constructor(private personGroupService: PersonGroupService) { }

  ngOnInit() {
  }

  public sendValue() {
    let model = new DataApiModel();
    model.data = this.str.toLowerCase();

    this.personGroupService.createGroup(JSON.stringify(model)).subscribe(result => {
      console.log('Result', result);
    }, error => console.error(error));
  }

}
