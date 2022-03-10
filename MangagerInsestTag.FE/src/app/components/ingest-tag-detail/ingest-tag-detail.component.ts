import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Category } from 'src/app/shared/Category/category.model';
import { CategoryService } from 'src/app/shared/Category/category.service';
import { Employee, EmployeeFilte } from 'src/app/shared/employee/employee.model';
import { EmployeeService } from 'src/app/shared/employee/employee.service';
import { Ingest } from 'src/app/shared/ingest/ingest.model';
import { IngestService } from 'src/app/shared/ingest/ingest.service';
import { IngestDetail } from 'src/app/shared/IngestDetail/ingest-detail.model';
import { IngestDetailService } from 'src/app/shared/IngestDetail/ingest-detail.service';
import { Position } from 'src/app/shared/position/position.model';
import { PositionService } from 'src/app/shared/position/position.service';
import { ProductionUnitFilter } from 'src/app/shared/ProductionUnit/production-unit.model';
import { ProductionUnitService } from 'src/app/shared/ProductionUnit/production-unit.service';
import { ProgramShowFilter } from 'src/app/shared/ProgramShow/program-show.model';
import { ProgramShowService } from 'src/app/shared/ProgramShow/program-show.service';
import { StatusIngest } from 'src/app/shared/StatusInges/status-ingest.model';
import { StatusIngestService } from 'src/app/shared/StatusInges/status-ingest.service';
import { TicketIngest } from 'src/app/shared/TicketIngest/ticket-ingest.model';
import { TicketIngestService } from 'src/app/shared/TicketIngest/ticket-ingest.service';
import { Topic, TopicFilter } from 'src/app/shared/Topics/topic.module';
import { TopicService } from 'src/app/shared/Topics/topic.service';

@Component({
  selector: 'app-ingest-tag-detail',
  templateUrl: './ingest-tag-detail.component.html',
  styleUrls: ['./ingest-tag-detail.component.css']
})
export class IngestTagDetailComponent implements OnInit {
  @Input() isShow: boolean = false;
  @Input() isAdd: boolean = true;
  @Output() changeStatusShow = new EventEmitter();

  statusIngests: StatusIngest[] = [];
  statusSelect: StatusIngest = new StatusIngest();
  employeeReportSrc: EmployeeFilte[] = [];
  employeeCameramanSrc: EmployeeFilte[] = [];
  employeeInRoomIngest: Employee[] = [];
  positionSrc: Position[] = [];
  productionUnitSrc: ProductionUnitFilter[] = [];
  programShowSrc: ProgramShowFilter[] = [];
  topicSrc: TopicFilter[] = [];
  ingestSrc: Ingest[] = [];
  categorySrc: Category[] = [];
  ticketIngest: TicketIngest = new TicketIngest();
  ingestSelect: IngestDetail[] = [];
  ingestDetailCreate: IngestDetail = new IngestDetail();
  temptEplInRoomIngest: string = '';
  constructor(
    private statusIngestService: StatusIngestService,
    private employeeService: EmployeeService,
    private positionService: PositionService,
    private ingestService: IngestService,
    private productionUnitService: ProductionUnitService,
    private programShowService: ProgramShowService,
    private topicService: TopicService,
    private categoryService: CategoryService,
    private ticketIngestService: TicketIngestService,
    private ingestDetailService: IngestDetailService
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
    this.topicService.GetAllTopic().subscribe(s => {
      s.forEach((element: any) => {
        this.topicSrc.push({
          TopicId: element.topicId,
          Name: element.name,
          ProgramName: element.productionName,
          CameramanName: element.cameramanName,
          ProductionName: element.productionName,
          ReporterName: element.reporterName,
          CreateName: element.createName,
          IsReporting: element.isReporting,
          IsNew: element.isNew,
          IsCategory: element.isCategory,
          IsOtherProgram: element.isOtherProgram,
          IsShow: false
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
          IsShow: false
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
          IsShow: false
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
          Name: element.name,
          IsShow: false
        });
      });
    });
    this.programShowService.GetAllProgramShow().subscribe(s => {
      s.forEach((element: any) => {
        this.programShowSrc.push({
          PropgramShowId: element.programShow,
          Name: element.name,
          IsShow: false
        });
      });
    });

    this.ingestService.GetAllIngest().subscribe(s => {
      s.forEach((element: any) => {
        this.ingestSrc.push({
          IngestTagId: element.ingestTagId,
          IngestCode: element.ingestCode,
          Name: element.name,
          Note: element.note,
          Status: element.status,
          CategoryId: element.categoryId,
          CardholderId: element.cardholderId,
          EmployeeId: element.employeeId,
          CategoryName: element.categoryName,
          CardholderName: element.cardholderName
        });
      });
    });
    this.categoryService.GetAllCategories().subscribe(s => {
      s.forEach((element: any) => {
        this.categorySrc.push({
          CategoryId: element.categoryId,
          Name: element.name
        });
      });
    });
    this.employeeService.GetAllEmployeeInRoomIngest().subscribe(s => {
      s.forEach((element: any) => {
        this.employeeInRoomIngest.push({
          EmployeeId: element.employeeId,
          Name: element.name,
          PositionId: element.positionId,
          ProductionUnitId: element.productionUnitId
        });
      });
    });

    //this.ingestSelect = this.ingestSrc;
  }

  changeShow() {
    this.changeStatusShow.emit();
  }

