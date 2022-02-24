import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ManagerIngestComponent } from './components/manager-ingest/manager-ingest.component';
import { IngestDeltalComponent } from './components/ingest-deltal/ingest-deltal.component';

@NgModule({
  declarations: [
    AppComponent,
    ManagerIngestComponent,
    IngestDeltalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
