using GenericRepo.Domain.Interfaces;

namespace GenericRepo.Domain.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}