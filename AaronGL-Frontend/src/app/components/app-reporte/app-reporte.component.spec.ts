import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppReporteComponent } from './app-reporte.component';

describe('AppReporteComponent', () => {
  let component: AppReporteComponent;
  let fixture: ComponentFixture<AppReporteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AppReporteComponent]
    });
    fixture = TestBed.createComponent(AppReporteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
