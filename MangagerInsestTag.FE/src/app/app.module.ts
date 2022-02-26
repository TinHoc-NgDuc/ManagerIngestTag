import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ManagerIngestComponent } from './components/manager-ingest/manager-ingest.component';
import { IngestDetailComponent } from './components/ingest-detail/ingest-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    ManagerIngestComponent,
    IngestDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
