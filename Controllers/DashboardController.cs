using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Money_Tracker.Models;

namespace Money_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            //Mes en curso

            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddSeconds(-1);

            System.Diagnostics.Debug.WriteLine(startDate.ToString());
            System.Diagnostics.Debug.WriteLine(endDate.ToString());

            List<Transaccion> transaccionesSeleccionadas = await _context.Transacciones
                .Include(x => x.categoria)
                .Where(y => y.transaccionFecha >= startDate && y.transaccionFecha <= endDate)
                .ToListAsync();

            int ingresoTotal = transaccionesSeleccionadas
                .Where(x => x.categoria.categoriaTipo == "Ingreso")
                .Sum(y => y.transaccionMonto);
            ViewBag.ingresoTotal = ingresoTotal.ToString("C0");

            int egresoTotal = transaccionesSeleccionadas
                .Where(x => x.categoria.categoriaTipo == "Egreso")
                .Sum(y => y.transaccionMonto);
            ViewBag.egresoTotal = egresoTotal.ToString("C0");

            int balance = ingresoTotal - egresoTotal;
            ViewBag.balance = balance.ToString("C0");

            return View();
        }
    }
}
