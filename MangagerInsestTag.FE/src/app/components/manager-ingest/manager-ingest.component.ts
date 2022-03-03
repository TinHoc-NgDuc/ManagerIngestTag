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

  //init
  isShowAdd: boolean = false;
  isAdd = false;
  isEdit = false;
  ingestSrc: Ingest[] = [];
  IngestEdit: Ingest = new Ingest();

  ngOnInit(): void {
    this.getIngestData();
  }

  //function
  getIngestData() {
    this.ingestSrc = [];
    this.ingestService.GetAllIngest().subscribe(s => {
      s.forEach((element: any) => {
        this.ingestSrc.push({
          IngestTagId: element.ingestTagId,
          Name: element.name,
          Note: element.note,
          PositionId: element.positionId,
          PositionName: element.positionName,
          Status: element.status,
          CardholderName: element.cardholderName
        });
      });
      debugger
    });
  }
  changeShowAdd() {
    this.isShowAdd = !this.isShowAdd;
    if (!this.isShowAdd) {
      this.getIngestData();
    }
  }

  //fucntion
  Delete(item: any) {
    this.ingestService.DeleteIngest(item.IngestTagId).subscribe(s => {
      this.getIngestData();
    });
  }
  Edit(item: any) {
    this.IngestEdit = item;
    this.changeShowAdd();
  }
}
