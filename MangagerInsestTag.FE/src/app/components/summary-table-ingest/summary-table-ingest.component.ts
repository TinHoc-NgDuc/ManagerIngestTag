import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-summary-table-ingest',
  templateUrl: './summary-table-ingest.component.html',
  styleUrls: ['./summary-table-ingest.component.css']
})
export class SummaryTableIngestComponent implements OnInit {
  status = ['Thẻ đang tạo', 'Chờ duyệt'];
  constructor() { }

  ngOnInit(): void {
  }

}
