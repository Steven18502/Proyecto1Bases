import { TestBed } from '@angular/core/testing';

import { CinetecService } from './cinetec.service';

describe('CinetecService', () => {
  let service: CinetecService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CinetecService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
