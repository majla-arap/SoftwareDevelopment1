import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LetAerodromComponent } from './let-aerodrom.component';

describe('LetAerodromComponent', () => {
  let component: LetAerodromComponent;
  let fixture: ComponentFixture<LetAerodromComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LetAerodromComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LetAerodromComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
