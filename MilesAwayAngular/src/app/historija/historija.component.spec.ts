import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistorijaComponent } from './historija.component';

describe('HistorijaComponent', () => {
  let component: HistorijaComponent;
  let fixture: ComponentFixture<HistorijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistorijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistorijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
