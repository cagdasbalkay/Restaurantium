namespace Restaurantium.Dto.BookingDtos
{
    public class ResultBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public byte NumberOfGuests { get; set; }
        public string SpecialRequest { get; set; }
    }
}
