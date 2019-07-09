import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User } from '../_models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  user: User;
  registerForm: FormGroup;

  constructor(private authservice: AuthService, private alertify: AlertifyService,
              private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.createRegistrationForm(); // create registerForm on component init
  }

  // Build and Validate RegistrationForm
  createRegistrationForm() {
    this.registerForm = this.fb.group(
      {
        email: ['', [Validators.required, Validators.email]],
        username: ['', [Validators.required, Validators.pattern('[a-zA-Z0-9-_&\.]*')]],
        password: ['', [Validators.required, Validators.minLength(8),
          Validators.maxLength(20), Validators.pattern('[a-zA-Z 0-9-_&()\*\^%\$#@!+]*')]],
        confirmPassword: ['', Validators.required]
      },
      { validators: this.passwordMatchValidator });
  }

  // Verify user has supplied matching password in confirm password field
  passwordMatchValidator(form: FormGroup) {
    return form.get('password').value === form.get('confirmPassword').value ? null : { mismatch: true };
  }

// OnSubmit : Send user details to authservice & handle errors & redirect to 'remark' route upon succesfull registration
  register() {
    if (this.registerForm.valid) {
      this.user = Object.assign({}, this.registerForm.value);
      this.authservice.register(this.user).subscribe(() => {
        this.alertify.success('Registration successful');
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.authservice.login(this.user).subscribe(() => {
          this.router.navigate(['/remark']);
        });
      });
    }
  }

  // emit cancel event back to 'home' componet & return user to landing page
  cancel() {
    this.cancelRegister.emit(false);
  }

}
