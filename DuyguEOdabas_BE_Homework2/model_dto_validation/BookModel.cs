using model_dto_validation.Enums;

namespace model_dto_validation
{
    public class BookModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string authorName { get; set; }
        public BookType bookType { get; set; }
        public int page { get; set; }
    }
}
