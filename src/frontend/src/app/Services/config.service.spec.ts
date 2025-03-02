import { TestBed } from '@angular/core/testing';

import { ConfigService } from './config.service';

describe('ConfigService', () => {
  let service: ConfigService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConfigService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('inserted key-value should be fetchable', () => {
    service.setConfig("foo", "bar");
    const value = service.getConfig("foo");
    expect(value).toBe("bar");
  });
});
