/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MarkerNoteService } from './markerNote.service';

describe('Service: MarkerNote', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MarkerNoteService]
    });
  });

  it('should ...', inject([MarkerNoteService], (service: MarkerNoteService) => {
    expect(service).toBeTruthy();
  }));
});
