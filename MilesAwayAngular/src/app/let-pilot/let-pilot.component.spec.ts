import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LetPilotComponent } from './let-pilot.component';

describe('LetPilotComponent', () => {
  let component: LetPilotComponent;
  let fixture: ComponentFixture<LetPilotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LetPilotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LetPilotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
