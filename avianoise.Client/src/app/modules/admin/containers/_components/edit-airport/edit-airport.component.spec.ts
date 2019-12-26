import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditAirportComponent } from './edit-airport.component';

describe('EditAirportComponent', () => {
  let component: EditAirportComponent;
  let fixture: ComponentFixture<EditAirportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditAirportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditAirportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
