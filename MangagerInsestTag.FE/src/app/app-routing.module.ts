import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagerIngestComponent } from './components/manager-ingest/manager-ingest.component';

const routes: Routes = [
  {path:"manageringest",component:ManagerIngestComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
