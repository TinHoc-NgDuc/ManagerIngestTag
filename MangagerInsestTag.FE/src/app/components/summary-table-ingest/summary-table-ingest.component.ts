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


@Component({
  selector: 'app-summary-table-ingest',
  templateUrl: './summary-table-ingest.component.html',
  styleUrls: ['./summary-table-ingest.component.css']
})
export class SummaryTableIngestComponent implements OnInit {
  statusIngests: StatusIngest[] = [];
  statusSelect: StatusIngest = new StatusIngest();
  employeeSrc: Employee[] = [];
  positionSrc: Position[] = [];
  productionUnitSrc: ProductionUnitService[] = [];
  productionUnitSelect: ProductionUnit = new ProductionUnit();
  constructor(
    private statusIngestService: StatusIngestService,
    private employeeService: EmployeeService,
    private positionService: PositionService,
    private ingestService: IngestService,
    private productionUnitService: ProductionUnitService,
  ) { }

  ngOnInit(): void {
    this.statusIngestService.GetAllStatus().subscribe(s => {
      s.forEach((element: any) => {
        this.statusIngests.push({
          StatusIngestId: element.statusInges,
          Name: element.name,
          StatusCode: element.statusCode
        });
      });
    });

    // this.employeeService.GetAllEmployee().subscribe(s => {
    //   s.forEach((element: any) => {
    //     this.employeeSrc.push({
    //       EmployeeId: element.employeeId,
    //       Name: element.name,
    //       PositionId: element.positionId,
    //       ProductionUnitId: element.productionUnitId,
    //     });
    //   });
    // });
    // this.positionService.GetAllPositions().subscribe(s => {
    //   s.forEach((element: any) => {
    //     this.positionSrc.push({
    //       PositionId: element.positionId,
    //       Name: element.name
    //     });
    //   });
    // });

    // this.productionUnitService.GetAllProductionUnits().subscribe(s => {
    //   s.forEach((element: any) => {
    //     console.log(element);
    //   });
    // });
  }

}
