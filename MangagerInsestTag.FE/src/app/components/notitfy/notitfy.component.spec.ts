import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotitfyComponent } from './notitfy.component';

describe('NotitfyComponent', () => {
  let component: NotitfyComponent;
  let fixture: ComponentFixture<NotitfyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotitfyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotitfyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
