import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MarkerNote } from '../_models/markerNote';
import { AuthService } from '../_services/auth.service';
import { MarkerNoteService } from '../_services/markerNote.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-remark',
  templateUrl: './remark.component.html',
  styleUrls: ['./remark.component.css']
})

// Component for rendering map & container for interaction methods
export class RemarkComponent implements OnInit {
  lat: number; // current map location in view
  lng: number; // current map location in view
  homeLat: number; // current user location marker coords
  homeLng: number; // current user location marker coords
  addNoteMode = false; // Toggle add note to current location form
  noteForm: FormGroup; // Add not reactive form
  markerNote: MarkerNote; // MarkerNote instance to hold add note form data
  savedMarkers: MarkerNote[]; // marker notes retrived from API
  currentUserId: number;

  constructor(
    private markerNoteService: MarkerNoteService,
    private authService: AuthService,
    private fb: FormBuilder,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.currentUserId = this.authService.currentUser.id;
    this.getCurrentLocation(); // Get current location set to current view on map
    this.createNoteForm(); // Create reactive createNoteForm

    this.route.data.subscribe(data => {
      this.savedMarkers = data.savedMarkers;
    });
  }

  // Set coordinates to where user clicks and place marker -- Disabled temporarily
  placeMarker(location) {
    this.lat = location.coords.lat;
    this.lng = location.coords.lng;
  }

  // get user's current location and set coordinates
  getCurrentLocation() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(location => {
        this.lat = location.coords.latitude;
        this.lng = location.coords.longitude;
        this.homeLat = this.lat;
        this.homeLng = this.lng;
      });
    } else {
      this.alertify.warning('Unable to get location');
    }
  }

  // toggle addNotes form display
  addNoteToggle() {
    this.addNoteMode = !this.addNoteMode;
  }

  // formuilder for creating marker note
  createNoteForm() {
    this.noteForm = this.fb.group({
      note: ['', [Validators.required]]
    });
  }

  // onSubmit, create new MarkerNote instance and persist to db via API
  createMarkerNote() {
    this.markerNote = Object.assign({}, this.noteForm.value);
    this.markerNote.latitude = this.homeLat;
    this.markerNote.longitude = this.homeLng;
    this.markerNoteService.createMarkerNote(this.markerNote).subscribe(
      () => {
        this.alertify.success('Note created successfully');
        this.noteForm.reset();
        this.addNoteToggle();
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
