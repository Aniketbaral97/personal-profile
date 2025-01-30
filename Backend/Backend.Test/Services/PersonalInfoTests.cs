using Application.Exceptions;
using Application.Interfaces;
using Application.Services.PersonalInfo;
using Backend.Test.Faker;
using Infrastructure.Persistence.Context;
using Moq;

namespace Backend.Test.Services;
[TestFixture]
public class PersonalInfoTests
{
    private IPersonalInfoService _service;
    private Mock<IPersonalInfoRepository> _repository;
    [SetUp]
    public void Setup()
    {
        _repository = new Mock<IPersonalInfoRepository>();
        _service = new PersonalInfoService(_repository.Object);

    }

    [Test]
    public void CreatePersonalInfo_WhenSuccess_ReturnId()
    {
        var model = PersonalInfoFaker.GetCreateModel();
        var expectedId=Guid.NewGuid();
        var repoResult = _repository.Setup(x=>x.AddPersonalInfoAsync(model)).ReturnsAsync(expectedId);
        var result = _service.AddPersonalInfoAsync(model).GetAwaiter().GetResult();
        Assert.That(result, Is.EqualTo(expectedId));
    }
    [Test]
    public void CreatePersonalInfo_WhenIncompleteModel_ThrowValidationError()
    {
        var model = PersonalInfoFaker.GetIncompleteCreateModel();
        Assert.That(async ()=> await _service.AddPersonalInfoAsync(model),Throws.Exception.TypeOf<ValidationException>());
    }
}
