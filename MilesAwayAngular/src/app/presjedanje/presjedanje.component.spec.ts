import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PresjedanjeComponent } from './presjedanje.component';

describe('PresjedanjeComponent', () => {
  let component: PresjedanjeComponent;
  let fixture: ComponentFixture<PresjedanjeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PresjedanjeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PresjedanjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
