import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y/input-modality/input-modality-detector';
import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/shared/employee/employee.model';
import { EmployeeService } from 'src/app/shared/employee/employee.service';
import { Filter } from 'src/app/shared/filter/filter.model';
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
  ingestEdit: Ingest = new Ingest();
  employeeSelect: Employee = new Employee();
  pageSize = [10, 20, 30];
  sizeChoose: number = 10;
  numberPage: number = 0;
  numberPageChoose: number = 1;
  filter: Filter = new Filter();
  ngOnInit(): void {
    this.filter.Query = "";
    this.filter.NumberPage = this.numberPageChoose;
    this.filter.PageSize = this.sizeChoose;
    this.getIngestData();

  }

  //function
  getIngestData() {
    this.ingestSrc = [];
    this.ingestService.GetFilter(this.filter).subscribe(s => {
      s.forEach((element: any) => {
        this.ingestSrc.push({
          IngestTagId: element.ingestTagId,
          IngestCode: element.ingestCode,
          Name: element.name,
          Note: element.note,
          PositionId: element.positionId,
          PositionName: element.positionName,
          Status: element.status,
          EmployeeId: element.employeeId,
          cardholderId: element.cardholderId,
          CardholderName: element.cardholderName
        });
      });
    });
    this.ingestService.GetNumberPage(this.filter).subscribe(s => {
      console.log(s);
      this.numberPage = s;
    });
  }
  changeShowAdd() {
    this.isShowAdd = !this.isShowAdd;
    if (!this.isShowAdd) {
      this.getIngestData();
    }
  }

  //fucntion
  Add() {
    this.isAdd = true;
    this.isEdit = false;
    this.changeShowAdd();
  }
  Delete(item: any) {
    this.ingestService.DeleteIngest(item.IngestTagId).subscribe(s => {
      this.getIngestData();
    });
  }
  Edit(item: any) {
    this.isAdd = false;
    this.isEdit = true;
    this.ingestEdit = item;
    this.employeeSelect.Name = item.CardholderName;
    this.employeeSelect.PositionId = item.PositionId;
    this.employeeSelect.EmployeeId = item.EmployeeId;
    this.employeeSelect.ProductionUnitId = item.ProductionUnitId;

    //console.log(this.ingestEdit);
    this.changeShowAdd();
  }
  Search(event: any) {
    this.ingestSrc = [];
    this.filter.Query = event.target.value;
    this.filter.NumberPage = this.numberPageChoose;
    this.filter.PageSize = this.sizeChoose;
    this.ingestService.GetFilter(event.target.value).subscribe(s => {
      s.forEach((element: any) => {
        this.ingestSrc.push({
          IngestTagId: element.ingestTagId,
          IngestCode: element.ingestCode,
          Name: element.name,
          Note: element.note,
          PositionId: element.positionId,
          PositionName: element.positionName,
          Status: element.status,
          EmployeeId: element.employeeId,
          cardholderId: element.cardholderId,
          CardholderName: element.cardholderName
        });
      });
    });
  }
}
