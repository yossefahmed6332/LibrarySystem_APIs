using LibrarySystem.DTOs.OperationDtos; 
namespace LibrarySystem.Interfaces
{
    public interface IOperationService
    {
        // Borrow
        Task<bool> BorrowBookAsync(int customerId, int bookCopyId);

        // Return
        Task<bool> ReturnBookAsync(int operationId);

        // Read
        Task<IEnumerable<OperationDto>> GetAllOperationsAsync();
        Task<OperationDto?> GetOperationByIdAsync(int operationId);
        Task<IEnumerable<OperationDto>> GetOperationsByCustomerAsync(int customerId);
        Task<IEnumerable<OperationDto>> GetOperationsByEmployeeAsync(int employeeId);
        Task<IEnumerable<OperationDto>> GetActiveBorrowOperationsAsync();
        Task<IEnumerable<OperationDto>> GetReturnedOperationsAsync();
        Task<IEnumerable<OperationDto>> GetOverdueOperationsAsync();

    }
}
