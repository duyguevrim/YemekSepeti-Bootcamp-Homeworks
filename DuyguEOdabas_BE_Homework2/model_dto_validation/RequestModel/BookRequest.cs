namespace model_dto_validation.RequestModel
{
    public class BookRequest
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string authorName { get; set; }
        public int bookType { get; set; }
        public int page { get; set; }

        
    }
}
