namespace Domain.Aggregates.Entities
{
    public class Document
    {
        public long DocumentId { get; set; }

        public long PersonId { get; set; }

        public string DocumentType { get; set; }

        public string DocumentNumber { get; set; }

        public virtual Person Person { get; set; }
    }
}
