using Application.DTOs;
using Application.Interfaces;
using Backend.Test.Faker;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Backend.Test.Repository
{
    [TestFixture]
    // public class PersonalInfoTests
    // {
    //     private AppDbContext _context;
    //     private IPersonalInfoRepository _repository;

    //     [SetUp]
    //     public void SetUp()
    //     {
    //         var options = new DbContextOptionsBuilder<AppDbContext>()
    //             .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
    //             .Options;

    //         _context = new AppDbContext(options);
    //         _repository = new PersonalInfoRepository(_context);
    //     }

    //     [TearDown]
    //     public void TearDown()
    //     {
    //         _context.Database.EnsureDeleted();
    //         _context.Dispose();
    //     }

    //     private async Task<PersonalInfo> CreatePersonalInfoAsync(){
    //         var personalInfo = PersonalInfoFaker.GetPersonalInfoEntity();
    //         _context.PersonalInfos.Add(personalInfo);
    //         await _context.SaveChangesAsync();
    //         return personalInfo;
    //     }

    //     [Test]
    //     public async Task AddPersonalInfoAsync_ShouldAddPersonalInfo()
    //     {
    //         var dto = PersonalInfoFaker.GetCreateModel();

    //         var id = await _repository.AddPersonalInfoAsync(dto);

    //         var personalInfo = await _context.PersonalInfos.FindAsync(id);
    //         Assert.Multiple(() =>
    //         {
    //             Assert.That(personalInfo, Is.Not.EqualTo(null));
    //             Assert.That(dto.Firstname, Is.EqualTo(personalInfo!.Firstname));
    //         });

    //     }

    //     [Test]
    //     public async Task GetPersonalInfoByIdAsync_ShouldReturnCorrectData()
    //     {
    //         var personalInfo = await CreatePersonalInfoAsync();

    //         var result = await _repository.GetPersonalInfoByIdAsync(personalInfo.Id);
    //         Assert.Multiple(() =>
    //         {
    //             Assert.That(result, Is.Not.EqualTo(null));
    //             Assert.That(personalInfo.Firstname, Is.EqualTo(result!.Firstname));
    //         });
    //     }

    //     [Test]
    //     public async Task DeletePersonalInfoAsync_ShouldDeletePersonalInfo()
    //     {
    //         var personalInfo = await CreatePersonalInfoAsync();

    //         var result = await _repository.DeletePersonalInfoAsync(personalInfo.Id);

    //         Assert.That(result, Is.EqualTo(1));
    //     }
    // }

    public class PersonalInfoTests
    {
        private Mock<AppDbContext> _dbContext;
        private IPersonalInfoRepository _personalInfo;
        private Mock<DbSet<PersonalInfo>> _dbSet;
        
        List<PersonalInfo> personalInfoList;
        [SetUp]
        public void Setup()
        {
            _dbSet = new Mock<DbSet<PersonalInfo>>();
            personalInfoList =PersonalInfoFaker.GetPersonalInfoEntities(10);
            _dbSet.Setup(m => m.Add(It.IsAny<PersonalInfo>()))
                  .Callback<PersonalInfo>(p => personalInfoList.Add(p));
            _dbSet.As<IQueryable<PersonalInfo>>().Setup(x => x.Provider).Returns(personalInfoList.AsQueryable().Provider);
            _dbSet.As<IQueryable<PersonalInfo>>().Setup(x => x.Expression).Returns(personalInfoList.AsQueryable().Expression);
            _dbSet.As<IQueryable<PersonalInfo>>().Setup(x => x.ElementType).Returns(personalInfoList.AsQueryable().ElementType);
            _dbSet.As<IQueryable<PersonalInfo>>().Setup(x => x.GetEnumerator()).Returns(() => personalInfoList.GetEnumerator());

            _dbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _dbContext.Setup(c => c.PersonalInfos).Returns(_dbSet.Object);
            _personalInfo = new PersonalInfoRepository(_dbContext.Object);

        }
        [TearDown]
        public void TearDown()
        {
        }
        [Test]
        public async Task CreatePersonalInfo_WhenSuccess_ReturnId()
        {
            var model = PersonalInfoFaker.GetCreateModel();
            var personalInfoList = new List<PersonalInfo>();
            _dbSet.Setup(x => x.Add(It.IsAny<PersonalInfo>()))
                  .Callback<PersonalInfo>(p => personalInfoList.Add(p));
            _dbContext.Setup(c => c.SaveChangesAsync(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                      .ReturnsAsync(1);
            var result = await _personalInfo.AddPersonalInfoAsync(model);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(Guid.Empty));
                Assert.That(personalInfoList.Count, Is.EqualTo(1)); // Ensure the entity was added to the list
            });
            _dbContext.Verify(m => m.SaveChangesAsync(It.IsAny<bool>(), It.IsAny<CancellationToken>()), Times.Once);
        }
        [Test]
        public async Task UpdatePersonalInfo_WhenSuccess_ReturnOne()
        {
            var updateId= personalInfoList.FirstOrDefault()!.Id;
            var updateModel = PersonalInfoFaker.GetUpdateModel();
            updateModel.Id=updateId;
            updateModel.Firstname="Test123";
            _dbContext.Setup(x=>x.SaveChangesAsync(It.IsAny<bool>(),It.IsAny<CancellationToken>())).ReturnsAsync(1);
            var result =await _personalInfo.UpdatePersonalInfoAsync(updateModel);
            Assert.That(result, Is.GreaterThan(0));   
            _dbContext.Verify(x=>x.SaveChangesAsync(It.IsAny<bool>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
