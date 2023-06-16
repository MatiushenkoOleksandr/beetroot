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
  treatmentDate = new FormControl(new Date());
  selectedTreatmentDate: Date | null = null;

  constructor(private fb: FormBuilder, private _httpService: HttpService) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      date: [null],
      hour: [null],
      price: [null],
      status: [null],
      paymentStatus: [null],
      prepaidAmount: [null],
      carId: [null],
      treatmentDate: this.treatmentDate,
    });
    this.treatmentDate.valueChanges.subscribe((v) => {
      this.selectedTreatmentDate = v;
      console.log(v);
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
    console.log(this.selectedTreatmentDate);
    if (!!this.selectedTreatmentDate) {
      value.date = this.selectedTreatmentDate;
      console.log(value.date);
    }
    var date = moment(value.date);
    value.date = date.toDate();
    this._httpService.saveReservation(value).subscribe();
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
