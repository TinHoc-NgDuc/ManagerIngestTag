import { IngestDetail } from "../IngestDetail/ingest-detail.model";
import { TicketIngest } from "../TicketIngest/ticket-ingest.model";

export class SummaryIngest {
    ticketIngest: TicketIngest = new TicketIngest();
    ingestDetail: IngestDetail[] =[];
}
