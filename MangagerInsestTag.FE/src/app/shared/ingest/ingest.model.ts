export class Ingest {
    IngestTagId: string = '00000000-0000-0000-0000-000000000000';
    IngestCode?: string = '';
    Name: string = '';
    Note: string = '';
    Status: boolean = false;
    CategoryId: string = '';
    CategoryName : string = '';
    CardholderId: string = '';
    EmployeeId: string = '';
    CardholderName?: string = '';
}
export class IngestCreate extends Ingest{
    ingestInTicket : Ingest = new Ingest();
}