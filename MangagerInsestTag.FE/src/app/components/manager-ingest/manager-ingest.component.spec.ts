import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerIngestComponent } from './manager-ingest.component';

describe('ManagerIngestComponent', () => {
  let component: ManagerIngestComponent;
  let fixture: ComponentFixture<ManagerIngestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagerIngestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerIngestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
