import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeesService } from './employees.service';
import Swal from 'sweetalert2';
import {Location} from '@angular/common';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent {
  Employees : any;
  constructor(private _employeesService : EmployeesService,private route: ActivatedRoute,private router: Router,private _location: Location){  }
  ngOnInit()
  {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this._employeesService.GetDepartmentEmployees(id)
    .subscribe(
      res => this.Employees = res);
  }
  DeleteEmployee(id:number){
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        this._employeesService.DeleteEmployee(id).subscribe(res => 
          {
            Swal.fire(
              'Deleted!',
              'Your file has been deleted.',
              'success'
            )
            this.Employees = this.Employees.filter((x:any)=>x.id !== id)
          },(err)=>{
            console.log("error")
          })
      }
    })
    
  }
  AddEmployee(){
    const id = Number(this.route.snapshot.paramMap.get('id'));
    var Path = "addEmployee/" + id.toString()
    this.router.navigate([Path])
  }
  EditEmployee(id:number){

    var Path = "editEmployee/" + id.toString()
    this.router.navigate([Path])
  }
  GoBack()
  {
    this._location.back();
  }
}
