import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngestDetailComponent } from './ingest-detail.component';

describe('IngestDetailComponent', () => {
  let component: IngestDetailComponent;
  let fixture: ComponentFixture<IngestDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IngestDetailComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IngestDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
