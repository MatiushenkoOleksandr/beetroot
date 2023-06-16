export class Customer {
  name: string;
  surname: string;
  phoneNumber: string;
  id: string | undefined;
  constructor(
    _name: string,
    _surname: string,
    _phoneNumber: string,
    _id: string | undefined
  ) {
    this.name = _name;
    this.surname = _surname;
    this.phoneNumber = _phoneNumber;
    this.id = _id;
  }
}
export class Car {
  constructor(
    public vin: string,
    public clientId: string,
    public id: string | undefined,
    public milage: number,
    public brand: string,
    public model: string,
    public year: number,
    public fuelType: FuelType
  ) {}
}
export enum FuelType {
  Petrol,
  Diesel,
  LPG,
  Hybrid,
  Electric,
}
export class ReservationListModel {
  constructor(
    public id: string,
    public date: Date,
    public hour: number,
    public price: number,
    public status: ReservationStatus,
    public paymentStatus: PaymentStatus,
    public prepaidAmount: number,
    public carId: string,
    public car: string,
    public customerName: string,
    public customerPhone: string
  ) {}
}

export interface Reservation {
  id: string | undefined;
  date: Date | string;
  hour: number;
  price: number;
  status: ReservationStatus;
  paymentStatus: PaymentStatus;
  prepaidAmount: number;
  carId: string;
}
export interface FilterReservations {
  date: Date | undefined;
  hourFrom: number | undefined;
  hourTo: number | undefined;
  status: ReservationStatus | undefined;
  paymentStatus: PaymentStatus | undefined;
  carId: string | undefined;
}

export enum ReservationStatus {
  Completed,
  InProgress,
  WaitingForCustomer,
  JustArrived,
}
export enum PaymentStatus {
  Paid,
  NotPaid,
  PartlyPaid,
}
