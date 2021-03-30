namespace Entities.Concrete
{
    public class CardPayment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string FullName { get; set; }
        public string Ccv { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
    }
}