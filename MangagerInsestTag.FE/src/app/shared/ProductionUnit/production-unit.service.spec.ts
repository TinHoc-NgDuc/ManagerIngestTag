import { TestBed } from '@angular/core/testing';

import { ProductionUnitService } from './production-unit.service';

describe('ProductionUnitService', () => {
  let service: ProductionUnitService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductionUnitService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
