namespace EnrichmentAcademy.Data
{
    public class AddSubject
    {
        public string Name { get; set; }
        public IFormFile LinkSubject { get; set; }
        public int IdFaculty { get; set; }
        public decimal Price { get; set; }

    }
}
