import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipPutnikaComponent } from './tip-putnika.component';

describe('TipPutnikaComponent', () => {
  let component: TipPutnikaComponent;
  let fixture: ComponentFixture<TipPutnikaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipPutnikaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TipPutnikaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
