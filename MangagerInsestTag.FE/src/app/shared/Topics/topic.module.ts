export class Topic {
    TopicId: string = '00000000-0000-0000-0000-000000000000';
    Name: string = '';
    ProgramName: string = '';
    CameramanName: string = '';
    ProductionName: string = '';
    ReporterName: string = '';
    CreateName: string = '';
    IsReporting: boolean = false;
    IsNew: boolean = false;
    IsCategory: boolean = false;
    IsOtherProgram: boolean = false;
}
export class TopicFilter extends Topic {
    IsShow: boolean = false;
}