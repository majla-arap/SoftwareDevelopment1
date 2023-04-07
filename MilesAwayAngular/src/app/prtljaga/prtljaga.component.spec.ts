import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrtljagaComponent } from './prtljaga.component';

describe('PrtljagaComponent', () => {
  let component: PrtljagaComponent;
  let fixture: ComponentFixture<PrtljagaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrtljagaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrtljagaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
