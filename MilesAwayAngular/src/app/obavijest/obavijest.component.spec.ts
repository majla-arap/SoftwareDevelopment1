import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObavijestComponent } from './obavijest.component';

describe('ObavijestComponent', () => {
  let component: ObavijestComponent;
  let fixture: ComponentFixture<ObavijestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObavijestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObavijestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
