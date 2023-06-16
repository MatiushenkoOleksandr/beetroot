import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonsComponentComponent } from './customersModule/persons.component/persons.component.component';
import { PersonsTableComponent } from './customersModule/persons-table/persons-table.component';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { NgFor, NgIf } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { CreateCarDialogComponent } from './carsModule/cars/create-car.dialog/create-car.dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { CreatePersonDialogComponent } from './customersModule/create-person.dialog/create-person.dialog.component';
import { CarsComponent } from './carsModule/cars/cars.component';
import { CarsTableComponent } from './carsModule/cars/cars-table/cars-table.component';
import { MatTabsModule } from '@angular/material/tabs';
import { AllCarsComponent } from './carsModule/all-cars/all-cars.component';
import { ReservationsComponent } from './reservations/reservations/reservations.component';
import { ReservationsTableComponent } from './reservations/reservations/reservations-table/reservations-table.component';
import { AddReservationComponent } from './reservations/add-reservation/add-reservation.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { UpdateCarDialogComponent } from './carsModule/update-car.dialog/update-car.dialog.component';
import { EditReservationComponent } from './reservations/edit-reservation/edit-reservation.component';
import { AppHeaderComponent } from './app-header/app-header.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonsComponentComponent,
    PersonsTableComponent,
    CarsComponent,
    CreateCarDialogComponent,
    CreatePersonDialogComponent,
    CarsTableComponent,
    AllCarsComponent,
    ReservationsComponent,
    ReservationsTableComponent,
    AddReservationComponent,
    UpdateCarDialogComponent,
    EditReservationComponent,
    AppHeaderComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    NgIf,
    NgFor,
    MatDialogModule,
    MatSelectModule,
    MatIconModule,
    MatTabsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
