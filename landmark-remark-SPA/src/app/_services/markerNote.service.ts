import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MarkerNote } from '../_models/markerNote';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
// Injectable service for retrieving and writing data for markernote api
export class MarkerNoteService {
  baseUrl = environment.apiUrl + 'markernote/';
  constructor(private http: HttpClient) {}

  // POST - add new MarkerNote to database
  createMarkerNote(markerNote: MarkerNote) {
    console.log(markerNote);
    return this.http.post(this.baseUrl + 'create', markerNote);
  }

  // GET all MarkerNotes from markernote api
  getMarkerNotes(): Observable<MarkerNote[]> {
    return this.http.get<MarkerNote[]>(this.baseUrl);
  }

  // GET MarkerNotes by searchstring[username or note content]
  searchMarkerNotes(searchString: string): Observable<MarkerNote[]> {
    return this.http.get<MarkerNote[]>(this.baseUrl + 'search/' + searchString);
  }
}
