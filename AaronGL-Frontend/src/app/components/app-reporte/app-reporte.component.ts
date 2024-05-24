import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BitacoraSalesInterface } from 'src/app/interfaces/sales-data-interface';
import { ServicioService } from '../../services/servicio.service';

@Component({
  selector: 'app-reporte',
  templateUrl: './app-reporte.component.html',
  styleUrls: ['./app-reporte.component.css']
})
export class AppReporteComponent implements OnInit, OnChanges {
  public listReport: BitacoraSalesInterface[] = [];

  @Input() salesDataInput: BitacoraSalesInterface[] | undefined;

  constructor(private servicio$: ServicioService) {}

  ngOnInit(): void {
    this.getAllSales();

  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['salesDataInput'] && this.salesDataInput) {
      this.listReport = this.salesDataInput;
    }
  }

  public getAllSales() {
    this.listReport = [];
    
    this.servicio$.getAllSales().subscribe(
      (data) => {
        console.log(data);
        data.map(bitacora => {
          if (bitacora !== undefined) {
            this.listReport!.push(bitacora);
          }
        })
      },
      (error) => {
        console.error("Error al extraer data [getAllSales]: " + error);
      }
    );
  }

  public clearAllSales() {
    this.listReport = [];
  }
}
