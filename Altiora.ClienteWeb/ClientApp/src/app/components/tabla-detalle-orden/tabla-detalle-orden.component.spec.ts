import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablaDetalleOrdenComponent } from './tabla-detalle-orden.component';

describe('TablaDetalleOrdenComponent', () => {
  let component: TablaDetalleOrdenComponent;
  let fixture: ComponentFixture<TablaDetalleOrdenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablaDetalleOrdenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablaDetalleOrdenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
