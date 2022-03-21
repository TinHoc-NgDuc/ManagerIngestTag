import { EventEmitter, Component, Input, OnInit, Output } from '@angular/core';
import { Employee } from 'src/app/shared/Employee/employee.model';
import { EmployeeService } from 'src/app/shared/Employee/employee.service';
import { TicketIngestFull } from 'src/app/shared/TicketIngest/ticket-ingest.model';
import { TicketIngestService } from 'src/app/shared/TicketIngest/ticket-ingest.service';

@Component({
  selector: 'app-submit-return-tag',
  templateUrl: './submit-return-tag.component.html',
  styleUrls: ['./submit-return-tag.component.css']
})
export class SubmitReturnTagComponent implements OnInit {
  @Input() isShowSubmit: boolean = true;
  @Input() passLogin: boolean = false;
  @Input() ticketIngest: TicketIngestFull = new TicketIngestFull();
  @Input() employeeTaker: Employee = new Employee();
  @Output() changeShowSubmit = new EventEmitter();
  @Output() changeStateShow = new EventEmitter();
  forgetPassword: boolean = false;
  constructor(
    private employeeService: EmployeeService,
    private ticketIngestService: TicketIngestService
  ) { }

  ngOnInit(): void { }
  Close() {
    this.changeShowSubmit.emit();
  }
  Login() {
    // this.passLogin = true;
    // this.changeStateShow.emit(this.passLogin);
    this.employeeService.PostCheckUser(this.employeeTaker).subscribe(s => {
      if (s) {
        this.passLogin = true;
        this.changeStateShow.emit(this.passLogin);
      }
      else{
        this.passLogin = false;
        this.changeStateShow.emit(this.passLogin);
      }
    });
  }
}
