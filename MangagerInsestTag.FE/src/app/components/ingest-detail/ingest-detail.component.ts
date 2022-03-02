import { Component, EventEmitter, OnInit, Input, Output } from '@angular/core';

@Component({
  selector: 'app-ingest-detail',
  templateUrl: './ingest-detail.component.html',
  styleUrls: ['./ingest-detail.component.css']
})
export class IngestDetailComponent implements OnInit {
  @Input() isShow: boolean = false;
  @Output() change = new EventEmitter();
  constructor() { }
  ngOnInit(): void {

  }

  close() {
    //this.change.emit("");
  }

  public Empoyee = [
    { id: "1", name: "nhan viên 1" },
    { id: "2", name: "nhan viên 2" },
    { id: "3", name: "nhan viên 3" },
    { id: "4", name: "nhan viên 4" },
  ]
}
