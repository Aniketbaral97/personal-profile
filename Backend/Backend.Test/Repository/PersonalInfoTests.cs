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
    public class PersonalInfoTests
    {
        private AppDbContext _context;
        private IPersonalInfoRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDbContext(options);
            _repository = new PersonalInfoRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private async Task<PersonalInfo> CreatePersonalInfoAsync(){
            var personalInfoDto = PersonalInfoFaker.GetPersonalInfoModel();
            var personalInfo = PersonalInfoFaker.GetPersonalInfoEntity(personalInfoDto);
            _context.PersonalInfos.Add(personalInfo);
            await _context.SaveChangesAsync();
            return personalInfo;
        }

        [Test]
        public async Task AddPersonalInfoAsync_ShouldAddPersonalInfo()
        {
            var dto = PersonalInfoFaker.GetCreateModel();

            var id = await _repository.AddPersonalInfoAsync(dto);

            var personalInfo = await _context.PersonalInfos.FindAsync(id);
            Assert.Multiple(() =>
            {
                Assert.That(personalInfo, Is.Not.EqualTo(null));
                Assert.That(dto.Firstname, Is.EqualTo(personalInfo!.Firstname));
            });

        }

        [Test]
        public async Task GetPersonalInfoByIdAsync_ShouldReturnCorrectData()
        {
            var personalInfo = await CreatePersonalInfoAsync();

            var result = await _repository.GetPersonalInfoByIdAsync(personalInfo.Id);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(null));
                Assert.That(personalInfo.Firstname, Is.EqualTo(result!.Firstname));
            });
        }

        // [Test]
        // public async Task DeletePersonalInfoAsync_ShouldDeletePersonalInfo()
        // {
        //     var personalInfo = await CreatePersonalInfoAsync();

        //     var result = await _repository.DeletePersonalInfoAsync(personalInfo.Id);

        //     Assert.That(result, Is.EqualTo(1));
        // }
    }

    
}
