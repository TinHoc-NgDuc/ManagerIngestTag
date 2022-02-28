import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SummaryTableIngestComponent } from './summary-table-ingest.component';

describe('SummaryTableIngestComponent', () => {
  let component: SummaryTableIngestComponent;
  let fixture: ComponentFixture<SummaryTableIngestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SummaryTableIngestComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SummaryTableIngestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
