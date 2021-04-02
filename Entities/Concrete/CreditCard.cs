using Core.Entities;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; }
        public string FullName { get; set; }
        public string Ccv { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
    }
}