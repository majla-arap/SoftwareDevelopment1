import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AviokompanijaComponent } from './aviokompanija.component';

describe('AviokompanijaComponent', () => {
  let component: AviokompanijaComponent;
  let fixture: ComponentFixture<AviokompanijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AviokompanijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AviokompanijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
