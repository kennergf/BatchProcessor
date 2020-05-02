import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultBatchComponent } from './consult-batch.component';

describe('ConsultBatchComponent', () => {
  let component: ConsultBatchComponent;
  let fixture: ComponentFixture<ConsultBatchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultBatchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultBatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
