using LibManagementSystem.Entities;
using LibManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace LibManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController: ControllerBase//It's a Controlller
    {
        //Parameter that are taken while making connection with the Database
        public string URI ="https://localhost:8081";
        public string PrimaryKey="C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        public string DatabaseName="batch4";
        public string ContainerName="student";

        public Microsoft.Azure.Cosmos.Container Container;
        //Making a constructor of container
        public BookController()
        {
         Container=GetContainer();
        }
        private Microsoft.Azure.Cosmos.Container GetContainer()
        {
            CosmosClient cosmosClient=new CosmosClient(URI,PrimaryKey);
            Database database=cosmosClient.GetDatabase(DatabaseName);
            Microsoft.Azure.Cosmos.Container container=database.GetContainer(ContainerName);
            return container;
        }
        [HttpPost]
        public async Task<IActionResult>AddBook(BookModel bookModel)
        {
            //mapping all the field from model to entity
            BookEntity book = new BookEntity
            {
                //Assign values
                Id = Guid.NewGuid().ToString(),
                UId = bookModel.UId,
                Title = bookModel.Title,
                Author = bookModel.Author,
                PublishedDate = bookModel.PublishedDate,
                ISBN = bookModel.ISBN,
                IsIssued = bookModel.IsIssued,
                DocumentType = "book",
                CreatedBy = "Admin",
                CreatedOn = DateTime.Now,
                UpdatedBy = "",
                UpdatedOn = DateTime.Now,
                Active = true,
                Archived = false,
                Version = 1 
            };
            //Adding value to Database
            ItemResponse<BookEntity> response=await Container.CreateItemAsync(book);
            return Ok(new BookModel
            {
                //Return from the Model
                UId = response.Resource.UId,
                Title=response.Resource.Title,
                Author=response.Resource.Author,
                PublishedDate=response.Resource.PublishedDate,
                ISBN=response.Resource.ISBN,
                IsIssued=response.Resource.IsIssued
            });
        }
          [HttpGet]
        public async Task<IActionResult>GetBookByTitle(string Title)
        {
            //Fetch the Records
            var query = Container.GetItemLinqQueryable<BookEntity>(true).Where(b => b.Title.ToLower() == Title.ToLower() && b.Active && !b.Archived).AsQueryable();
            List<BookModel> books = query.Select(book => new BookModel { 
                UId=book.UId,
                Title=book.Title,
                Author=book.Author,
                PublishedDate=book.PublishedDate,
                ISBN=book.ISBN,
                IsIssued=book.IsIssued
            }).ToList();
            return Ok(books);//Return the values
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            //Fetch the Records
            var query = Container.GetItemLinqQueryable<BookEntity>(true).Where(b=>b.Active && !b.Archived).AsQueryable();
            List<BookModel>books=query.Select(book=>new BookModel
            {
                UId=book.UId,
                Title=book.Title,
                Author=book.Author,
                PublishedDate=book.PublishedDate,
                ISBN=book.ISBN,
                IsIssued=book.IsIssued
            }).ToList();

            return Ok(books);//Return the values
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIssueBooks()
        {
            //Fetch the Records
            var query = Container.GetItemLinqQueryable<BookEntity>(true).Where(b => b.Active && !b.Archived).AsQueryable();
            List<BookModel> books = query.Select(book => new BookModel
            {
                UId = book.UId,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                ISBN = book.ISBN,
                IsIssued = book.IsIssued
            }).ToList();

            return Ok(books);//Return the values

        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookModel bookModel)
        {
            //Fetch the Records
            var query = Container.GetItemLinqQueryable<BookEntity>(true).Where(b=>b.UId==bookModel.UId && b.Active && !b.Archived).AsQueryable();
            BookEntity existingBook = query.FirstOrDefault();
            if (existingBook==null)
            {
                return NotFound();
            }
            existingBook.Archived=true;
            existingBook.Active=false;
            await Container.ReplaceItemAsync(existingBook,existingBook.Id);

            existingBook.Id=Guid.NewGuid().ToString();
            existingBook.UpdatedBy="Admin";
            existingBook.UpdatedOn=DateTime.Now;
            existingBook.Version+=1; 
            existingBook.Active=true;
            existingBook.Archived=false;
            existingBook.Title=bookModel.Title;
            existingBook.Author=bookModel.Author;
            existingBook.PublishedDate=bookModel.PublishedDate;
            existingBook.ISBN=bookModel.ISBN;
            existingBook.IsIssued=bookModel.IsIssued;
            await Container.CreateItemAsync(existingBook);
            return Ok(new BookModel //Return the values
            {
                UId=existingBook.UId,
                Title=existingBook.Title,
                Author=existingBook.Author,
                PublishedDate=existingBook.PublishedDate,
                ISBN=existingBook.ISBN,
                IsIssued=existingBook.IsIssued
            });
        }
    }
}
