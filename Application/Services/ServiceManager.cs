using Application.Contracts;
using Application.Contracts.Services;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        public ServiceManager(IUnitOfWork unitOfWork, ILoggerService loggerService)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(unitOfWork, loggerService));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(unitOfWork, loggerService));
        }

        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
