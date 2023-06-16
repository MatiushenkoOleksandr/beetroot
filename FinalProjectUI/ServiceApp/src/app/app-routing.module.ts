import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarsComponent } from './carsModule/cars/cars.component';
import { PersonsComponentComponent } from './customersModule/persons.component/persons.component.component';
import { AllCarsComponent } from './carsModule/all-cars/all-cars.component';
import { ReservationsComponent } from './reservations/reservations/reservations.component';
import { AddReservationComponent } from './reservations/add-reservation/add-reservation.component';
import { EditReservationComponent } from './reservations/edit-reservation/edit-reservation.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/customers',
    pathMatch: 'full',
  },
  {
    path: 'customers/:id/cars',
    component: CarsComponent,
  },
  {
    path: 'customers',
    component: PersonsComponentComponent,
  },
  {
    path: 'cars',
    component: AllCarsComponent,
  },
  {
    path: 'reservations',
    component: ReservationsComponent,
  },
  {
    path: 'reservations/add',
    component: AddReservationComponent,
  },
  {
    path: 'reservations/:id/edit',
    component: EditReservationComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
