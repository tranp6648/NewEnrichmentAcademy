namespace EnrichmentAcademy.Data
{
    public class CreatePackage
    {
        public string Name { get; set; }
        public decimal PricePackage { get; set; }
        public List<int> IdSubject { get; set; }
    }
}
