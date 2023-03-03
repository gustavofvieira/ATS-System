using AutoFixture;
using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Services.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Challenge.TOTVS.Tests.Services
{
    public class JobVacancyServiceTest
    {
        private Mock<IJobVacancyRepository> _jobVacancyRepository = default!;
        private Mock<ILogger<JobVacancyService>> _logger = default!;
        private Fixture _fixture = default!; 

        [SetUp]
        public void SetUp()
        {
            _logger = new();
            _jobVacancyRepository = new();
            _fixture = new();
        }

        [Test] 
        public async Task ShouldAddWithSuccess()
        {
            //Arrange
            var service = new JobVacancyService(_logger.Object, _jobVacancyRepository.Object);
            var jobVacancy = _fixture.Build<JobVacancy>().Create();
            
            //Act

            await service.Add(jobVacancy);

            //Assert
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("[Add] - Started", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("[Add] - Finish", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }

        [Test]
        public async Task ShouldGetAllWithSuccess()
        {
            //Arrange
            var service = new JobVacancyService(_logger.Object, _jobVacancyRepository.Object);
            var jobVacancys = _fixture.Build<JobVacancy>().CreateMany(2).ToList();

            _jobVacancyRepository.Setup(c => c.GetAll()).ReturnsAsync(jobVacancys);

            //Act
            var result = await service.GetAll();


            //Assert

            result.Should().HaveCount(2);
            _jobVacancyRepository.Verify(c => c.GetAll(), Times.Once);
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("[GetAll] - Started", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("[GetAll] - Finish", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }

        [Test]
        public async Task ShouldGetByIdWithSuccess()
        {
            //Arrange
            var id = Guid.NewGuid();
            var service = new JobVacancyService(_logger.Object, _jobVacancyRepository.Object);
            var JobVacancys = _fixture.Build<JobVacancy>().With(c => c.JobVacancyId, id).Create();

            _jobVacancyRepository.Setup(c => c.GetById(id)).ReturnsAsync(JobVacancys);

            //Act
            var result = await service.GetById(id);


            //Assert

            result.JobVacancyId.Should().Be(id);
            _jobVacancyRepository.Verify(c => c.GetById(id), Times.Once);
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[GetById] - Started, with ID: {id}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[GetById] - Finish, with ID: {id}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }

        [Test]
        public async Task ShouldUpdateWithSuccess()
        {
            //Arrange
            var service = new JobVacancyService(_logger.Object, _jobVacancyRepository.Object);
            var jobVacancy = _fixture.Build<JobVacancy>().Create();

            //Act
            await service.Update(jobVacancy);

            //Assert
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Update] - Started, with ID: {jobVacancy.JobVacancyId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Update] - Finish, with ID: {jobVacancy.JobVacancyId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }

        [Test]
        public async Task ShouldRemoveWithSuccess()
        {
            //Arrange
            var service = new JobVacancyService(_logger.Object, _jobVacancyRepository.Object);
            var jobVacancy = _fixture.Build<JobVacancy>().Create();

            //Act

            await service.Remove(jobVacancy.JobVacancyId);

            //Assert
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Remove] - Started, with ID: {jobVacancy.JobVacancyId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Remove] - Finish, with ID: {jobVacancy.JobVacancyId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }
    }
}