import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '@services/auth.service';
import { Router } from '@angular/router';
import { Login } from '@classes/login.class';

import * as fromRoot from '../../../state/app.state';
import * as fromAuthActions from '../../../state/auth.actions';
import { Store } from '@ngrx/store';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  formInProgress: boolean;
  errorMessage: string;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private store: Store<fromRoot.State>
  ) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.form = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]]
    });
  }

  onLogin() {
    this.formInProgress = true;
    const data: Login = {
      email: this.form.value.email,
      password: this.form.value.password
    };
    this.authService.post(data).subscribe(
      (result) => {
        if(result.token) {
          this.formInProgress = false;
          this.store.dispatch(
            new fromAuthActions.SaveTokenToLocalStorage(result.token)
          );
          this.router.navigateByUrl('admin');
        }
      },
      (error) => {
        this.errorMessage = error.error.message;
        this.formInProgress = false;
      }
    );
  }
}
