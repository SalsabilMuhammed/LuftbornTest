import { Component } from '@angular/core';
import { DepartmentsService } from './departments.service';
import {Location} from '@angular/common';
@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentsComponent {

  Departments : any;
  constructor(private _departmentservice : DepartmentsService,private _location: Location){  }
  ngOnInit()
  {
    this._departmentservice.GetDepartments().subscribe(res => 
      {
        this.Departments = res;
      })
  }
  GoBack()
  {
    this._location.back();
  }
}
