import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngestDeltalComponent } from './ingest-deltal.component';

describe('IngestDeltalComponent', () => {
  let component: IngestDeltalComponent;
  let fixture: ComponentFixture<IngestDeltalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IngestDeltalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IngestDeltalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
