import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagerIngestComponent } from './components/manager-ingest/manager-ingest.component';
import { SummaryTableIngestComponent } from './components/summary-table-ingest/summary-table-ingest.component';

const routes: Routes = [
  {path:"manageringest",component:ManagerIngestComponent},
  {path:"manageringesttag",component:SummaryTableIngestComponent}  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
