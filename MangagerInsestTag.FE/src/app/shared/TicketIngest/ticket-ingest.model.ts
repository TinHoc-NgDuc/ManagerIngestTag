import { IngestDetail } from "../IngestDetail/ingest-detail.model";

export class TicketIngest {
    TicketIngestId: string  = '00000000-0000-0000-0000-000000000000';
    Name: string = '';
    CreateName: string = '';
    TopicName: string = '';
    ProgramName: string = '';
    CameramanName: string = '';
    ProductionName: string = '';
    ReporterName: string = '';
    SaveDocument: string = '';
    IsReporting: boolean = false;
    IsNew: boolean = false;
    IsCategory: boolean = false;
    IsOtherProgram: boolean = false;
    StatusIngestCode: string = '';
    StatusIngest: string = '';
    DateCreate: Date = new Date();
}
export class TicketIngestFull extends TicketIngest{
    IngestDetailFull: IngestDetail[] = [];
}