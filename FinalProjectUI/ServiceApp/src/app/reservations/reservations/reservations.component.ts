import { HttpService } from 'src/app/http.service';
import { Component, OnInit } from '@angular/core';
import {
  FilterReservations,
  PaymentStatus,
  ReservationListModel,
  ReservationStatus,
} from 'src/app/httpModals';
import { Router } from '@angular/router';
import { SelectInput } from 'src/app/common/models/selectInput';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.scss'],
})
export class ReservationsComponent implements OnInit {
  constructor(private HttpService: HttpService, private router: Router) {}
  carInputOptions: SelectInput<string>[] = [];
  filterModel: FilterReservations = {
    carId: undefined,
    hourFrom: undefined,
    hourTo: undefined,
    date: undefined,
    paymentStatus: undefined,
    status: undefined,
  };

  hourFromFilter: number | undefined = undefined;
  reservations: ReservationListModel[] = [];

  ngOnInit(): void {
    this.refreshReservations();
    this.HttpService.getCars().subscribe((result) => {
      this.carInputOptions = result.map((a) => {
        return {
          value: a.id ?? '',
          viewValue: `${a.brand} - ${a.model}, ${a.vin}`,
        };
      });
    });
  }
  refreshReservations() {
    this.HttpService.getReservations(this.filterModel).subscribe((result) => {
      this.reservations = result;
    });
  }
  addReservation() {
    this.router.navigate([`reservations/add`]);
  }
  applyFilter() {
    this.refreshReservations();
  }
  statusOptions: SelectInput<ReservationStatus>[] = [
    {
      viewValue: 'Just Arrived',
      value: ReservationStatus.JustArrived,
    },
    {
      viewValue: 'Completed',
      value: ReservationStatus.Completed,
    },
    {
      viewValue: 'In Progress',
      value: ReservationStatus.InProgress,
    },
    {
      viewValue: 'Waiting For Customer',
      value: ReservationStatus.WaitingForCustomer,
    },
  ];

  paymentStatusOptions: SelectInput<PaymentStatus>[] = [
    {
      viewValue: 'Paid',
      value: PaymentStatus.Paid,
    },
    {
      viewValue: 'Partly Paid',
      value: PaymentStatus.PartlyPaid,
    },
    {
      viewValue: 'Not Paid',
      value: PaymentStatus.NotPaid,
    },
  ];
}
