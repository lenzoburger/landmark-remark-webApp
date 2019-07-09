import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    if (this.authService.loggedIn()) {
      this.router.navigate(['/remark']); // On initialization if user is logged in redirect to remark route
    }
  }

  // toggle appearance of landing page & registration forms
  registerToggle() {
    this.registerMode = true;
  }

   // Return to landing page
  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }
}
