import { Component, EventEmitter, OnInit, Input, Output } from '@angular/core';
import { Employee } from 'src/app/shared/employee/employee.model';
import { EmployeeService } from 'src/app/shared/employee/employee.service';
import { Ingest } from 'src/app/shared/ingest/ingest.model';
import { IngestService } from 'src/app/shared/ingest/ingest.service';
import { Position } from 'src/app/shared/position/position.model';
import { PositionService } from 'src/app/shared/position/position.service';

@Component({
  selector: 'app-ingest-detail',
  templateUrl: './ingest-detail.component.html',
  styleUrls: ['./ingest-detail.component.css']
})
export class IngestDetailComponent implements OnInit {
  @Input() isShow: boolean = false;
  @Input() isAdd: boolean = false;
  @Input() isEdit: boolean = false;
  @Output() changeShow = new EventEmitter();

  constructor(private employeeService: EmployeeService, private positionService: PositionService, private ingestService: IngestService) { }
  employeeSrc: Employee[] = [];
  positionSrc: Position[] = [];
  employeeSelect: Employee = new Employee();
  IngestCreate: Ingest = new Ingest();

  public ngOnInit(): void {
    this.employeeService.GetAllEmployee().subscribe(s => {
      s.forEach((element: any) => {
        this.employeeSrc.push({
          EmployeeId: element.employeeId,
          Name: element.name,
          PositionId: element.positionId,
          ProductionUnitId: element.productionUnitId,
        });
      });
    });
    this.positionService.GetAllPositions().subscribe(s => {
      s.forEach((element: any) => {
        this.positionSrc.push({
          PositionId: element.positionId,
          Name: element.name
        });
      });
    });
  }

  Close() {
    this.changeShow.emit();
  }
  Save() {
    this.IngestCreate.PositionId = this.employeeSelect.PositionId;
    this.IngestCreate.CardholderName = this.employeeSrc.find(element => element.EmployeeId == this.employeeSelect.EmployeeId)?.Name;
    this.ingestService.PostIngest(this.IngestCreate).subscribe(s => {
      this.ClearData();
      this.Close();
    });
  }
  ClearData() {
    this.employeeSelect = new Employee();
    this.IngestCreate = new Ingest();
  }
  Edit(){
    
  }
}
