import { Component, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '@services/auth.service';
import { Router } from '@angular/router';
import { Login } from '@classes/login.class';

import * as fromRoot from '@state/app.state';
import * as fromAuthActions from '@state/auth/auth.actions';
import * as fromAuthState from '@state/auth/auth.state';
import { Store, select } from '@ngrx/store';
import { takeWhile } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy {
  alive: boolean = true;
  form: FormGroup;
  formInProgress: boolean;
  errorMessage: string;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private store: Store<fromRoot.State>
  ) {
    this.checkRole();
    this.initForm();
  }

  checkRole() {
    this.store.pipe(select(fromAuthState.getUserRole), takeWhile(() => this.alive)).subscribe(role => {
      if(role && role.code && role.code == 'admin') {
        this.router.navigateByUrl('admin');
      }
    });
  }

  initForm() {
    this.form = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null]
    });
  }

  onLogin() {
    this.formInProgress = true;
    const data: Login = {
      email: this.form.value.email,
      password: this.form.value.password
    };
    this.authService.post(data).pipe(takeWhile(() => this.alive)).subscribe(
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

  ngOnDestroy() {
    this.alive = false;
  }
}
