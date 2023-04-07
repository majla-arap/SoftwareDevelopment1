import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KupovinaLetComponent } from './kupovina-let.component';

describe('KupovinaLetComponent', () => {
  let component: KupovinaLetComponent;
  let fixture: ComponentFixture<KupovinaLetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KupovinaLetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KupovinaLetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
