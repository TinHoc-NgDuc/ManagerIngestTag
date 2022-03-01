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
}
