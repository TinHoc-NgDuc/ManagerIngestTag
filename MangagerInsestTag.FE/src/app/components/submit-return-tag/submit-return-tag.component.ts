import { EventEmitter, Component, Input, OnInit, Output } from '@angular/core';
import { Employee } from 'src/app/shared/Employee/employee.model';
import { EmployeeService } from 'src/app/shared/Employee/employee.service';
import { IngestService } from 'src/app/shared/Ingest/ingest.service';
import { IngestDetailService } from 'src/app/shared/IngestDetail/ingest-detail.service';
import { PositionService } from 'src/app/shared/Position/position.service';
import { TicketIngestFull } from 'src/app/shared/TicketIngest/ticket-ingest.model';
import { TicketIngestService } from 'src/app/shared/TicketIngest/ticket-ingest.service';
import { UserLogin } from 'src/app/shared/UserLogin/user-login.model';
import { UserLoginService } from 'src/app/shared/UserLogin/user-login.service';

@Component({
  selector: 'app-submit-return-tag',
  templateUrl: './submit-return-tag.component.html',
  styleUrls: ['./submit-return-tag.component.css']
})
export class SubmitReturnTagComponent implements OnInit {
  @Input() isShowSubmit: boolean = true;
  @Input() ticketIngest: TicketIngestFull = new TicketIngestFull();
  @Input() employeeTaker: Employee = new Employee();
  @Output() changeShowSubmit = new EventEmitter();

  userLogin: UserLogin = new UserLogin();
  forgetPassword: boolean = false;
  constructor(
    private employeeService: EmployeeService,
    private positionService: PositionService,
    private ingestService: IngestService,
    private ticketIngestService: TicketIngestService,
    private ingestDetailService: IngestDetailService,
    public userLoginService: UserLoginService
  ) { }

  ngOnInit(): void { }
  Close() {
    this.changeShowSubmit.emit();
  }
  Login() {

  }
}
