namespace model_dto_validation.Data.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string authorName { get; set; }
        public string type { get; set; }
        public int page { get; set; }
        public int BookType { get; set; }
    }
}
