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
    public class CandidateServiceTest
    {
        private Mock<ICandidateRepository> _candidateRepository = default!;
        private Mock<ILogger<CandidateService>> _logger = default!;
        private Fixture _fixture = default!; 

        [SetUp]
        public void SetUp()
        {
            _logger = new();
            _candidateRepository = new();
            _fixture = new();
        }

        [Test] 
        public async Task ShouldAddWithSuccess()
        {
            //Arrange
            var service = new CandidateService(_logger.Object, _candidateRepository.Object);
            var candidate = _fixture.Build<Candidate>().Create();
            
            //Act

            await service.Add(candidate);

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
            var service = new CandidateService(_logger.Object, _candidateRepository.Object);
             var candidates = _fixture.Build<Candidate>().CreateMany(2).ToList();

            _candidateRepository.Setup(c => c.GetAll()).ReturnsAsync(candidates);

            //Act
            var result = await service.GetAll();


            //Assert

            result.Should().HaveCount(2);
            _candidateRepository.Verify(c => c.GetAll(), Times.Once);
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
            var service = new CandidateService(_logger.Object, _candidateRepository.Object);
            var candidates = _fixture.Build<Candidate>().With(c => c.CandidateId, id).Create();

            _candidateRepository.Setup(c => c.GetById(id)).ReturnsAsync(candidates);

            //Act
            var result = await service.GetById(id);


            //Assert

            result.CandidateId.Should().Be(id);
            _candidateRepository.Verify(c => c.GetById(id), Times.Once);
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
            var service = new CandidateService(_logger.Object, _candidateRepository.Object);
            var candidate = _fixture.Build<Candidate>().Create();

            //Act
            await service.Update(candidate);

            //Assert
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Update] - Started, with ID: {candidate.CandidateId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Update] - Finish, with ID: {candidate.CandidateId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }

        [Test]
        public async Task ShouldRemoveWithSuccess()
        {
            //Arrange
            var service = new CandidateService(_logger.Object, _candidateRepository.Object);
            var candidate = _fixture.Build<Candidate>().Create();

            //Act

            await service.Remove(candidate.CandidateId);

            //Assert
            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Remove] - Started, with ID: {candidate.CandidateId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

            _logger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals($"[Remove] - Finish, with ID: {candidate.CandidateId}", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);

        }
    }
}