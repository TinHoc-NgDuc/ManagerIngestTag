import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubmitReturnTagComponent } from './submit-return-tag.component';

describe('SubmitReturnTagComponent', () => {
  let component: SubmitReturnTagComponent;
  let fixture: ComponentFixture<SubmitReturnTagComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubmitReturnTagComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubmitReturnTagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
