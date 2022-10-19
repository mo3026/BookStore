using Microsoft.AspNetCore.Mvc;
using BookStore.Model;
using BookStore.DBActions;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index(string searchText="", string PageOptionsDropDown="")
        {
            List<Book> Books = new List<Book>();
            try
            {
                if(searchText=="") Books = BooksActions.BookSelect();
                else Books = BooksActions.BookSearch(PageOptionsDropDown, searchText);
            }
            catch (Exception ex)
            {
            }
            return View(Books);
        }
    }
}
