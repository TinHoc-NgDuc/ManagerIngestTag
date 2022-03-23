import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { delay } from 'rxjs';
import { Category } from 'src/app/shared/Category/category.model';
import { CategoryService } from 'src/app/shared/Category/category.service';
import { Employee, EmployeeFilte } from 'src/app/shared/Employee/employee.model';
import { EmployeeService } from 'src/app/shared/Employee/employee.service';
import { Ingest } from 'src/app/shared/Ingest/ingest.model';
import { IngestService } from 'src/app/shared/Ingest/ingest.service';
import { IngestDetail } from 'src/app/shared/IngestDetail/ingest-detail.model';
import { Position } from 'src/app/shared/Position/position.model';
import { PositionService } from 'src/app/shared/Position/position.service';
import { ProductionUnitFilter } from 'src/app/shared/ProductionUnit/production-unit.model';
import { ProductionUnitService } from 'src/app/shared/ProductionUnit/production-unit.service';
import { ProgramShowFilter } from 'src/app/shared/ProgramShow/program-show.model';
import { ProgramShowService } from 'src/app/shared/ProgramShow/program-show.service';
import { StatusIngest } from 'src/app/shared/StatusInges/status-ingest.model';
import { StatusIngestService } from 'src/app/shared/StatusInges/status-ingest.service';
import { SummaryIngest } from 'src/app/shared/SummaryIngest/summary-ingest.model';
import { TicketIngestService } from 'src/app/shared/TicketIngest/ticket-ingest.service';
import { Topic, TopicFilter } from 'src/app/shared/Topics/topic.module';
import { TopicService } from 'src/app/shared/Topics/topic.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-ingest-tag-detail',
  templateUrl: './ingest-tag-detail.component.html',
  styleUrls: ['./ingest-tag-detail.component.css']
})
export class IngestTagDetailComponent implements OnInit {
  @Input() isShow: boolean = false;
  @Input() isAdd: boolean = false;
  @Input() isPending: boolean = false;
  @Input() isApproved: boolean = false;
  @Input() isDarft: boolean = false;
  @Input() summaryIngest: SummaryIngest = new SummaryIngest();
  @Output() changeStatusShow = new EventEmitter();
  isShowSubmit = false;

  statusIngests: StatusIngest[] = [];
  statusSelect: StatusIngest = new StatusIngest();
  employeeReportSrc: EmployeeFilte[] = [];
  employeeCameramanSrc: EmployeeFilte[] = [];
  employeeInRoomIngest: Employee[] = [];
  employeeReporterOrEditor: Employee[] = [];

  positionSrc: Position[] = [];
  productionUnitSrc: ProductionUnitFilter[] = [];
  programShowSrc: ProgramShowFilter[] = [];
  topicSrc: TopicFilter[] = [];
  ingestSrc: Ingest[] = [];
  categorySrc: Category[] = [];
  temptEplInRoomIngest: string = '';
  temptEplTakerTag: string = '';

  IngestDetailActionSelect: IngestDetail[] = [];
  IngestDetailReturnSelect: IngestDetail[] = [];


  dsnguoinhankhacnhau: Employee[] = [];
  employeeTaker: Employee = new Employee();

  // login
  isLoginSuccec = true;
  passLogin = false;

