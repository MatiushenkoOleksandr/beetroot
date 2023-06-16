import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  PaymentStatus,
  Reservation,
  ReservationStatus,
} from 'src/app/httpModals';
import { HttpService } from 'src/app/http.service';
import * as moment from 'moment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reservations-table',
  templateUrl: './reservations-table.component.html',
  styleUrls: ['./reservations-table.component.scss'],
})
export class ReservationsTableComponent {
  constructor(private HttpService: HttpService, private router: Router) {}
  @Input() reservations: Reservation[] = [];
  displayedColumns = [
    'date',
    'hour',
    'price',
    'status',
    'paymentStatus',
    'prepaidAmount',
    'car',
    'customerName',
    'customerPhone',
    'delete',
  ];
  @Output() onReservationDeleted: EventEmitter<any> = new EventEmitter();

  getElementsDateString(date: Date): string {
    let valueDate: string = moment(date).format('yyyy-MM-DD');
    return valueDate;
  }

  getStatusString(status: number): string {
    return ReservationStatus[status];
  }
  getPaymentStatusString(status: number): string {
    return PaymentStatus[status];
  }
  deleteReservation(id: string) {
    this.HttpService.deleteReservation(id).subscribe(() => {
      this.onReservationDeleted.emit(null);
    });
  }
  tableElementClicked(id: string) {
    this.router.navigate([`reservations/${id}/edit`]);
  }
}
