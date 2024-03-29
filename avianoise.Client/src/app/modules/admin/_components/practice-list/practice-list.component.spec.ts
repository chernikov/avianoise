import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticeListComponent } from './post-list.component';

describe('PracticeListComponent', () => {
  let component: PracticeListComponent;
  let fixture: ComponentFixture<PracticeListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PracticeListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
