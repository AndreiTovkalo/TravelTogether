using System.Collections.Generic;
using System.Threading.Tasks;
using TravelTogether.Application.Features.Employees.Queries.GetEmployees;
using TravelTogether.Application.Parameters;
using TravelTogether.Domain.Entities;

namespace TravelTogether.Application.Interfaces.Repositories
{
    /// <summary>
    /// Interface for retrieving paged employee response asynchronously.
    /// </summary>
    /// <param name="requestParameters">The request parameters.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public interface IEmployeeRepositoryAsync : IGenericRepositoryAsync<Employee>
    {
        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedEmployeeResponseAsync(GetEmployeesQuery requestParameters);
    }
}