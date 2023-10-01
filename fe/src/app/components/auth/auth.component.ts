import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { QueryService } from 'src/app/http/query.service';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
})
export class AuthComponent {
  public form: FormGroup = this.buildForm();

  public emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  public passwordControl = new FormControl('');

  public user;
  constructor(
    public fb: FormBuilder,
    public queryService: QueryService,
    private authService: AuthService
  ) {}

  public buildForm(): FormGroup {
    return this.fb.group({
      login: [],
      password: [],
    });
  }

  public onLogin(): void {
    const value = this.form.value;
    this.authService.user$.subscribe((success: any) => {
      this.user = success;
    });
  }
}
