import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})

// Third-party alertifyjs service - for displaying alerts on screen
export class AlertifyService {
  constructor() {}

  confirm(message: string, okCallback: () => any) {
    alertify.confirm(message, e => {
      if (e) {
        okCallback();
      } else {
      }
    });
  }

  // green box success message
  success(message: string) {
    alertify.success(message);
  }

  // red box error message
  error(message: string) {
    alertify.error(message);
  }

  // orange box warning message
  warning(message: string) {
    alertify.warning(message);
  }

 // white box warning message
  message(message: string) {
    alertify.message(message);
  }
}
