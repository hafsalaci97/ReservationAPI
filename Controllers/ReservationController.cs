using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly ReservationContext _context;

    public ReservationController(ReservationContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        return Ok(reservation);
    }
}
