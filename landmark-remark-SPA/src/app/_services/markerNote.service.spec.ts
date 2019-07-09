/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MarkerNoteService } from './markerNote.service';
import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';

describe('Service: MarkerNote', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [MarkerNoteService]
    });
  });

  it('should inject markerNote service', inject([MarkerNoteService], (service: MarkerNoteService) => {
    expect(service).toBeTruthy();
  }));
});
