import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LetAvionComponent } from './let-avion.component';

describe('LetAvionComponent', () => {
  let component: LetAvionComponent;
  let fixture: ComponentFixture<LetAvionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LetAvionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LetAvionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
