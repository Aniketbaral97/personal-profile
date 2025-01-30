using Application.DTOs.PersonalInfos;
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
    [Test]
    public void UpdatePersonalInfo_WhenSucces_ReturnInt()
    {
        var model = PersonalInfoFaker.GetUpdateModel();
        var repoResult = _repository.Setup(x=>x.CheckIsMain(model.Id)).Returns(false);
        var repoResult2 = _repository.Setup(x=>x.UpdatePersonalInfoAsync(model)).ReturnsAsync(1);
        var result =_service.UpdatePersonalInfoAsync(model).GetAwaiter().GetResult();
        Assert.That(result, Is.EqualTo(1));
    }
    [Test]  
    public void UpdatePersonalInfo_WhenDuplicateIsMain_ThrowCommandExecutionException()
    {
        var model = PersonalInfoFaker.GetUpdateModel();
        model.IsMain=true;
        var repoResult = _repository.Setup(x=>x.CheckIsMain(model.Id)).Returns(true);
        Assert.That(async () =>await _service.UpdatePersonalInfoAsync(model), Throws.Exception.TypeOf<CommandExecutionException>());
    }
    [Test]
    public void UpdatePersonalInfo_WhenFluentValidationError_ThrowValidationException()
    {
        var model = PersonalInfoFaker.GetIncompleteUpdateModel();
        model.IsMain=true;
        var repoResult = _repository.Setup(x=>x.CheckIsMain(model.Id)).Returns(false);
        Assert.That(async () =>await _service.UpdatePersonalInfoAsync(model), Throws.Exception.TypeOf<ValidationException>());
    }
    [Test]
    public void GetPersonalInfo_WhenSuccess_ReturnPersonalInfo()
    {
        var id=Guid.NewGuid();
        var model = PersonalInfoFaker.GetPersonalInfoModel();
        var repoResult = _repository.Setup(x=>x.GetPersonalInfoByIdAsync(id)).ReturnsAsync(model);
        var result =_service.GetPersonalInfoByIdAsync(id).GetAwaiter().GetResult();
        Assert.That(result, Is.EqualTo(model)); 
    }
    [Test]
    public void GetPersonalInfo_WhenInvalidId_ReturnNull()
    {
        var id=Guid.NewGuid();
        PersonalInfoDto? model = null;
        var repoResult = _repository.Setup(x=>x.GetPersonalInfoByIdAsync(id)).ReturnsAsync(model);
        var result =_service.GetPersonalInfoByIdAsync(id).GetAwaiter().GetResult();
        Assert.That(result, Is.EqualTo(model)); 
    }

    [Test]
    public void DeletePersonalInfoById_WhenSuccess_ReturnOne()
    {
        var id= Guid.NewGuid();
        var repoResult=_repository.Setup(x=>x.DeletePersonalInfoAsync(id)).ReturnsAsync(1);
        var result =_service.DeletePersonalInfoAsync(id).GetAwaiter().GetResult();
        Assert.That(result, Is.EqualTo(1));
    }
    [Test]
    public void GetPersonalInfoList_WhenSuccess_ReturnList()
    {
        var request= new PersonalInfoDemoRequestDto();
        var expectedResponse = new GetPersonalInfoDemoDto(){
            TotalPages=1,
            PersonalInfos=[new PersonalInfoDemo(){
                Firstname="A",
                Lastname="B",
                Designations="C",
                Address="D",
            }]
        };
        var repoResult=_repository.Setup(x=>x.GetPersonalInfoList(It.IsAny<PersonalInfoDemoRequestDto>())).ReturnsAsync(expectedResponse);
        var result =_service.GetPersonalInfoList(request).GetAwaiter().GetResult();
        Assert.That(result, Is.EqualTo(expectedResponse));
    }
}
