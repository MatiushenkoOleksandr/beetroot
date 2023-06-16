import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Customer } from '../../httpModals';
import { MatTableModule } from '@angular/material/table';
import { Route, Router } from '@angular/router';
import { HttpService } from 'src/app/http.service';

@Component({
  selector: 'app-persons-table',
  templateUrl: './persons-table.component.html',
  styleUrls: ['./persons-table.component.scss'],
})
export class PersonsTableComponent {
  constructor(private router: Router, private HttpService: HttpService) {}

  @Input() customers: Customer[] = [];
  @Output() onCustomerDeleted: EventEmitter<any> = new EventEmitter();
  dataSourse: [] = [];
  displayedColumns = ['name', 'surname', 'phoneNumber', 'delete'];

  tableElementClicked(id: string) {
    this.router.navigate([`customers/${id}/cars`]);
  }

  deleteCustomer(event: any, id: string) {
    event.stopPropagation();
    this.HttpService.deleteCustomer(id).subscribe(() => {
      this.onCustomerDeleted.emit(null);
    });
  }
}
