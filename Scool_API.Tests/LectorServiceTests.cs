using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using School_API.Data.Model;
using School_API.Data;
using School_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scool_API.Tests
{
    public class LectorServiceTests
    {
            [Fact]
        public async Task GetAll_Returns_AllLectors()
        {
            // Arrange
            var lectors = new List<Lector>
        {
            new Lector { Id = 1, Name = "luka", Email = "luka@gmail.com" },
            new Lector { Id = 2, Name = "nino", Email = "nino@gmail.com" }
        }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Lector>>();
            mockDbSet.As<IQueryable<Lector>>().Setup(m => m.Provider).Returns(lectors.Provider);
            mockDbSet.As<IQueryable<Lector>>().Setup(m => m.Expression).Returns(lectors.Expression);
            mockDbSet.As<IQueryable<Lector>>().Setup(m => m.ElementType).Returns(lectors.ElementType);
            mockDbSet.As<IQueryable<Lector>>().Setup(m => m.GetEnumerator()).Returns(lectors.GetEnumerator());

            var mockDbContext = new Mock<IApplicationDbContext>();
            mockDbContext.Setup(db => db.Lectors).Returns(mockDbSet.Object);

            var mockMapper = new Mock<IMapper>();

            var service = new LectorService((ApplicationDbContext)mockDbContext.Object, mockMapper.Object);

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, l => l.Name == "luka");
            Assert.Contains(result, l => l.Name == "nino");
        }
    }
}
