import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as APIs from 'src/app/apis';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  constructor(private _http : HttpClient) { }

  AddDepartment( data: any) {
    return this._http.post(APIs.AddDepartment,data)
    
  }

  UpdateDepartment( Data:any)
  {
    return this._http.put(APIs.UpdateDepartment,Data)
  
  }

  GetDepartments() {
 
    return this._http.get(APIs.GetDepartments)
  }

  GetDepartmentById(Id:any) {
 
    return this._http.get(APIs.GetDepartmentEmployees, {params:Id})
   
  }


  DeleteDepartment(Id:any)
  {
    return this._http.delete(APIs.DeleteDepartment,{params:Id} )
    .pipe(
      map(res => {
        return res;
      }),
    )
  }


}
