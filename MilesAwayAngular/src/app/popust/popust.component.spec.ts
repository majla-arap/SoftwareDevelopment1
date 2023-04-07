import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopustComponent } from './popust.component';

describe('PopustComponent', () => {
  let component: PopustComponent;
  let fixture: ComponentFixture<PopustComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PopustComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PopustComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
