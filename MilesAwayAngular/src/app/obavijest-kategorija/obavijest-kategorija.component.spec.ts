import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObavijestKategorijaComponent } from './obavijest-kategorija.component';

describe('ObavijestKategorijaComponent', () => {
  let component: ObavijestKategorijaComponent;
  let fixture: ComponentFixture<ObavijestKategorijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObavijestKategorijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObavijestKategorijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
