import { Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './auth/auth.service';
import { Role, User } from './auth/userModel';
import { BaseComponent } from './base/base.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent extends BaseComponent implements OnInit {
  navLinks: any[];
  navLinksToShow: any[] = [];

  navLinksAll = [
    {
      label: 'Customers',
      link: './customers',
      index: 0,
      onlyForAdmin: true,
    },
    {
      label: 'Cars',
      link: './cars',
      index: 1,
      onlyForAdmin: true,
    },
    {
      label: 'Reservations',
      link: './reservations',
      index: 2,
    },
  ];
  activeLinkIndex = -1;
  constructor(
    private router: Router,
    injector: Injector,
    private authService: AuthenticationService
  ) {
    super(injector);
    this.navLinks = [
      {
        label: 'Customers',
        link: './customers',
        index: 0,
        onlyForAdmin: true,
      },
      {
        label: 'Cars',
        link: './cars',
        index: 1,
        onlyForAdmin: true,
      },
      {
        label: 'Reservations',
        link: './reservations',
        index: 2,
      },
    ];
    this.authService.userLoggedIn.subscribe((a) => this.refreshTabs());
  }
  ngOnInit(): void {
    this.refreshTabs();
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(
        this.navLinks.find((tab) => tab.link === '.' + this.router.url)
      );
    });
  }

  refreshTabs() {
    if (this.user?.role !== Role.Admin) {
      this.navLinks = this.navLinksAll.filter((a) => !a.onlyForAdmin);
    } else {
      this.navLinks = this.navLinksAll;
    }
  }

  title = 'ServiceApp';
}
