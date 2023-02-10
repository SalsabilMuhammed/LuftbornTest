import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { DepartmentsComponent } from './components/departments/departments.component';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  {path: '', redirectTo:'home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: 'departments', component: DepartmentsComponent},
  {path: 'department/:id', component: EmployeesComponent},
  {path: 'addEmployee/:id', component: AddEmployeeComponent},
  {path: 'editEmployee/:id', component: EditEmployeeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
