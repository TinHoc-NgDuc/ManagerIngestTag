import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/shared/Employee/employee.model';
import { EmployeeService } from 'src/app/shared/Employee/employee.service';
import { HistoryIngestService } from 'src/app/shared/HistoryIngest/history-ingest.service';
import { IngestService } from 'src/app/shared/Ingest/ingest.service';
import { IngestDetail } from 'src/app/shared/IngestDetail/ingest-detail.model';
import { Position } from 'src/app/shared/Position/position.model';
import { PositionService } from 'src/app/shared/Position/position.service';
import { ProductionUnit } from 'src/app/shared/ProductionUnit/production-unit.model';
import { ProductionUnitService } from 'src/app/shared/ProductionUnit/production-unit.service';
import { StatusIngest } from 'src/app/shared/StatusInges/status-ingest.model';
import { StatusIngestService } from 'src/app/shared/StatusInges/status-ingest.service';
import { SummaryIngest } from 'src/app/shared/SummaryIngest/summary-ingest.model';
import { SummaryIngestService } from 'src/app/shared/SummaryIngest/summary-ingest.service';
import { environment } from 'src/environments/environment';


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
  isShow = false;
  isAdd = false;
  isPending = false;
  isApproved = false;
  isDarft = false;
  constructor(
    private statusIngestService: StatusIngestService,
    private employeeService: EmployeeService,
    private positionService: PositionService,
    private productionUnitService: ProductionUnitService,
    private summaryIngestService: SummaryIngestService,
    private router: Router,
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
          UserLogin: element.userLogin,
          Password: ''
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
          UserLogin: element.userLogin,
          Password: ''
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
    this.getSummary();
  }
  getSummary() {
    this.summaryingests = [];
    this.summaryIngestService.GetAllSummaryIngest().subscribe(s => {
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
          StatusIngestCode: element.ticketIngest.statusIngest,
          TicketIngestId: element.ticketIngest.ticketIngestId,
          TopicName: element.ticketIngest.topicName,
          DateCreate: new Date(),
          IngestDetailFull: []
        }
        element.ingestDetail.forEach((obj: any) => {
          this.summaryingest.ingestDetail.push({
            IngestDeltailId: obj.ingestDeltailId,
            ticketIngestId: obj.ticketIngestId,
            DateReturn: obj.dateReturn,
            DateSend: obj.dateSend,
            IngestTagId: obj.ingestTagId,
            RecipientId: obj.recipientId,
            RecipientName: obj.recipientName,
            TakerId: obj.takerId,
            TakerName: obj.takerName,
            Status: obj.status,
            IngestTag: {
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
            }
          });
        });
        this.summaryingest.ticketIngest.IngestDetailFull = this.summaryingest.ingestDetail;
        element.historyIngest.forEach((item: any) => {
          this.summaryingest.HistoryIngest.push({
            TicketIngestId: item.ticketIngestId,
            ActionCode: item.actionCode,
            HistoryIngestId: item.historyIngestId,
            NameAction: item.nameAction,
            Performer: item.performer,
            TicketIngest: item.ticketIngest,
            TimeAction: item.timeAction
          });
        });

        this.summaryingests.push(this.summaryingest);
      });
      this.summaryingest = new SummaryIngest();
    });

  }
  changeStatusShow() {
    this.isShow = !this.isShow;
    if (!this.isShow) {
      this.getSummary();
    }
  }

  Add() {
    this.isShow = false;
    this.isAdd = true;
    this.isPending = false;
    this.isApproved = false;
    this.isDarft = false;
    this.changeStatusShow();
  }
  ExportExcel(){
    let urlExporl = environment.baseUrl+"/api/SumaryIngest/exportExcel";
    window.open(urlExporl);
  }
  onClick(item: SummaryIngest) {
    this.summaryingest = item;
    // var date = new Date();
    // let latest_date = this.datepipe.transform(date, 'dd/MM/yyyy');
    // console.log(latest_date);


    if (item.ticketIngest.StatusIngestCode.toLocaleLowerCase() == environment.Pending.toLocaleLowerCase()) {
      this.isShow = false;
      this.isAdd = false;
      this.isPending = true;
      this.isApproved = false;
      this.isDarft = false;
      this.changeStatusShow();
    }
    else if (item.ticketIngest.StatusIngestCode.toLocaleLowerCase() == environment.Approved.toLocaleLowerCase()) {
      this.isShow = false;
      this.isAdd = false;
      this.isPending = false;
      this.isApproved = true;
      this.isDarft = false;
      this.changeStatusShow();
    }
    else if (item.ticketIngest.StatusIngestCode.toLocaleLowerCase() == environment.SentFile.toLocaleLowerCase()) {
      this.isShow = false;
      this.isAdd = false;
      this.isPending = false;
      this.isApproved = true;
      this.isDarft = false;
      this.changeStatusShow();
    }

  }
}
