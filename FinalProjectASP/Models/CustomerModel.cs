namespace FinalProjectASP.Models
{
    public class CustomerModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<CarModel> Cars { get; set; }
    }
}
