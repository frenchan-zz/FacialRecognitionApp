import { TestBed, inject } from '@angular/core/testing';

import { PersonGroupService } from './person-group.service';

describe('PersonGroupService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PersonGroupService]
    });
  });

  it('should be created', inject([PersonGroupService], (service: PersonGroupService) => {
    expect(service).toBeTruthy();
  }));
});
