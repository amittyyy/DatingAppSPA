import { TestBed } from '@angular/core/testing';

import { NugetService } from './nuget.service';

describe('NugetService', () => {
  let service: NugetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NugetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
