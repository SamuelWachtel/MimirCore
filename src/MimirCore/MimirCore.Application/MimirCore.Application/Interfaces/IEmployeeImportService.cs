using MimirCore.Application.Models;
using MimirCore.Application.Models.Common;
using MimirCore.Application.Models.Employee;

namespace MimirCore.Application.Interfaces;

public interface IEmployeeImportService
{
    Task<ImportResult> ImportFromExcelAsync(Stream fileStream);
    Task<ImportResult> ImportFromCsvAsync(Stream fileStream);
    Task<ImportResult> ValidateImportDataAsync(IEnumerable<EmployeeImportDto> employees);
}