import { HistoryIngest } from "../HistoryIngest/history-ingest.model";
import { IngestDetail } from "../IngestDetail/ingest-detail.model";
import { TicketIngestFull } from "../TicketIngest/ticket-ingest.model";

export class SummaryIngest {
    ticketIngest: TicketIngestFull = new TicketIngestFull();
    ingestDetail: IngestDetail[] = [];
    HistoryIngest: HistoryIngest[] =[];
}
