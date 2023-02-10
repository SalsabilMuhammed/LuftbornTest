import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Addemployeedto} from 'src/app/models/employees/addemployeedto';
import { EmployeesService } from '../employees/employees.service';
import Swal from 'sweetalert2';
import {Location} from '@angular/common';
@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  public Employee:Addemployeedto = new Addemployeedto();
 
  constructor(private _employeesService : EmployeesService,private route: ActivatedRoute,private router: Router,private _location: Location){  }

  AddEmployee()
  {
    this.Employee.departmentId = Number(this.route.snapshot.paramMap.get('id'));
    this._employeesService.AddEmployee(this.Employee)
    .subscribe(res => 
      {
        this.Employee = new Addemployeedto();
        Swal.fire('Employee Added');

      },(err)=>{
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong!'
        })
      });
  }
  
  GoBack()
  {
    this._location.back();
  }
}
