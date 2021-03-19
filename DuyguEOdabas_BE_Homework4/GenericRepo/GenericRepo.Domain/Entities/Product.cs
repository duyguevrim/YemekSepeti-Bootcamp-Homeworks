using GenericRepo.Domain.Interfaces;

namespace GenericRepo.Domain.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public double Price { get; set; }
    }
}