import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoiseInfoComponent } from './noise-info.component';

describe('NoiseInfoComponent', () => {
  let component: NoiseInfoComponent;
  let fixture: ComponentFixture<NoiseInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoiseInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoiseInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
