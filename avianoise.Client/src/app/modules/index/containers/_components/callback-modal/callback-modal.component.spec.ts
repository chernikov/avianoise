import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CallbackModalComponent } from './callback-modal.component';

describe('CallbackModalComponent', () => {
  let component: CallbackModalComponent;
  let fixture: ComponentFixture<CallbackModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CallbackModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CallbackModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
