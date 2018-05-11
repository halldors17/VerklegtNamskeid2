using System.Collections.Generic;
using System.Linq;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AuthorService
    {
        private AuthorRepo _authorRepo;
        public AuthorService()
        {
            _authorRepo = new AuthorRepo();
        }
     public List<AuthorListViewModel> GetAllAuthors()
        {
            var authors = _authorRepo.GetAllAuthors();
            return authors;
        }
    internal object GetAuthorsByName(string SearchString)
        {
            var authors = _authorRepo.GetAuthorsByName(SearchString).ToList();
            return authors;
        }
        public AuthorDetailsViewModel GetDetailsAuthor(int id)
        {
            var authors = _authorRepo.GetDetailsAuthor(id);
            return authors;
        }
           public void AddAuthor(AuthorInputModel author)
        {
            _authorRepo.AddAuthor(author);
        }
        public void UpdateAuthor(AuthorInputModel author)
        {
            _authorRepo.UpdateAuthor(author);
        }
             public void RemoveAuthor(int id)
        {
            _authorRepo.RemoveAuthor(id);
        }
        public AuthorSalesInfoViewModel GetSalesForAuthor(int id)
        {
            var authors = _authorRepo.GetSalesForAuthor(id);
            return authors;
        }
    }
}