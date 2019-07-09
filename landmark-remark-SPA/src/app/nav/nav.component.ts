import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(
    public authservice: AuthService, // user authentication service
    private alertify: AlertifyService, // inject AlertifyJs service
    private router: Router
  ) {}

  ngOnInit() {}

  // sends signIn credentials to authentication service & redirects user to 'remark' upon seccessful login
  login() {
    this.authservice.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in successfully');
      },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/remark']);
      }
    );
  }

  // returns whether user is logged in
  loggedIn() {
    return this.authservice.loggedIn();
  }

  // logouts user: removes and resets cached JWT token & redirects user to home
  logout() {
    if (this.loggedIn()) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      this.authservice.decodedToken = null;
      this.authservice.currentUser = null;
    }
    this.alertify.message('Logged out');
    this.router.navigate(['/home']);
  }
}
