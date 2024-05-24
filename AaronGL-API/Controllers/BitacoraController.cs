using Microsoft.AspNetCore.Mvc;
using AaronGLAPI.Models;
using AaronGLAPI.Data;
using AaronGLAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AaronGLAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        private readonly BitacoraStoreContext _context;
        private readonly SalesServicesApi _salesServicesApi;

        public BitacoraController(BitacoraStoreContext context, SalesServicesApi salesServicesApi)
        {
            _context = context;
            _salesServicesApi = salesServicesApi;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Bitacora>> GetBitacoras()
        {
            return _context.Bitacoras.Include(b => b.SaleLog).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Bitacora> GetBitacora(int id)
        {
            var registro = _context.Bitacoras.Include(b => b.SaleLog).FirstOrDefault(b => b.IdLog == id);

            if (registro == null)
            {
                return NotFound();
            }

            return registro;
        }

        [HttpPost]
        public ActionResult<Bitacora> PostBitacora(Bitacora bitacora)
        {
            _context.Bitacoras.Add(bitacora);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBitacora), new { id = bitacora.IdLog }, bitacora);
        }

        [HttpPost("report")]
        public async Task<ActionResult<IEnumerable<Bitacora>>> GetSalesDataForMultipleIds([FromBody] ReportRequest request)
        {
            var tasks = request.Ids.Select(id => _salesServicesApi.GetSaleData(id, request.Date)).ToList();
            var results = await Task.WhenAll(tasks);

            var bitacoras = results.Where(result => result != null).Cast<Bitacora>().ToList();
                bitacoras = bitacoras.OrderBy(b => b.IdLog).ToList();

            return Ok(bitacoras);
        }
    }
}
