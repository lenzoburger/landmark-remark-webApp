import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-remark',
  templateUrl: './remark.component.html',
  styleUrls: ['./remark.component.css']
})
export class RemarkComponent implements OnInit {
  lat: number;
  lng: number;
  homeLat: number;
  homeLng: number;

  constructor(private alertify: AlertifyService) {}

  ngOnInit() {
    this.getCurrentLocation();
  }

  // Set coordinates to where to user clicks and place marker
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
}
