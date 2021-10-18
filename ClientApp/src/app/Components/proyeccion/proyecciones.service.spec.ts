import { TestBed } from '@angular/core/testing';

import { ProyeccionesService } from './proyecciones.service';

describe('ProyeccionesService', () => {
  let service: ProyeccionesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProyeccionesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
