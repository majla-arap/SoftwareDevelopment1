import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UspjesnaKupovinaComponent } from './uspjesna-kupovina.component';

describe('UspjesnaKupovinaComponent', () => {
  let component: UspjesnaKupovinaComponent;
  let fixture: ComponentFixture<UspjesnaKupovinaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UspjesnaKupovinaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UspjesnaKupovinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
