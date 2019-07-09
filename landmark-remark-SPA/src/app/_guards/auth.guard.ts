import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
// prevents unauthorized access to whitelisted pages
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router, private altertify: AlertifyService) { }

  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }

    this.altertify.error('Unauthorized');
    this.router.navigate(['/home']);
    return false;
  }
}