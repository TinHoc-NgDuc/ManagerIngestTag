export class StatusIngest {
    StatusIngestId: string = '';
    StatusCode: string = '';
    Name: string = '';
}

export class StatusFilter extends StatusIngest {
    isShow : boolean = false;
}