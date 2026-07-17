using LibrarySystem.DTOs.OperationDtos; 
namespace LibrarySystem.Interfaces
{
    public interface IOperationService
    {
        // Borrow
        public Task BorrowBookAsync(CreateOperationDto operationDto);

        // Return
        public Task ReturnBookAsync(int operationId);
        //Buy 
        public Task BuyBookAsync(CreateOperationDto operationDto);
        //Refund
        public Task RefundBookAsync(CreateOperationDto operationDto);

        // Read
        public Task<IEnumerable<OperationDto>> GetAllOperationsAsync();
        public Task<OperationDto?> GetOperationByIdAsync(int operationId);
        public Task<IEnumerable<OperationDto>> GetOperationsByCustomerAsync(int customerId);
        public Task<IEnumerable<OperationDto>> GetOperationsByEmployeeAsync(int employeeId);
        public Task<IEnumerable<OperationDto>> GetActiveBorrowOperationsAsync();
        public Task<IEnumerable<OperationDto>> GetReturnedOperationsAsync();
        public Task<IEnumerable<OperationDto>> GetOperationsByBookCopyAsync(int bookCopyId);



    }
}
