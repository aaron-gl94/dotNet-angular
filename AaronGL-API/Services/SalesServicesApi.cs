using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AaronGLAPI.Data;
using AaronGLAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AaronGLAPI.Services
{
    public class SalesServicesApi
    {
        private readonly HttpClient _httpClient;
        private readonly IDbContextFactory<BitacoraStoreContext> _contextFactory;

        public SalesServicesApi(HttpClient httpClient, IDbContextFactory<BitacoraStoreContext> contextFactory)
        {
            _httpClient = httpClient;
            _contextFactory = contextFactory;
        }

        public async Task<Bitacora?> GetSaleData(int id, string date)
        {
            var url = $"https://aphmx442916.azurewebsites.net/sales/data/{id}/{date}";

            try
            {
                var response = await _httpClient.GetStringAsync(url);

                if (response != null)
                {
                    var sale = JsonSerializer.Deserialize<SalesData>(response, new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    });

                    Console.Write($"\n\n[sale.response]: {sale}\n\n");

                    if (sale != null)
                    {
                        var bitacora = new Bitacora
                        {
                            DateLog = DateTime.Now,
                            SaleLog = sale
                        };

                        Console.Write($"\n\n[Bitacora.Add]: {bitacora}\n\n");

                        using (var context = _contextFactory.CreateDbContext()) {
                            context.Bitacoras.Add(bitacora);
                            await context.SaveChangesAsync();
                        }
                        
                        return bitacora;
                    }
                }

                Console.WriteLine("\n\n[Error]: Response is null or empty\n\n");
                throw new Exception("\n\n[Error]: Response is null or empty\n\n");
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"HttpRequestException: {e.Message}");
            }
        }
    }
}
