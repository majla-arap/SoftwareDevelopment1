import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KupovinaKarticaComponent } from './kupovina-kartica.component';

describe('KupovinaKarticaComponent', () => {
  let component: KupovinaKarticaComponent;
  let fixture: ComponentFixture<KupovinaKarticaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KupovinaKarticaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KupovinaKarticaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
