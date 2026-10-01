using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }
    }
}
