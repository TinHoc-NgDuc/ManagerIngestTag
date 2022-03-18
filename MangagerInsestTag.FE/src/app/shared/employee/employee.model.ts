export class Employee {
    EmployeeId: string = '';
    Name?: string = '';
    ProductionUnitId: string = '';
    PositionId: string = '';
    UserName: string = '';
    Password: string = '';
}
export class EmployeeFilte extends Employee{
    IsShow : boolean = false;
}