using AutoFixture;
using Challenge.TOTVS.Domain.Interfaces.Repositories;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Services.Services;
using Moq;
using NUnit.Framework;

namespace Challenge.TOTVS.Tests.Services
{
    public class CandidateServiceTest
    {
        private Mock<ICandidateRepository> _candidateRepository;
        private Fixture _fixture; 

        [SetUp]
        public void SetUp()
        {
            _candidateRepository = new();
            _fixture = new();
        }

        [Test] 
        public async Task ShouldAddWithSuccess()
        {
            //Arrange
            var service = new CandidateService(_candidateRepository.Object);
            var candidate = _fixture.Build<Candidate>().Create();
            
            //Act

            await service.Add(candidate);

            //Assert

        }
    }
}