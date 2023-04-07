import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeKupacComponent } from './home-kupac.component';

describe('HomeKupacComponent', () => {
  let component: HomeKupacComponent;
  let fixture: ComponentFixture<HomeKupacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeKupacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeKupacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
