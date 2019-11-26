using Library.Web.Entities;
using Library.Web.EntityFrameworkCore;
using Library.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Web.Tests.RepositoryTests
{
    [TestFixture]
    public class AuthorRepositoryTests
    {
        private AuthorRepository _repository;
        private LibraryDbContext _context;
        private Author _author;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
          .UseInMemoryDatabase(databaseName: "Add_Data_To_Database")
          .Options;

            _context = new LibraryDbContext(options);
            _author = new Author { FirstName = "Joanne", LastName = "Rowling", Id = 1 };
            _context.Authors.Add(_author);
            _repository = new AuthorRepository(_context);

        }

        [Test]
        public void AddAsync_Null_ShouldThrowArgumentNullException() => Assert.ThrowsAsync<ArgumentNullException>(() => _repository.AddAsync(null));

        [Test]
        public void AddAsync_Author_ShouldAddAuthorToDB()
        {
            _repository.AddAsync(_author).Wait();

            Assert.AreEqual(_author, _repository.FindByIdAsync(_author.Id).Result);
        }
        

        [Test]
        public void DeleteAsync_Null_ShouldThrowArgumentNullException() => Assert.ThrowsAsync<ArgumentNullException>(() => _repository.DeleteAsync(null));

        [Test]
        public void DeleteAsync_ValidAuthor_ShouldDeleteAuthor()
        {
            //Arrange
            _repository.AddAsync(_author).Wait();
            _repository.DeleteAsync(_author).Wait();

            //Act
            var author = _repository.FindByIdAsync(_author.Id).Result;

            //Assert
            Assert.IsNull(author);
        }

        [Test]
        public void UpdateAsync_Null_ShouldThrowArgumentNullException() => Assert.ThrowsAsync<ArgumentNullException>(() => _repository.UpdateAsync(null));

        [Test]
        public void UpdateAsync_ValidAuthor_ShouldUpdateAuthor()
        {
            _repository.AddAsync(_author).Wait();
            _author.FirstName = "Updated name";
            _repository.UpdateAsync(_author).Wait();

            var author = _repository.FindByIdAsync(_author.Id).Result;

            Assert.AreEqual(_author, author);
        }

        [Test]
        public void FindByIdAsync_Input0_ShouldThrowArgumentException() => Assert.ThrowsAsync<ArgumentException>(() => _repository.FindByIdAsync(0));

        [Test]
        public void FindByIdAsync_ValidInput_ShouldReturnAnAuthor() => Assert.IsInstanceOf<Author>(_repository.FindByIdAsync(1).Result);

        [Test]
        public void FindByIdAsync_InvalidInput_ShouldReturnNull() => Assert.IsNull(_repository.FindByIdAsync(2).Result);

        [Test]
        public void GetAll_ShouldNotReturnNull() => Assert.IsNotNull(_repository.GetAll());

    }
}
