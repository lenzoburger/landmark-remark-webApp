import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of, pipe } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MarkerNote } from '../_models/markerNote';
import { MarkerNoteService } from '../_services/markerNote.service';

@Injectable()
export class MarkerNotesResolver implements Resolve<MarkerNote[]> {
  constructor(
    private markerNoteService: MarkerNoteService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<MarkerNote[]> {
    return this.markerNoteService.getMarkerNotes().pipe(
      catchError(error => {
        this.alertify.error('Problem retrieving data');
        return of(null);
      })
    );
  }
}
