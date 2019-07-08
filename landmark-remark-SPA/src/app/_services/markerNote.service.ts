import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MarkerNote } from '../_models/markerNote';

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
}
