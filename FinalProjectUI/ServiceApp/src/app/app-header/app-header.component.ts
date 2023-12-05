import { Component, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../auth/auth.service';
import { BaseComponent } from '../base/base.component';

@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.scss'],
})
export class AppHeaderComponent extends BaseComponent {
  constructor(
    private injector: Injector,
    private _router: Router,
    private authenticationService: AuthenticationService
  ) {
    super(injector);
  }

  navigateToLogin() {
    this._router.navigate(['login']);
  }

  logout() {
    this.authenticationService.logout();
  }
}
