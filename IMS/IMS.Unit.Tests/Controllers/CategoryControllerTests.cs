using Castle.Core.Logging;
using IMS.API.Controllers;
using IMS.API.Models;
using IMS.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IMS.Unit.Tests.Controllers
{
    public class CategoryControllerTests
    {
        [Fact]
        public async Task Index_Returns_ListOfCategories()
        {
            //Arrange
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.ListAsync()).ReturnsAsync(GetTestCategories);
            var controller = new CategoryController(NullLogger<CategoryController>.Instance, mockRepo.Object);

            //Act
            var actionResult = await controller.Get();

            //Assert            
            Assert.IsType<OkObjectResult>(actionResult);
            var result = actionResult as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
            var categories = result.Value as List<Category>;
            Assert.Equal(2, categories.Count);
            
        }

        [Fact]
        public async Task Index_Returns_CategoryForSearchedId()
        {
            //Arrange
            var categoryId = 1;
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(categoryId)).ReturnsAsync(GetTestCategories()[0]).Verifiable();            
            var controller = new CategoryController(NullLogger<CategoryController>.Instance, mockRepo.Object);

            //Act
            var actionResult = await controller.Get(categoryId);

            //Assert            
            Assert.IsType<OkObjectResult>(actionResult);
            var result = actionResult as OkObjectResult;
            Assert.Equal(200, result.StatusCode);
            var category = result.Value as Category;
            Assert.Equal(categoryId, category.Id);
            Assert.Equal("Category1", category.Name);
            Assert.Equal("Description 1", category.Description);
            mockRepo.Verify();

        }


        [Fact]
        public async Task Index_Returns_NotFoundWhenIdIsNotPresent()
        {
            //Arrange
            var categoryId = 300;
            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(categoryId)).ReturnsAsync((Category)null).Verifiable();
            var controller = new CategoryController(NullLogger<CategoryController>.Instance, mockRepo.Object);

            //Act
            var actionResult = await controller.Get(categoryId);

            //Assert            
            Assert.IsType<NotFoundResult>(actionResult);
            var result = actionResult as NotFoundResult;
            Assert.Equal(404, result.StatusCode);            
            mockRepo.Verify();
        }

        private List<Category> GetTestCategories()
        {
            return new List<Category>()
            {
                new Category { Id = 1, Name = "Category1", Description = "Description 1" },
                new Category { Id = 2, Name = "Category2", Description = "Description 2" }
            };
        }

    }


}
