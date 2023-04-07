import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipPrtljageComponent } from './tip-prtljage.component';

describe('TipPrtljageComponent', () => {
  let component: TipPrtljageComponent;
  let fixture: ComponentFixture<TipPrtljageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipPrtljageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TipPrtljageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
