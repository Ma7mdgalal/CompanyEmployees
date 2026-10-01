using Application.Contracts;
using Application.Contracts.Services;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerService loggerService;

        public EmployeeService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            this.unitOfWork = unitOfWork;
            this.loggerService = loggerService;
        }
    }
}
