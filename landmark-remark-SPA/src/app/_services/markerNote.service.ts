import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MarkerNote } from '../_models/markerNote';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MarkerNoteService {
  baseUrl = environment.apiUrl + 'markernote/';
  constructor(private http: HttpClient) {}

  createMarkerNote(markerNote: MarkerNote) {
    console.log(markerNote);
    return this.http.post(this.baseUrl + 'create', markerNote);
  }

  getMarkerNotes(): Observable<MarkerNote[]> {
    return this.http.get<MarkerNote[]>('http://localhost:5000/api/markernote');
  }
}
