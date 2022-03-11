import { Component, EventEmitter, OnInit, Input, Output } from '@angular/core';
import { Category } from 'src/app/shared/Category/category.model';
import { CategoryService } from 'src/app/shared/Category/category.service';
import { Employee } from 'src/app/shared/employee/employee.model';
import { EmployeeService } from 'src/app/shared/employee/employee.service';
import { Ingest } from 'src/app/shared/ingest/ingest.model';
import { IngestService } from 'src/app/shared/ingest/ingest.service';

@Component({
  selector: 'app-ingest-detail',
  templateUrl: './ingest-detail.component.html',
  styleUrls: ['./ingest-detail.component.css']
})
export class IngestDetailComponent implements OnInit {
  @Input() isShow: boolean = false;
  @Input() isAdd: boolean = false;
  @Input() isEdit: boolean = false;
  @Input() ingestData: Ingest = new Ingest();
  @Input() employeeSelect: Employee = new Employee();
  @Output() changeShow = new EventEmitter();

  employeeSrc: Employee[] = [];
  categorySrc: Category[] = [];

  constructor
    (
      private employeeService: EmployeeService,
      private categoryService: CategoryService,
      private ingestService: IngestService
    ) { }

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
    this.categoryService.GetAllCategories().subscribe(s => {
      s.forEach((element: any) => {
        this.categorySrc.push({
          CategoryId : element.categoryId,
          Name : element.name
        });
      });
    });
  }

  Close() {
    this.ClearData();
    this.changeShow.emit();
  }
  Save() {
    this.ingestData.CardholderName = this.employeeSrc.find(element => element.EmployeeId == this.employeeSelect.EmployeeId)?.Name;
    this.ingestData.EmployeeId = this.employeeSelect.EmployeeId;
    this.ingestData.CardholderId = this.employeeSelect.EmployeeId;
    
    this.ingestService.PostIngest(this.ingestData).subscribe(s => {
      this.ClearData();
      this.Close();
    });
  }
  ClearData() {
    this.employeeSelect.Name = "";
    this.employeeSelect.PositionId = "";
    this.employeeSelect.EmployeeId = "";
    this.employeeSelect.ProductionUnitId = "";
    //this.employeeSelect = new Employee();
    this.ingestData = new Ingest();
  }
  Edit() {
    this.ingestData.CardholderName = this.employeeSrc.find(element => element.EmployeeId == this.employeeSelect.EmployeeId)?.Name;
    this.ingestData.EmployeeId = this.employeeSelect.EmployeeId;
    this.ingestData.CardholderId = this.employeeSelect.EmployeeId;
    // debugger
    this.ingestService.PutIngest(this.ingestData).subscribe(s => {
      this.ClearData();
      this.Close();
    });
  }

}
