import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  Car,
  Customer,
  FilterReservations,
  Reservation,
  ReservationListModel,
} from './httpModals';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  constructor(private http: HttpClient) {}
  getPersons() {
    return this.http.get<Customer[]>('https://localhost:7170/Customer');
  }
  getCustomersCars(id: string) {
    return this.http.get<Car[]>(`https://localhost:7170/Customer/${id}/cars`);
  }
  createCar(car: Car) {
    return this.http.post('https://localhost:7170/Car', car);
  }
  deleteCar(id: string) {
    return this.http.delete(`https://localhost:7170/Car/${id}`);
  }
  createPerson(customerModel: Customer) {
    return this.http.post('https://localhost:7170/Customer', customerModel);
  }
  deleteCustomer(id: string) {
    return this.http.delete(`https://localhost:7170/Customer/${id}`);
  }
  getCars() {
    return this.http.get<Car[]>('https://localhost:7170/Car');
  }

  getReservations(filterModel: FilterReservations) {
    const params = new HttpParams()
      .set('hourFrom', filterModel.hourFrom ?? '')
      .set('hourTo', filterModel.hourTo ?? '')
      .set('status', filterModel.status ?? '')
      .set(
        'date',
        !!filterModel.date ? moment(filterModel.date).format('yyyy-MM-DD') : ''
      )
      .set('paymentStatus', filterModel.paymentStatus ?? '')
      .set('carId', filterModel.carId ?? '');
    return this.http.get<ReservationListModel[]>(
      'https://localhost:7170/Reservation',
      { params }
    );
  }
  deleteReservation(id: string) {
    return this.http.delete(`https://localhost:7170/Reservation/${id}`);
  }
  saveReservation(reservation: Reservation) {
    console.log(reservation);

    let valueDate: string = moment(reservation.date).format('yyyy-MM-DD');
    reservation.date = valueDate;
    return this.http.post('https://localhost:7170/Reservation', reservation);
  }
  getCarById(id: string) {
    return this.http.get<Car>(`https://localhost:7170/Car/${id}`);
  }
  saveUpdateCar(car: Car) {
    return this.http.put('https://localhost:7170/Car', car);
  }
  getReservationById(id: string) {
    return this.http.get<Reservation>(
      `https://localhost:7170/Reservation/${id}`
    );
  }
  updateReservation(reservation: Reservation) {
    return this.http.put('https://localhost:7170/Reservation', reservation);
  }
}
