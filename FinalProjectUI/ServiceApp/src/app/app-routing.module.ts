import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarsComponent } from './carsModule/cars/cars.component';
import { PersonsComponentComponent } from './customersModule/persons.component/persons.component.component';
import { AllCarsComponent } from './carsModule/all-cars/all-cars.component';
import { ReservationsComponent } from './reservations/reservations/reservations.component';
import { AddReservationComponent } from './reservations/add-reservation/add-reservation.component';
import { EditReservationComponent } from './reservations/edit-reservation/edit-reservation.component';
import { LoginComponent } from './auth/login/login.component';
import { Role } from './auth/userModel';
import { AuthGuard } from './auth/auth-guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/customers',
    pathMatch: 'full',
  },
  {
    data: { roles: [Role.Admin] },
    canActivate: [AuthGuard],
    path: 'customers/:id/cars',
    component: CarsComponent,
  },
  {
    data: { roles: [Role.Admin] },
    canActivate: [AuthGuard],
    path: 'customers',
    component: PersonsComponentComponent,
  },
  {
    path: 'cars',
    component: AllCarsComponent,
    data: { roles: [Role.Admin] },
    canActivate: [AuthGuard],
  },
  {
    path: 'reservations',
    component: ReservationsComponent,
    canActivate: [AuthGuard],
  },
  {
    data: { roles: [Role.Admin] },
    canActivate: [AuthGuard],
    path: 'reservations/add',
    component: AddReservationComponent,
  },
  {
    data: { roles: [Role.Admin] },
    canActivate: [AuthGuard],
    path: 'reservations/:id/edit',
    component: EditReservationComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },

  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
