export interface SalesDataInterface {
    id?: number;
    date?: string;
    name?: string;
    sales?: number;
    expenses?: number;
}

export interface SaleDataRequestInterface {
    ids: string;
    date: string;
}

export interface BitacoraSalesInterface {
    idLog?: string,
    dateLog: string,
    saleLog: SalesDataInterface
}
