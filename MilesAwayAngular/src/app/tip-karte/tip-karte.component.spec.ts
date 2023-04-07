import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipKarteComponent } from './tip-karte.component';

describe('TipKarteComponent', () => {
  let component: TipKarteComponent;
  let fixture: ComponentFixture<TipKarteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipKarteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TipKarteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
