import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/shared/employee/employee.model';
import { EmployeeService } from 'src/app/shared/employee/employee.service';
import { IngestService } from 'src/app/shared/ingest/ingest.service';
import { Position } from 'src/app/shared/position/position.model';
import { PositionService } from 'src/app/shared/position/position.service';
import { ProductionUnit } from 'src/app/shared/ProductionUnit/production-unit.model';
import { ProductionUnitService } from 'src/app/shared/ProductionUnit/production-unit.service';
import { StatusIngest } from 'src/app/shared/StatusInges/status-ingest.model';
import { StatusIngestService } from 'src/app/shared/StatusInges/status-ingest.service';
import { SummaryIngest } from 'src/app/shared/SummaryIngest/summary-ingest.model';
import { SummaryIngestService } from 'src/app/shared/SummaryIngest/summary-ingest.service';


@Component({
  selector: 'app-summary-table-ingest',
  templateUrl: './summary-table-ingest.component.html',
  styleUrls: ['./summary-table-ingest.component.css']
})
export class SummaryTableIngestComponent implements OnInit {
  statusIngests: StatusIngest[] = [];
  statusSelect: StatusIngest = new StatusIngest();
  employeeReportSrc: Employee[] = [];
  employeeCameramanSrc: Employee[] = [];
  summaryingests: SummaryIngest[] = [];
  summaryingest: SummaryIngest = new SummaryIngest();
  positionSrc: Position[] = [];
  productionUnitSrc: ProductionUnit[] = [];
  productionUnitSelect: ProductionUnit = new ProductionUnit();
  isShow = true;
  isAdd = false;
  isReceive = false;
  isReturn = false;

  constructor(
    private statusIngestService: StatusIngestService,
    private employeeService: EmployeeService,
    private positionService: PositionService,
    private ingestService: IngestService,
    private productionUnitService: ProductionUnitService,
    private summaryIngestService: SummaryIngestService
  ) { }

  ngOnInit(): void {
    this.statusIngestService.GetAllStatus().subscribe(s => {
      s.forEach((element: any) => {
        this.statusIngests.push({
          StatusIngestId: element.statusIngestId,
          Name: element.name,
          StatusCode: element.statusCode
        });
      });

    });
    this.employeeService.GetAllEmployeeReporter().subscribe(s => {
      s.forEach((element: any) => {
        this.employeeReportSrc.push({
          EmployeeId: element.employeeId,
          Name: element.name,
          PositionId: element.positionId,
          ProductionUnitId: element.productionUnitId,
        });
      });
    });
    this.employeeService.GetAllEmployeeCameraman().subscribe(s => {
      s.forEach((element: any) => {
        this.employeeCameramanSrc.push({
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
    this.productionUnitService.GetAllProductionUnits().subscribe(s => {
      s.forEach((element: any) => {
        this.productionUnitSrc.push({
          ProductionUnitId: element.productionUnitId,
          Name: element.name
        });
      });
    });
    this.summaryIngestService.GetAllSummaryIngest().subscribe(s => {
      console.log(s);
      s.forEach((element: any) => {
        this.summaryingest = new SummaryIngest();
        this.summaryingest.ticketIngest = {
          CreateName: element.ticketIngest.createName,
          CameramanName: element.ticketIngest.cameramanName,
          IsNew: element.ticketIngest.isNew,
          IsCategory: element.ticketIngest.isCategory,
          IsOtherProgram: element.ticketIngest.isOtherProgram,
          IsReporting: element.ticketIngest.isReporting,
          Name: element.ticketIngest.name,
          ProductionName: element.ticketIngest.productionName,
          ProgramName: element.ticketIngest.productionName,
          ReporterName: element.ticketIngest.reporterName,
          SaveDocument: element.ticketIngest.saveDocument,
          StatusIngest: element.ticketIngest.statusName,
          StatusIngestId: element.ticketIngest.statusIngestId,
          TicketIngestId: element.ticketIngest.ticketIngestId,
          TopicName: element.ticketIngest.topicName
        }
        element.ingestDetail.forEach((obj: any) => {
          this.summaryingest.ingestDetail.push({
            IngestDeltailId: obj.ingestDeltailId,
            TicketIngestId: obj.ticketIngestId,
            EmployeeSendId: obj.employeeSendId,
            EmployeeSend: obj.employeeSend,
            EmployeeReceiveId: obj.employeeReceiveId,
            EmployeeReceive: obj.employeeReceive,
            DateSend: obj.dateSend,
            DateReceive: obj.dateReceive,
            Recipient: obj.recipient,
            Ingest: {
              CardholderId: obj.ingestTag.cardholderId,
              CardholderName: obj.ingestTag.cardholderName,
              CategoryId: obj.ingestTag.categoryId,
              CategoryName: obj.ingestTag.categoryName,
              EmployeeId: obj.ingestTag.employeeId,
              IngestCode: obj.ingestTag.ingestCode,
              IngestTagId: obj.ingestTag.ingestTagId,
              Name: obj.ingestTag.name,
              Note: obj.ingestTag.note,
              Status: obj.ingestTag.status
            },
            Ingestid: obj.ingestid
          });
        });

        this.summaryingests.push(this.summaryingest);
      });

      console.log(this.summaryingest);
    });
  }

  changeStatusShow() {
    this.isShow = !this.isShow;
  }

  Add() {
    this.changeStatusShow();
  }
  onClick(item: any) {
    //console.log('Click '+ JSON.stringify(item));

  }
}
