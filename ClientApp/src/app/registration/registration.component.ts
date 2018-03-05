import { Component, OnInit } from '@angular/core';
import {PersonGroupService} from '../person-group.service';
import {DataApiModel} from "../data-api-model";
import {PersonGroupApiModel} from "../person-group-api-model";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  groupName: string;
  userName: string;
  public groups: PersonGroupApiModel[];

  constructor(private personGroupService: PersonGroupService) { }

  ngOnInit() {
    this.getGroupList();
  }

  public registerGroup() {
    let model = new DataApiModel();
    model.data = this.groupName.toLowerCase();

    this.personGroupService.createGroup(JSON.stringify(model)).subscribe(result => {
      console.log('Result', result);

    }, error => console.error(error));
  }

  private getGroupList() {
    this.personGroupService.getGroupList().subscribe( result => {
      console.log('Result', result);
      this.groups = result;
    }, error => console.error(error));
  }
}
