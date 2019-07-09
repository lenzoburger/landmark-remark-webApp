import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
// Injectble service for user authetication and registration
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;

  constructor(private http: HttpClient) {}

  // Sends POST request with user credentials & saves retured JWT Token and User object in localStorage
  login(userCred: any) {
    return this.http.post(this.baseUrl + 'login', userCred).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', JSON.stringify(user.userObject));
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.currentUser = user.userObject;
        }
      })
    );
  }

// Sends POST request new user form details
  register(user: any) {
    return this.http.post(this.baseUrl + 'register', user);
  }

// Checks if JWT token is expired or deleted from localStorage
  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
