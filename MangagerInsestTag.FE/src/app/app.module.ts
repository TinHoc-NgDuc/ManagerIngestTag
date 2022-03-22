import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ManagerIngestComponent } from './components/manager-ingest/manager-ingest.component';
import { IngestDetailComponent } from './components/ingest-detail/ingest-detail.component';
import { SummaryTableIngestComponent } from './components/summary-table-ingest/summary-table-ingest.component';
import { IngestTagDetailComponent } from './components/ingest-tag-detail/ingest-tag-detail.component';
import { SubmitReturnTagComponent } from './components/submit-return-tag/submit-return-tag.component';
import { NavigationPanelComponent } from './components/navigation-panel/navigation-panel.component';
import { EmployeeService } from './shared/Employee/employee.service';
import { PositionService } from './shared/Position/position.service';
import { IngestService } from './shared/Ingest/ingest.service';
import { StatusIngestService } from './shared/StatusInges/status-ingest.service';
import { ProductionUnit } from './shared/ProductionUnit/production-unit.model';
import { ProgramShowService } from './shared/ProgramShow/program-show.service';
import { TopicService } from './shared/Topics/topic.service';
import { CategoryService } from './shared/Category/category.service';
import { HistoryIngestService } from './shared/HistoryIngest/history-ingest.service';
import { SummaryIngestService } from './shared/SummaryIngest/summary-ingest.service';
import { DatePipe } from '@angular/common';
import { NotitfyComponent } from './components/notitfy/notitfy.component';


@NgModule({
  declarations: [
    AppComponent,
    ManagerIngestComponent,
    IngestDetailComponent,
    SummaryTableIngestComponent,
    IngestTagDetailComponent,
    SubmitReturnTagComponent,
    NavigationPanelComponent,
    NotitfyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatCheckboxModule,
    MatSelectModule
  ],
  providers:
  [
    CategoryService,
    EmployeeService, 
    PositionService, 
    IngestService, 
    StatusIngestService, 
    ProductionUnit, 
    ProgramShowService,
    HistoryIngestService, 
    TopicService,
    SummaryIngestService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
