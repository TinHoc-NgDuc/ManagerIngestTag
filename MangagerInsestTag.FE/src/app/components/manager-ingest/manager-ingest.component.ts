import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/shared/employee/employee.model';
import { EmployeeService } from 'src/app/shared/employee/employee.service';
import { Ingest } from 'src/app/shared/ingest/ingest.model';
import { IngestService } from 'src/app/shared/ingest/ingest.service';
import { Position } from 'src/app/shared/position/position.model';
import { PositionService } from 'src/app/shared/position/position.service';

@Component({
  selector: 'app-manager-ingest',
  templateUrl: './manager-ingest.component.html',
  styleUrls: ['./manager-ingest.component.css']
})
export class ManagerIngestComponent implements OnInit {

  constructor(private employeeService: EmployeeService, private positionService: PositionService, private ingestService: IngestService) { }

  isShowAdd: boolean = false;
  ingestSrc: Ingest[] = [];

  ngOnInit(): void {
    this.ingestService.GetAllIngest().subscribe(s => {
      console.log(s);
      s.forEach((element: any) => {
        this.ingestSrc.push({
          IngestTagId: element.ingestTagId,
          Name: element.name,
          Note: element.note,
          PositionId: element.positionId,
          Status: element.status,
          CardholderName: element.cardholderName
        });
      });
    });


  }

  changeShowAdd() {
    this.isShowAdd = !this.isShowAdd;
  }
}
