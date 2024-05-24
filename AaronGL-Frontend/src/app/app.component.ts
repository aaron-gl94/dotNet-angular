import { Component } from '@angular/core';
import { BitacoraSalesInterface, SalesDataInterface } from './interfaces/sales-data-interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AaronGL-Frontend';

  salesDataMiddle: BitacoraSalesInterface[] | undefined;

  onSalesDataReceived($event: BitacoraSalesInterface[]): void {
    this.salesDataMiddle = $event;
  }
}
