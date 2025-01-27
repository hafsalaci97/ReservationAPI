namespace ReservationAPI.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
    }
}
