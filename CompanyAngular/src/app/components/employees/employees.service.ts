import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as APIs from 'src/app/apis';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private _http : HttpClient) { }

  AddEmployee( data: any) {
    return this._http.post(APIs.AddEmployee,data)
     
  }

  UpdateEmployee( Data:any)
  {
    return this._http.put(APIs.UpdateEmployee,Data)
  
  }

  GetDepartmentEmployees(departmentId:any) {
 
    let queryParams = new HttpParams();
    queryParams = queryParams.append("departmentId",departmentId);
    
    return this._http.get(APIs.GetDepartmentEmployees,{params:queryParams})
  
  }
  GetEmployeeById(employeeId:any) {
 
    let queryParams = new HttpParams();
    queryParams = queryParams.append("employeeId",employeeId);
    
    return this._http.get(APIs.GetEmployeeById,{params:queryParams})
   
  }

  DeleteEmployee(employeeId:any)
  {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("employeeId",employeeId);
    return this._http.delete(APIs.DeleteEmployee,{params:queryParams} )
    .pipe(
      map(res => {
        return res;
      }),
    )
  }
}

