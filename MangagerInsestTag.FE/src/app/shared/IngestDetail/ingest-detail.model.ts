import { Ingest } from "../Ingest/ingest.model";

export class IngestDetail {
    IngestDeltailId: string = '00000000-0000-0000-0000-000000000000';
    DateSend: string = '';
    DateReturn: string = '';
    RecipientName?: string = '';
    RecipientId: string = '';
    TakerName: string = '';
    TakerId: string = '';
    ticketIngestId: string = '';
    IngestTagId: string = '';
    IngestTag: Ingest = new Ingest();
}
