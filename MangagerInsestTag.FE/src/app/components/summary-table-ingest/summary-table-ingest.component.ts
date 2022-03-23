import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee } from 'src/app/shared/Employee/employee.model';
import { EmployeeService } from 'src/app/shared/Employee/employee.service';
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
  summaryingestsFilter: SummaryIngest[] = [];
  summaryingest: SummaryIngest = new SummaryIngest();
  positionSrc: Position[] = [];
  productionUnitSrc: ProductionUnit[] = [];
  productionUnitSelect: ProductionUnit = new ProductionUnit();
  isShow = false;
  isAdd = false;
  isPending = false;
  isApproved = false;
  isDarft = false;
  //filter
  filter: Filter = new Filter();
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });
  isFilterDate = false;

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
      this.summaryingestsFilter = this.summaryingests;
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
  ExportExcel() {
    // let urlExporl = environment.baseUrl + "/api/SumaryIngest/exportExcel";
    // window.open(urlExporl);
    this.exportTableToExcel('tableData', 'data');
  }
  exportTableToExcel(tableID: string, filename = '') {
    var downloadLink;
    var dataType = 'application/vnd.ms-excel';
    var tableSelect = document.getElementById(tableID);
    //console.log(tableSelect);

    if (tableSelect != null) {

      //var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');
      var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20').replace(/#/g, '%23');

      // Specify file name
      filename = filename ? filename + '.xls' : 'excel_data.xls';

      // Create download link element
      downloadLink = document.createElement("a");

      document.body.appendChild(downloadLink);



      // Create a link to the file
      downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

      // Setting the file name
      downloadLink.download = filename;

      //triggering the function
      downloadLink.click();

    }
  }
  onClick(item: SummaryIngest) {
    this.summaryingest = item;
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
  //export Data to file excel

  //filter
  reporterChange() {
    var item = this.employeeReportSrc.find(f => f.EmployeeId == this.filter.reporter.EmployeeId);
    if (item != undefined) {
      this.filter.reporter = {
        EmployeeId: item.EmployeeId,
        Password: item.Password,
        PositionId: item.PositionId,
        ProductionUnitId: item.ProductionUnitId,
        UserLogin: item.UserLogin,
        Name: item.Name
      };
      this.filteTicket();
    }
  }
  productionUnitChange() {
    var item = this.productionUnitSrc.find(f => f.ProductionUnitId == this.filter.productionUnit.ProductionUnitId);
    if (item != undefined) {
      this.filter.productionUnit = {
        Name: item.Name,
        ProductionUnitId: item.ProductionUnitId
      };
      this.filteTicket();
    }
  }
  cameramenChange() {
    var item = this.employeeCameramanSrc.find(f => f.EmployeeId == this.filter.cameramen.EmployeeId);
    if (item != undefined) {
      this.filter.cameramen = {
        EmployeeId: item.EmployeeId,
        Password: item.Password,
        PositionId: item.PositionId,
        ProductionUnitId: item.ProductionUnitId,
        UserLogin: item.UserLogin,
        Name: item.Name
      };
      this.filteTicket();
    }
  }
  statusIngestChange() {
    var item = this.statusIngests.find(f => f.StatusIngestId == this.filter.statusIngest.StatusIngestId);
    if (item != undefined) {
      this.filter.statusIngest = {
        StatusIngestId: item.StatusIngestId,
        StatusCode: item.StatusCode,
        Name: item.Name
      };
      this.filteTicket();
    }
  }
  filteTicket() {
    this.summaryingestsFilter = [];
    this.summaryingests.forEach(element => {
      let flagt = true;
      debugger
      if (this.filter.cameramen.Name != undefined && this.filter.cameramen.Name?.length > 0) {
        if (!element.ticketIngest.CameramanName.toLocaleLowerCase().includes(this.filter.cameramen.Name.toLocaleLowerCase())) {
          flagt = false;
        }
      }
      if (this.filter.reporter.Name != undefined && this.filter.reporter.Name?.length > 0) {
        if (!element.ticketIngest.ReporterName.toLocaleLowerCase().includes(this.filter.reporter.Name.toLocaleLowerCase())) {
          flagt = false;
        }
      }
      if (this.filter.productionUnit.Name.length > 0) {
        if (!element.ticketIngest.ProductionName.toLocaleLowerCase().includes(this.filter.productionUnit.Name.toLocaleLowerCase())) {
          flagt = false;
        }
      }
      if (this.filter.statusIngest.Name.length > 0) {
        if (!element.ticketIngest.StatusIngestCode.toLocaleLowerCase().includes(this.filter.statusIngest.StatusCode.toLocaleLowerCase())) {
          flagt = false;
        }
      }
      if (!(this.filter.timeStart <= element.ticketIngest.DateCreate && this.filter.timeEnd >= element.ticketIngest.DateCreate)) {
        console.log(this.filter.timeStart);
        
        flagt = false;
      }
      if (this.filter.strFilter.length > 0) {
        var str = this.filter.strFilter.toLocaleLowerCase();
        if (!(
          element.ticketIngest.CameramanName.toLocaleLowerCase().includes(str) ||
          element.ticketIngest.ReporterName.toLocaleLowerCase().includes(str) ||
          element.ticketIngest.ProductionName.toLocaleLowerCase().includes(str) ||
          element.ticketIngest.Name.toLocaleLowerCase().includes(str) ||
          element.ticketIngest.CreateName.toLocaleLowerCase().includes(str)
        )) {
          flagt = false;
        }

        element.ingestDetail.forEach(obj => {
          if (!(
            obj.RecipientName?.toLocaleLowerCase().includes(str) ||
            obj.TakerName?.toLocaleLowerCase().includes(str)
          )) {
            flagt = false;
          }
        });
      }
      if (flagt) {
        this.summaryingestsFilter.push(element);
      }
    });

  }
  //
  StartDate(event: any) {
    this.isFilterDate = true;
    this.filter.timeStart = event.value;
    this.filteTicket();
  }
  EndDate(event: any) {
    this.isFilterDate = true;
    this.filter.timeEnd = event.value;
    this.filteTicket();
  }

  //clear
  clearFilterReporter() {
    this.filter.reporter.EmployeeId = '';
    this.filter.reporter.Name = '';
    this.filter.reporter.Password = '';
    this.filter.reporter.PositionId = '';
    this.filter.reporter.ProductionUnitId = '';
    this.filter.reporter.UserLogin = '';
    this.filteTicket();
  }
  clearFilterProductionUnit() {
    this.filter.productionUnit.Name = '';
    this.filter.productionUnit.ProductionUnitId = '';
    this.filteTicket();
  }
  clearFilterCameramen() {
    this.filter.cameramen.EmployeeId = '';
    this.filter.cameramen.Name = '';
    this.filter.cameramen.Password = '';
    this.filter.cameramen.PositionId = '';
    this.filter.cameramen.ProductionUnitId = '';
    this.filter.cameramen.UserLogin = '';
    this.filteTicket();
  }
  clearFilterStatusIngest() {
    this.filter.statusIngest.StatusIngestId = '';
    this.filter.statusIngest.Name = '';
    this.filter.statusIngest.StatusCode = '';
    this.filteTicket();
  }
  clearFilterDate() {
    this.isFilterDate = false;
    this.range = new FormGroup({
      start: new FormControl(),
      end: new FormControl(),
    });
    this.filter.timeEnd = new Date("9999-05-27");
    this.filter.timeStart = new Date("0001-05-27");
    this.filteTicket();
  }
  changStrFilter() {
    this.filteTicket();
  }
  clearStrFilter(){
    this.filter.strFilter ='';
    this.filteTicket();
  }
}

class Filter {
  public timeStart: Date = new Date("0001-05-27");
  public timeEnd: Date = new Date("9999-05-27");
  public reporter: Employee = new Employee();
  public cameramen: Employee = new Employee();
  public productionUnit: ProductionUnit = new ProductionUnit();
  public strFilter: string = '';
  public statusIngest: StatusIngest = new StatusIngest();
}