  Close() {
    this.changeShow();
  }
  Save() {
    //this.changeShow();
    if (this.isAdd) {
      this.ticketIngest.StatusIngest = "Draft";
    }
    //console.log(this.ingestSelect);

    this.ticketIngestService.PostIngest(this.ticketIngest).subscribe(s => {
      this.ingestSelect.forEach(element => {
        element.TicketIngestId = s.ticketIngestId,
        element.EmployeeReceive = this.employeeInRoomIngest.find(f => f.EmployeeId == element.EmployeeReceiveId)?.Name;
      });
      this.ingestDetailService.PostIngestDetail(this.ingestSelect).subscribe(
        (resp) => {
          console.log(resp);
        },
        (error) => {
          console.log(error.error);
        });
    });
  }

  eplChangePvValue(event: any) {
    var strInput = event.target.value;
    this.clearShow();
    if (strInput.length > 0) {
      this.employeeReportSrc.forEach(element => {
        if (element.Name?.toLowerCase().includes(strInput.toLowerCase())) {
          element.IsShow = true;
        };
      });
    }
  }
  EmployeePVSelect(event: any) {
    this.clearShow();
    this.ticketIngest.ReporterName = event.Name;
  }
  eplChangeQPValue(event: any) {
    var strInput = event.target.value;
    this.clearShow();
    if (strInput.length > 0) {
      this.employeeCameramanSrc.forEach(element => {
        if (element.Name?.toLowerCase().includes(strInput.toLowerCase())) {
          element.IsShow = true;
        };
      });
    }
  }
  EmployeeQPSelect(event: any) {
    this.clearShow();
    this.ticketIngest.CameramanName = event.Name;
  }
  proUnitChangenValue(event: any) {
    var strInput = event.target.value;
    this.clearShow();
    if (strInput.length > 0) {
      this.productionUnitSrc.forEach(element => {
        if (element.Name?.toLowerCase().includes(strInput.toLowerCase())) {
          element.IsShow = true;
        };
      });
    }
  }
  TopicChangePvValue(event: any) {
    var strInput = event.target.value;
    this.clearShow();
    if (strInput.length > 0) {
      this.topicSrc.forEach(element => {
        if (element.Name?.toLowerCase().includes(strInput.toLowerCase())) {
          element.IsShow = true;
        };
      });
    }
  }
  TopicSelect(event: Topic) {
    this.clearShow();
    this.ticketIngest.TopicName = event.Name;
    this.ticketIngest.CreateName = event.CreateName;
    this.ticketIngest.ProgramName = event.ProgramName;
    this.ticketIngest.ReporterName = event.ReporterName;
    this.ticketIngest.CameramanName = event.CameramanName;
    this.ticketIngest.ProductionName = event.ProductionName;
    this.ticketIngest.Name = event.Name,
      this.ticketIngest.IsCategory = event.IsCategory,
      this.ticketIngest.IsNew = event.IsNew,
      this.ticketIngest.IsOtherProgram = event.IsOtherProgram,
      this.ticketIngest.IsReporting = event.IsReporting
  }
  programChangeValue(event: any) {
    var strInput = event.target.value;
    this.clearShow();
    if (strInput.length > 0) {
      this.programShowSrc.forEach(element => {
        if (element.Name?.toLowerCase().includes(strInput.toLowerCase())) {
          element.IsShow = true;
        };
      });
    }
  }
  ProductionSelect(event: any) {
    this.clearShow();
    this.ticketIngest.ProductionName = event.Name;
  }
  programSelect(event: any) {
    this.clearShow();
    this.ticketIngest.ProgramName = event.Name;
  }
  SelectIngest(event: any) {
    //console.log(this.ingest);
    var item = this.ingestSrc.find(e => e.IngestCode == this.ingestDetailCreate.Ingest.IngestCode);
    if (item != undefined) {
      this.ingestSelect.push({
        IngestDeltailId: "00000000-0000-0000-0000-000000000000",
        DateReceive: "",
        DateSend: new Date().toLocaleString().split(',')[0],
        EmployeeReceive: "",
        EmployeeSend: "",
        Sender: "",
        TicketIngestId: "00000000-0000-0000-0000-000000000000",
        EmployeeReceiveId: "00000000-0000-0000-0000-000000000000",
        EmployeeSendId: "00000000-0000-0000-0000-000000000000",
        Ingest: {
          IngestTagId: item.IngestTagId,
          IngestCode: item.IngestCode,
          Name: item.Name,
          Note: item.Note,
          Status: item.Status,
          CategoryId: item.CardholderId,
          CategoryName: item.CategoryName,
          CardholderId: item.CardholderId,
          EmployeeId: item.EmployeeId,
          CardholderName: item.CardholderId
        }
      });
      // this.ingestCreate = new IngestCreate();
      this.removeElement(this.ingestSrc, item);
    }

  }
  removeElement(array: any[], elem: any) {
    var index = array.indexOf(elem);
    //array.splice(index, 1);
    if (index > -1) {
      array.splice(index, 1);
    }
  }
  Remove(element: any) {
    // console.log(element);
    // if (element != undefined) {
    //   this.ingestSrc.push(element);
    //   this.ingestCreate = new IngestCreate();
    //   this.removeElement(this.ingestSelect, element);

    // }
  }
  clearShow() {
    this.employeeReportSrc.forEach(element => { element.IsShow = false; });
    this.employeeCameramanSrc.forEach(element => { element.IsShow = false; });
    this.productionUnitSrc.forEach(element => { element.IsShow = false; });
    this.topicSrc.forEach(element => { element.IsShow = false; });
    this.programShowSrc.forEach(element => { element.IsShow = false; });
  }

  changeEmployee(item: IngestDetail) {
    item.EmployeeReceiveId = this.temptEplInRoomIngest;
    this.temptEplInRoomIngest = '';
  }
}
