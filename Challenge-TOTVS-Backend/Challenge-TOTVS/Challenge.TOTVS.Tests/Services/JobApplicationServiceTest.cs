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
    public class JobApplicationServiceTest
    {
        private Mock<IJobApplicationRepository> _jobApplicationRepository = default!;
        private Mock<ILogger<JobApplicationService>> _logger = default!;
        private Fixture _fixture = default!; 

        [SetUp]
        public void SetUp()
        {
            _logger = new();
            _jobApplicationRepository = new();
            _fixture = new();
        }

        [Test] 
        public async Task ShouldAddWithSuccess()
        {
            //Arrange
            var service = new JobApplicationService(_logger.Object, _jobApplicationRepository.Object);
            var JobApplication = _fixture.Build<JobApplication>().Create();
            
            //Act

            await service.Add(JobApplication);

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
            var service = new JobApplicationService(_logger.Object, _jobApplicationRepository.Object);
             var JobApplications = _fixture.Build<JobApplication>().CreateMany(2).ToList();

            _jobApplicationRepository.Setup(c => c.GetAll()).ReturnsAsync(JobApplications);

            //Act
            var result = await service.GetAll();


            //Assert

            result.Should().HaveCount(2);
            _jobApplicationRepository.Verify(c => c.GetAll(), Times.Once);
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
            var service = new JobApplicationService(_logger.Object, _jobApplicationRepository.Object);
            var JobApplications = _fixture.Build<JobApplication>().With(c => c.JobApplicationId, id).Create();

            _jobApplicationRepository.Setup(c => c.GetById(id)).ReturnsAsync(JobApplications);

            //Act
            var result = await service.GetById(id);


            //Assert

            result.JobApplicationId.Should().Be(id);
            _jobApplicationRepository.Verify(c => c.GetById(id), Times.Once);
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
            var service = new JobApplicationService(_logger.Object, _jobApplicationRepository.Object);
            var JobApplication = _fixture.Build<JobApplication>().Create();

            //Act
            await service.Update(JobApplication);

            //Assert
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Update] - Started, with ID: {JobApplication.JobApplicationId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Update] - Finish, with ID: {JobApplication.JobApplicationId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }

        [Test]
        public async Task ShouldRemoveWithSuccess()
        {
            //Arrange
            var service = new JobApplicationService(_logger.Object, _jobApplicationRepository.Object);
            var JobApplication = _fixture.Build<JobApplication>().Create();

            //Act

            await service.Remove(JobApplication.JobApplicationId);

            //Assert
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Remove] - Started, with ID: {JobApplication.JobApplicationId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Remove] - Finish, with ID: {JobApplication.JobApplicationId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }
    }
}