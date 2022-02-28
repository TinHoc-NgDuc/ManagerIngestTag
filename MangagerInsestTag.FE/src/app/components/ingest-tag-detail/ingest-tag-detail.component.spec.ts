import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngestTagDetailComponent } from './ingest-tag-detail.component';

describe('IngestTagDetailComponent', () => {
  let component: IngestTagDetailComponent;
  let fixture: ComponentFixture<IngestTagDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IngestTagDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IngestTagDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
