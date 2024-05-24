https://aphmx442916.azurewebsites.net/sales/data/619/2015-06-12

{
    "id": 619,
    "date": "2015-06-12",
    "name": "Almacén Puebla",
    "sales": 25195,
    "expenses": 993.8
}


API en .Net usando C#
    Proyecto “NombreCandidato-API”
    Recibe los parámetros IDs y fecha
    Regresa los datos necesarios para mostrar el reporte
    Registrar en la base de datos SQL Server la bitácora de la petición, incluyendo los parámetros, el resultado que se regresa y las iniciales del nombre del candidato.
    Este proyecto debe invocar el servicio arriba mencionado tantas veces como sea necesario, por cada uno de los IDs recibidos.
    Bonus: Dicho servicio tarda 8 segundos en responder. Asegure que el tiempo de respuesta de su API sea menor a 10 segundos aun recibiendo 3 IDs




Sending HTTP request GET https://aphmx442916.azurewebsites.net/sales/data/619/2015-06-12
    {
        "id": 619,
        "name": "Almacén Puebla",
        "salesAmount": 0,
        "expenses": 993.8,
        "date": "2015-06-12T00:00:00"
    }

Sending HTTP request GET https://aphmx442916.azurewebsites.net/sales/data/626/2015-06-12
        "id": 626,
        "name": "Bar Lindavista",
        "salesAmount": 0,
        "expenses": 1210.8,
        "date": "2015-06-12T00:00:00"
    }


Sending HTTP request GET https://aphmx442916.azurewebsites.net/sales/data/643/2015-06-12
    {
        "id": 643,
        "name": "Sucursal Tláhuac",
        "salesAmount": 0,
        "expenses": 1210.8,
        "date": "2015-06-12T00:00:00"
    }