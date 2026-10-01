using Application.Contracts;
using Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerService loggerService;

        public CompanyService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            this.unitOfWork = unitOfWork;
            this.loggerService = loggerService;
        }
    }
}
