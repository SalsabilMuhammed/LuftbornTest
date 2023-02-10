export class Addemployeedto {
 
    name: string;
    address: string;
    departmentId:number;
    constructor(
        name: string ="",
        address: string ="",
        departmentId:number = 0,
    ) {
        this.name = name;
        this.address = address;
        this.departmentId = departmentId;
    }
}
