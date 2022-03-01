import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manager-ingest',
  templateUrl: './manager-ingest.component.html',
  styleUrls: ['./manager-ingest.component.css']
})
export class ManagerIngestComponent implements OnInit {

  constructor() { }

  isShowAdd: boolean = false;
  ngOnInit(): void {
  }

  changeShowAdd(){
    this.isShowAdd = !this.isShowAdd;
  }
}
