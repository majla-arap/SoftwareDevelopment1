import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeMenadzerComponent } from './home-menadzer.component';

describe('HomeMenadzerComponent', () => {
  let component: HomeMenadzerComponent;
  let fixture: ComponentFixture<HomeMenadzerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeMenadzerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeMenadzerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
