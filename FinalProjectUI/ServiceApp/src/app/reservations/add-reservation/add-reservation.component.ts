import { SelectInput } from './../../common/models/selectInput';
import { Component } from '@angular/core';
import * as moment from 'moment';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import {
  Car,
  PaymentStatus,
  Reservation,
  ReservationStatus,
} from 'src/app/httpModals';
import { HttpService } from 'src/app/http.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.scss'],
})
export class AddReservationComponent {
  form: FormGroup = new FormGroup({});
  flag: boolean = true;
  cars: Car[] = [];
  carInputOptions: SelectInput<string>[] = [];

  constructor(
    private fb: FormBuilder,
    private _httpService: HttpService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      price: [null, [Validators.required]],
      hour: [
        null,
        [Validators.required, Validators.min(0), Validators.max(24)],
      ],
      paymentStatus: [null, [Validators.required]],
      status: [null, [Validators.required]],
      prepaidAmount: [null],
      carId: [null],
      id: [null],
      date: [null],
      comments: [null],
    });

    this._httpService.getCars().subscribe((result) => {
      this.cars = result;
      this.carInputOptions = result.map((a) => {
        return {
          value: a.id ?? '',
          viewValue: `${a.brand} - ${a.model}, ${a.vin}`,
        };
      });
    });
  }

  onSave(hui: any) {
    let value = hui.value as Reservation;

    var date = moment(value.date);
    value.date = date.toDate();
    this._httpService.saveReservation(value).subscribe((a) => {
      this.router.navigate([`reservations`]);
    });
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