  // show hide required
  isShowTopicRequired = false;
  isShowReporterRequired = false;
  isShowCreateRequired = false;
  isShowProductionRequired = false;
  isShowCameramanRequired = false;
  isShowProgramRequired = false;
  isSaveDocumentRequired = false;
  isTypeProgramRequired = false;
  isEmployeeRequired = false;
  isTakerRequired = false;
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
    private datepipe: DatePipe
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
          IsShow: false,
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
          IsShow: false,
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
    this.ingestService.GetIngestTagsActivate().subscribe(s => {
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
          ProductionUnitId: element.productionUnitId,
          UserLogin: element.userLogin,
          Password: ''
        });
      });
    });
    this.employeeService.GetAllReporterOrEditor().subscribe(s => {
      s.forEach((element: any) => {
        this.employeeReporterOrEditor.push({
          EmployeeId: element.employeeId,
          Name: element.name,
          PositionId: element.positionId,
          ProductionUnitId: element.productionUnitId,
          UserLogin: element.userLogin,
          Password: ''
        });
      });
    });
  }

  changeShow() {
    this.changeStatusShow.emit();
  }
  // changeShowSubmit() {
  //   this.isShowSubmit = !this.isShowSubmit;
  // }
  Close() {
    this.changeShow();
  }
  Save(action: number) {
    //luu
    if (action == 0) {
      // this.summaryIngest.ticketIngest.StatusIngest = environment.Darft;
      // this.summaryIngest.ticketIngest.IngestDetailFull.forEach(element => {
      //   element.Status = environment.Darft;
      // });
      // this.ticketIngestService.PostIngest(this.summaryIngest.ticketIngest).subscribe(s => {
      //   
      // });
    }
    //trinh
    else if (action == 1) {

      var isError = this.checkValidate();
      if (isError) {
        //mess error
        return;
      }
      this.summaryIngest.ticketIngest.StatusIngest = environment.Pending;
      this.summaryIngest.ticketIngest.IngestDetailFull.forEach(element => {
        element.Status = environment.Pending;
      });
      this.ticketIngestService.PostIngest(this.summaryIngest.ticketIngest).subscribe(s => {
        this.ClearData();
        this.changeShow();
      });
    }
    //duyet
    else if (action == 2) {
      if (this.SelectIngesAcitionDeltail.length <= 0) {
        this.isTypeProgramRequired = true;
        return;
      }
      this.IngestDetailActionSelect.forEach(element => {
        var item = this.summaryIngest.ingestDetail.find(f => f.IngestDeltailId == element.IngestDeltailId);
        if (item != undefined) {
          item.Status = environment.Approved;
        }
      });
      this.ticketIngestService.PutIngest(this.summaryIngest.ticketIngest).subscribe(s => {
        this.ClearData();
        this.changeShow();
      });
    }
    //gui file
    else if (action == 3) {
      // if (this.IngestDetailActionSelect.length <= 0) {
      //   // this.IngestDetailActionSelect.forEach(element => {
      //   //   // this.isTypeProgramRequired = true;
      //   // });
      //   return;
      // }
      this.IngestDetailActionSelect.forEach(element => {
        var item = this.summaryIngest.ingestDetail.find(f => f.IngestDeltailId == element.IngestDeltailId);
        if (item != undefined) {
          item.Status = environment.SentFile;
        }
      });
      this.ticketIngestService.PutIngest(this.summaryIngest.ticketIngest).subscribe(s => {
        this.ClearData();
        this.changeShow();
      });

    }
    //tra the
    else if (action == 4) {
      this.dsnguoinhankhacnhau = [];
      this.IngestDetailReturnSelect.forEach(element => {
        var item = this.summaryIngest.ingestDetail.find(f => f.IngestDeltailId == element.IngestDeltailId);
        if (item != undefined && (item.TakerName != undefined && item.TakerName.length > 0)) {
          //item.Status = environment.SentFile;
          let checkExist = this.dsnguoinhankhacnhau.find(f => f.EmployeeId == element.TakerId);
          if (checkExist == undefined) {
            let eple = this.employeeReporterOrEditor.find(f => f.EmployeeId == element.TakerId);
            if (eple != undefined) {
              this.dsnguoinhankhacnhau.push(eple);
            }
          }
        }
        else {
          this.isTakerRequired = true;
        }
      });
      if (this.isTakerRequired == true) {
        return;
      }
      this.changeStateLogin(this.passLogin);
    }
  }
  changeStateLogin(passLogin: boolean) {
    this.isShowSubmit = false;
    if (passLogin) {
      //Messger login thanh cong


      //update status ticket, write log
      this.IngestDetailReturnSelect.forEach(element => {
        var ingestDeltail = this.summaryIngest.ingestDetail.find(f => (f.IngestDeltailId == element.IngestDeltailId && f.TakerId == this.employeeTaker.EmployeeId));
        if (ingestDeltail != undefined) {
          //cập nhật thông tin
          if (ingestDeltail != undefined) {
            ingestDeltail.Status = environment.ReturnTag;
            ingestDeltail.TakerId = this.employeeTaker.EmployeeId;
            ingestDeltail.TakerName = this.employeeTaker.Name;

            var date=new Date();
            let latest_date =this.datepipe.transform(date, 'dd/MM/yyyy');
            if(latest_date!= null){
              ingestDeltail.DateReturn =latest_date;
            }
          }
          this.ticketIngestService.PutIngest(this.summaryIngest.ticketIngest).subscribe(s => {
          });
        }
      });
    }
    else {
      //alert("login thất bại");
    }
    //this.isLoginSuccec =! this.isLoginSuccec;
    var item = this.dsnguoinhankhacnhau.shift();
    if (item != undefined) {
      this.employeeTaker = item;
      this.isShowSubmit = true;
    }
    else{
      this.employeeTaker = new Employee();
      this.ClearData();
      delay(500);
      
      this.changeShow();
    }
  }
  checkValidate() {
    var isError = false;
    // check validate
    if (this.summaryIngest.ticketIngest.TopicName.length <= 0) {
      this.isShowTopicRequired = true;
      isError = true;
    }
    if (this.summaryIngest.ticketIngest.ReporterName.length <= 0) {
      this.isShowReporterRequired = true;
      isError = true;
    }
    if (this.summaryIngest.ticketIngest.CreateName.length <= 0) {
      this.isShowCreateRequired = true;
      isError = true;
    }
    if (this.summaryIngest.ticketIngest.ProductionName.length <= 0) {
      this.isShowProductionRequired = true;
      isError = true;
    }
    if (this.summaryIngest.ticketIngest.ProgramName.length <= 0) {
      this.isShowProgramRequired = true;
      isError = true;
    }
    if (this.summaryIngest.ticketIngest.CameramanName.length <= 0) {
      this.isShowCameramanRequired = true;
      isError = true;
    }
    if (
      this.summaryIngest.ticketIngest.IsCategory == false &&
      this.summaryIngest.ticketIngest.IsNew == false &&
      this.summaryIngest.ticketIngest.IsReporting == false &&
      this.summaryIngest.ticketIngest.IsOtherProgram == false
    ) {
      this.isTypeProgramRequired = true;
      isError = true;
    }
    this.summaryIngest.ticketIngest.IngestDetailFull.forEach(element => {
      if (element.RecipientId == '00000000-0000-0000-0000-000000000000') {
        this.isEmployeeRequired = true;
        isError = true;
      }
    });
    return isError;
  }
  eplCreate() {
    this.isShowCreateRequired = false;
  }
  eplChangePvValue(event: any) {
    this.isShowReporterRequired = false;
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
    this.summaryIngest.ticketIngest.ReporterName = event.Name;
  }
  eplChangeQPValue(event: any) {
    this.isShowCameramanRequired = false;
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
    this.summaryIngest.ticketIngest.CameramanName = event.Name;
  }
  proUnitChangenValue(event: any) {
    this.isShowProductionRequired = false;
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
    this.isShowTopicRequired = false;
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
    this.clearRequired();
    this.summaryIngest.ticketIngest.TopicName = event.Name;
    this.summaryIngest.ticketIngest.CreateName = event.CreateName;
    this.summaryIngest.ticketIngest.ProgramName = event.ProgramName;
    this.summaryIngest.ticketIngest.ReporterName = event.ReporterName;
    this.summaryIngest.ticketIngest.CameramanName = event.CameramanName;
    this.summaryIngest.ticketIngest.ProductionName = event.ProductionName;
    this.summaryIngest.ticketIngest.Name = event.Name,
      this.summaryIngest.ticketIngest.IsCategory = event.IsCategory,
      this.summaryIngest.ticketIngest.IsNew = event.IsNew,
      this.summaryIngest.ticketIngest.IsOtherProgram = event.IsOtherProgram,
      this.summaryIngest.ticketIngest.IsReporting = event.IsReporting
  }
  checkTypeProgram() {
    this.isTypeProgramRequired = false;
  }
  programChangeValue(event: any) {
    this.isShowProgramRequired = false;
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
    this.summaryIngest.ticketIngest.ProductionName = event.Name;
  }
  programSelect(event: any) {
    this.clearShow();
    this.summaryIngest.ticketIngest.ProgramName = event.Name;
  }
  SelectIngest(event: any) {
    if (event.target.value.length > 0) {
      var item = this.ingestSrc.find(e => e.IngestCode == event.target.value);
      if (item != undefined) {
        this.summaryIngest.ticketIngest.IngestDetailFull.push({
          IngestDeltailId: "00000000-0000-0000-0000-000000000000",
          DateSend: new Date().toLocaleString().split(',')[0],
          IngestTagId: "00000000-0000-0000-0000-000000000000",
          RecipientId: "00000000-0000-0000-0000-000000000000",
          TakerId: "00000000-0000-0000-0000-000000000000",
          RecipientName: "",
          ticketIngestId: "00000000-0000-0000-0000-000000000000",
          TakerName: "",
          DateReturn: '',
          Status: '',
          IngestTag: {
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
        this.removeElement(this.ingestSrc, item);
      }
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
    if (element != undefined) {
      this.ingestSrc.push(element.IngestTag);
      this.removeElement(this.summaryIngest.ticketIngest.IngestDetailFull, element);

    }
  }
  clearShow() {
    this.employeeReportSrc.forEach(element => { element.IsShow = false; });
    this.employeeCameramanSrc.forEach(element => { element.IsShow = false; });
    this.productionUnitSrc.forEach(element => { element.IsShow = false; });
    this.topicSrc.forEach(element => { element.IsShow = false; });
    this.programShowSrc.forEach(element => { element.IsShow = false; });
  }
  clearRequired() {
    this.isShowTopicRequired = false;
    this.isShowReporterRequired = false;
    this.isShowCreateRequired = false;
    this.isShowProductionRequired = false;
    this.isShowCameramanRequired = false
    this.isShowProgramRequired = false;
    this.isTypeProgramRequired = false;
  }
  changeEmployee(item: IngestDetail) {
    item.RecipientId = this.temptEplInRoomIngest;
    item.RecipientName = this.employeeInRoomIngest.find(f => f.EmployeeId == item.RecipientId)?.Name;
    this.temptEplInRoomIngest = '';
    this.isEmployeeRequired = false;
  }
  changeEmployeeReturn(item: IngestDetail) {
    item.TakerId = this.temptEplTakerTag;
    item.TakerName = this.employeeReporterOrEditor.find(f => f.EmployeeId == this.temptEplTakerTag)?.Name;
    this.temptEplTakerTag = '';
    this.isTakerRequired = false;
  }
  SelectIngesAcitionDeltail(item: IngestDetail, event: any) {
    if (event.srcElement.checked) {
      this.IngestDetailActionSelect.push(item);
    }
    else {
      this.removeElement(this.IngestDetailActionSelect, item);
    }

  }
  SelectIngestReturnDeltail(item: IngestDetail, event: any) {
    if (event.srcElement.checked) {
      this.IngestDetailReturnSelect.push(item);
    }
    else {
      this.removeElement(this.IngestDetailReturnSelect, item);
    }
  }
  ClearData() {
    this.summaryIngest = new SummaryIngest();
    this.IngestDetailActionSelect = [];
    this.IngestDetailReturnSelect = [];
    this.temptEplInRoomIngest = '';
  }
}
