import { Component, Injector } from '@angular/core';
import { AuthenticationService } from '../auth/auth.service';
import { Role, User } from '../auth/userModel';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.scss'],
})
export abstract class BaseComponent {
  user?: User | null;
  authServisce: AuthenticationService;
  constructor(injector: Injector) {
    this.authServisce = injector.get(AuthenticationService);
    this.authServisce.user.subscribe((x) => (this.user = x));
  }

  get isAdmin(): boolean {
    return this.user?.role === Role.Admin;
  }
}
