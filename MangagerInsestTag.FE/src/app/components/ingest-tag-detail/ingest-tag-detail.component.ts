import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { flush } from '@angular/core/testing';
import { Employee, EmployeeFilte } from 'src/app/shared/employee/employee.model';
import { EmployeeService } from 'src/app/shared/employee/employee.service';
import { IngestService } from 'src/app/shared/ingest/ingest.service';
import { Position } from 'src/app/shared/position/position.model';
import { PositionService } from 'src/app/shared/position/position.service';
import { ProductionUnit, ProductionUnitFilter } from 'src/app/shared/ProductionUnit/production-unit.model';
import { ProductionUnitService } from 'src/app/shared/ProductionUnit/production-unit.service';
import { ProgramShow } from 'src/app/shared/ProgramShow/program-show.module';
import { ProgramShowService } from 'src/app/shared/ProgramShow/program-show.service';
import { StatusIngest } from 'src/app/shared/StatusInges/status-ingest.model';
import { StatusIngestService } from 'src/app/shared/StatusInges/status-ingest.service';
import { Topic, TopicFilter } from 'src/app/shared/Topics/topic.module';
import { TopicService } from 'src/app/shared/Topics/topic.service';

@Component({
  selector: 'app-ingest-tag-detail',
  templateUrl: './ingest-tag-detail.component.html',
  styleUrls: ['./ingest-tag-detail.component.css']
})
export class IngestTagDetailComponent implements OnInit {
  @Input() isShow: boolean = false;
  @Output() changeStatusShow = new EventEmitter();
  statusIngests: StatusIngest[] = [];
  statusSelect: StatusIngest = new StatusIngest();
  employeeReportSrc: EmployeeFilte[] = [];
  employeeCameramanSrc: EmployeeFilte[] = [];
  positionSrc: Position[] = [];
  productionUnitSrc: ProductionUnitFilter[] = [];
  programShowSrc: ProgramShow[] = [];
  topicSrc: TopicFilter[] = [];

  constructor(
    private statusIngestService: StatusIngestService,
    private employeeService: EmployeeService,
    private positionService: PositionService,
    private ingestService: IngestService,
    private productionUnitService: ProductionUnitService,
    private programShowService: ProgramShowService,
    private topicService: TopicService
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
          TopicId: element.TopicId,
          Name: element.Name,
          ProgramName: element.ProductionName,
          CameramanName: element.CameramanName,
          ProductionName: element.ProductionName,
          ReporterName: element.ReporterName,
          CreateName: element.CreateName,
          IsReporting: element.IsReporting,
          IsNew: element.IsNew,
          IsCategory: element.IsCategory,
          IsOtherProgram: element.IsOtherProgram,
          IsShow : true
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
          Name: element.name
        });
      });
    });
  }

  changeShow() {
    this.changeStatusShow.emit();
  }

  Close() {
    this.changeShow();
  }
  Save() {
    this.changeShow();
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
  clearShow() {
    this.employeeReportSrc.forEach(element => { element.IsShow = false; });
    this.employeeCameramanSrc.forEach(element => { element.IsShow = false; });
    this.productionUnitSrc.forEach(element => { element.IsShow = false; });
  }
}
