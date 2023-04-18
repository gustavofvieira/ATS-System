﻿using Challenge.TOTVS.Domain.Exceptions;
using Challenge.TOTVS.Domain.Interfaces.Repositories.Auth;
using Challenge.TOTVS.Domain.Interfaces.Services;
using Challenge.TOTVS.Domain.Models;
using Challenge.TOTVS.Domain.Models.Auth;
using Microsoft.Extensions.Logging;

namespace Challenge.TOTVS.Services.Services
{
    public class RecoverPasswordService : IRecoverPasswordService
    {
        private readonly ILogger _logger;
        private readonly IRecoverPasswordRepository _recoverPasswordRepository;

        public RecoverPasswordService(
            ILogger<RecoverPasswordService> logger,
            IRecoverPasswordRepository recoverPasswordRepository)
        {
            _logger = logger;
            _recoverPasswordRepository = recoverPasswordRepository;
        }

        public async Task<Guid> CreateRecoverPassword(User user)
        {
            var recoverId = Guid.NewGuid();
            var recover = new RecoverPassword { RecoverPasswordId = recoverId, UserId = user.UserId, EmailAddress = user.EmailAddress };

            await _recoverPasswordRepository.Add(recover);

            return recoverId;
        }

        public async Task<RecoverPassword> ValidExpirateDate(Guid id)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(ValidExpirateDate), id);
            var recover = await _recoverPasswordRepository.GetById(id);
            if (recover is null)
                throw new DomainException("Recover password not found!");
            if (recover.ExpirateAt <= DateTime.UtcNow)
                throw new RecoverPasswordException("Link to recover password expirated, send request again!");
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(ValidExpirateDate), id);
            return recover;
        }

        public async Task<RecoverPassword> GetById(Guid id)
        {
            _logger.LogInformation("[{Mehtod}] - Started, with ID: {id}", nameof(GetById), id);
            var recoverPassword = await _recoverPasswordRepository.GetById(id);
            _logger.LogInformation("[{Mehtod}] - Finish, with ID: {id}", nameof(GetById), id);
            return recoverPassword;
        }
    }
}
