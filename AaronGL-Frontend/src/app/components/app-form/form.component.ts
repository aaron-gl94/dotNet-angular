import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BitacoraSalesInterface } from 'src/app/interfaces/sales-data-interface';
import { ServicioService } from '../../services/servicio.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  @Output() salesDataEventOutput = new EventEmitter<BitacoraSalesInterface[]>();

  formSale: any = {
    ids: '',
    date: ''
  };

  constructor(private service$: ServicioService) {}

  ngOnInit(): void {
      
  }

  onSubmit() {

    if (this.formSale.ids && this.formSale.date) {

      this.salesDataEventOutput.emit([]);

      const idsString = this.formSale.ids; // Obtiene los valores del input
      const ids: number[] = idsString.split(',').map(Number);

      const request: any = {
        ids: ids,
        date: this.formSale.date
      }

      this.service$.getSalesAPI(request).subscribe(data => {
        console.log('[Datos de ventas]:', data);

        this.salesDataEventOutput.emit(data);

      });
      
    }
  }
}
