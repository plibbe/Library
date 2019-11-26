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
    public class CustomerRepositoryTests
    {
        private LibraryDbContext _context;
        private Customer _customer;
        private CustomerRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
          .UseInMemoryDatabase(databaseName: "Add_Data_To_Database")
          .Options;

            _context = new LibraryDbContext(options);
            _customer = new Customer { FirstName = "John", LastName = "Doe", Id = 1 };
            _context.Customers.Add(_customer);
            _repository = new CustomerRepository(_context);

        }

        [Test]
        public void AddAsync_Null_ShouldThrowArgumentNullException() => Assert.ThrowsAsync<ArgumentNullException>(() => _repository.AddAsync(null));

        [Test]
        public void AddAsync_Author_ShouldAddAuthorToDB() => Assert.IsTrue(_repository.AddAsync(_customer).IsCompletedSuccessfully);

        [Test]
        public void DeleteAsync_Null_ShouldThrowArgumentNullException() => Assert.ThrowsAsync<ArgumentNullException>(() => _repository.DeleteAsync(null));

        [Test]
        public void DeleteAsync_ValidAuthor_ShouldDeleteAuthor() => Assert.IsTrue(_repository.DeleteAsync(_customer).IsCompletedSuccessfully);

        [Test]
        public void UpdateAsync_Null_ShouldThrowArgumentNullException() => Assert.ThrowsAsync<ArgumentNullException>(() => _repository.UpdateAsync(null));

        [Test]
        public void UpdateAsync_ValidAuthor_ShouldDeleteAuthor() => Assert.IsTrue(_repository.UpdateAsync(_customer).IsCompletedSuccessfully);

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
