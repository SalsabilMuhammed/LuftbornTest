import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Editemployeedto } from 'src/app/models/employees/editemployeedto';
import { EmployeesService } from '../employees/employees.service';
import Swal from 'sweetalert2';
import {Location} from '@angular/common';
@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent {
  public Employee: Editemployeedto = new Editemployeedto();
  public OldEmployee: any;
  constructor(private _employeesService: EmployeesService, private route: ActivatedRoute, private router: Router,private _location: Location) { }

  ngOnInit() {
    var id = Number(this.route.snapshot.paramMap.get('id'));
    this._employeesService.GetEmployeeById(id)
      .subscribe(
        res => {
          this.OldEmployee = res;
          this.Employee.id = this.OldEmployee.id;
          this.Employee.name = this.OldEmployee.name;
          this.Employee.address = this.OldEmployee.address
        }
      );
  }

  EditEmployee() {
    this._employeesService.UpdateEmployee(this.Employee)
      .subscribe(res => {
        Swal.fire('Employee Edited');
      }, (err) => {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong!'
        });
        this.Employee.name = this.OldEmployee.name,
        this.Employee.address = this.OldEmployee.address;
        this.Employee.id = this.OldEmployee.id;

      });
  }
  GoBack()
  {
    this._location.back();
  }
}
