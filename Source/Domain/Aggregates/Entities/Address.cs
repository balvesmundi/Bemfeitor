namespace Domain.Aggregates.Entities
{

    public class Address
    {
        public long AddressId { get; set; }

        public long PersonId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }
    }
}
