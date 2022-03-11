import { Ingest } from "../ingest/ingest.model";

export class IngestDetail {
    IngestDeltailId: string = '00000000-0000-0000-0000-000000000000';
    TicketIngestId: string = '';
    EmployeeSendId: string = '00000000-0000-0000-0000-000000000000';
    EmployeeSend: string = '';
    EmployeeReceiveId: string = '00000000-0000-0000-0000-000000000000';
    EmployeeReceive?: string = '';
    DateSend: string = '';
    DateReceive: string = '';
    Recipient: string = '';
    Ingestid: string = '00000000-0000-0000-0000-000000000000';
    Ingest: Ingest = new Ingest();
}
