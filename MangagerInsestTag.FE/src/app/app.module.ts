import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ManagerIngestComponent } from './components/manager-ingest/manager-ingest.component';
import { IngestDetailComponent } from './components/ingest-detail/ingest-detail.component';
import { SummaryTableIngestComponent } from './components/summary-table-ingest/summary-table-ingest.component';
import { IngestTagDetailComponent } from './components/ingest-tag-detail/ingest-tag-detail.component';
import { SubmitReturnTagComponent } from './components/submit-return-tag/submit-return-tag.component';
import { NavigationPanelComponent } from './components/navigation-panel/navigation-panel.component';
import { CategoryService } from './shared/category/category.service';

@NgModule({
  declarations: [
    AppComponent,
    ManagerIngestComponent,
    IngestDetailComponent,
    SummaryTableIngestComponent,
    IngestTagDetailComponent,
    SubmitReturnTagComponent,
    NavigationPanelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [CategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
