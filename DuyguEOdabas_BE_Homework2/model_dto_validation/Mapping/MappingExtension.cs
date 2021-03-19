using model_dto_validation.Data.Entity;
using model_dto_validation.Enums;
using model_dto_validation.RequestModel;
using System.Collections.Generic;

namespace model_dto_validation.Mapping
{
    public static class MappingExtension
    {

        public static List<BookModel> ToBookResponse(this List<Book> books)
        {
            List<BookModel> result = new List<BookModel>();

            for (int i = 0; i < books.Count; i++)
            {
                result.Add(new BookModel
                {
                    Id = books[i].Id,
                    name = books[i].name,
                    bookType = (BookType)books[i].BookType,
                    authorName = books[i].authorName,
                    page = books[i].page
                });
            }

            return result;
        }
        public static Book ToBook(this BookRequest bookRequest)
        {
            Book book = new Book
            {
                Id = bookRequest.Id,
                name = bookRequest.name,
                authorName = bookRequest.authorName,
                BookType = bookRequest.bookType,
                page = bookRequest.page
            };
            return book;
        }
    }
}



