using LibrarySystem.Interfaces;
using LibrarySystem.Data; 
using LibrarySystem.Models;
using LibrarySystem.DTOs.OperationDtos;
using Microsoft.EntityFrameworkCore;
namespace LibrarySystem.Service
{
    public class OperationService : IOperationService
    {
        private readonly LibraryDbContext _context;

        public OperationService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task BorrowBookAsync(CreateOperationDto operationDto)
        {
            var book = await _context.TbBooksCopies
                .Where(a => a.BookId == operationDto.BookId && a.Status == Status.Available)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                throw new InvalidOperationException($"Book with ID {operationDto.BookId} is not available for borrowing,No copies available.");
            }

            var operation = new Operation
            {
                CustomerId = operationDto.CustomerId,
                EmployeeId = operationDto.EmployeeId, // Using the provided employee ID
                BookCopyId= book.Id, // Assign the ID of the available book copy
                DeadLine = operationDto.DeadLine,
                PaymentMethod = operationDto.PaymentMethod,
                OperationType = operationDto.OperationType
            };
            book.Status = Status.Borrowed;
            await _context.TbOperations.AddAsync(operation);
            await _context.SaveChangesAsync();


        }
        public async Task ReturnBookAsync(int operationId)
        {
            var operation = await _context.TbOperations
                .Include(o => o.BookCopy)
                .FirstOrDefaultAsync(o => o.Id == operationId);
            if (operation == null)
            {
                throw new InvalidOperationException($"Operation with ID {operationId} not found.");
            }
            if (operation.OperationType != OperationType.Borrow)
            {
                throw new InvalidOperationException($"Operation with ID {operationId} is not a borrow operation.");
            }
            operation.BookCopy.Status = Status.Available;
            operation.IsReturned = true;
            await _context.SaveChangesAsync();

        }

        public async Task BuyBookAsync(CreateOperationDto operationDto)
        {
            var book = await _context.TbBooksCopies
                .Where(a => a.BookId == operationDto.BookId && a.Status == Status.Available)
                .FirstOrDefaultAsync();
            if (book == null)
            {
                throw new InvalidOperationException($"Book with ID {operationDto.BookId} is not available for buying,No copies available.");
            }
            var operation = new Operation
            {
                CustomerId = operationDto.CustomerId,
                EmployeeId = operationDto.EmployeeId, // Using the provided employee ID
                DeadLine = operationDto.DeadLine,
                PaymentMethod = operationDto.PaymentMethod,
                OperationType = operationDto.OperationType
            };
            book.Status = Status.Sold;
            await _context.TbOperations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task RefundBookAsync(CreateOperationDto operationDto)
        {
            var operation = new Operation
            {
                CustomerId = operationDto.CustomerId,
                EmployeeId = operationDto.EmployeeId,
                DeadLine = operationDto.DeadLine,
                BookCopyId=operationDto.BookId,
                PaymentMethod = operationDto.PaymentMethod,
                OperationType = OperationType.Refund
            };
            var bookCopy = await _context.TbBooksCopies
                .Where(b => b.Id == operationDto.BookId)
                .FirstOrDefaultAsync();
            if (bookCopy == null)
            {
                throw new Exception($"Book copy with ID {operationDto.BookId} not found.");
            }
            bookCopy.Status = Status.Available;

            await _context.TbOperations.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        
        public async Task<IEnumerable<OperationDto>> GetAllOperationsAsync()
        {
            var operations = await _context.TbOperations
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.BookCopy)
                .Select(o => new OperationDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    BookCopyId = o.BookCopyId,
                    DeadLine = o.DeadLine,
                    PaymentMethod = o.PaymentMethod,
                    OperationType = o.OperationType
                })
                .ToListAsync();

            if (operations.Count == 0)
            {
                throw new InvalidOperationException("No operations found.");
            }

            return operations;
        }

        public async Task<OperationDto?> GetOperationByIdAsync(int operationId)
        {
            var operation = await _context.TbOperations
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.BookCopy)
                .Where(o => o.Id == operationId)
                .Select(o => new OperationDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    BookCopyId = o.BookCopyId,
                    DeadLine = o.DeadLine,
                    PaymentMethod = o.PaymentMethod,
                    OperationType = o.OperationType
                })
                .FirstOrDefaultAsync();
            if (operation == null)
            {
                throw new InvalidOperationException($"Operation with ID {operationId} not found.");
            }
            return operation;

        }

        public async Task<IEnumerable<OperationDto>> GetOperationsByCustomerAsync(int customerId)
        {
            var operations = await _context.TbOperations
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.BookCopy)
                .Where(o => o.CustomerId == customerId)
                .Select(o => new OperationDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    BookCopyId = o.BookCopyId,
                    DeadLine = o.DeadLine,
                    PaymentMethod = o.PaymentMethod,
                    OperationType = o.OperationType
                })
                .ToListAsync();

            if (operations.Count == 0)
            {
                throw new InvalidOperationException($"No operations found for customer with ID {customerId}.");
            }
            return operations;
        }

        public async Task<IEnumerable<OperationDto>> GetOperationsByEmployeeAsync(int employeeId)
        {
            var operations = await _context.TbOperations
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.BookCopy)
                .Where(o => o.EmployeeId == employeeId)
                .Select(o => new OperationDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    BookCopyId = o.BookCopyId,
                    DeadLine = o.DeadLine,
                    PaymentMethod = o.PaymentMethod,
                    OperationType = o.OperationType
                })
                .ToListAsync();
            if (operations.Count == 0)
            {
                throw new InvalidOperationException($"No operations found for employee with ID {employeeId}.");
            }
            return operations;
        }
        public async Task<IEnumerable<OperationDto>> GetActiveBorrowOperationsAsync()
        {
            var operations = await _context.TbOperations
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.BookCopy)
                .Where(o => o.OperationType == OperationType.Borrow && o.BookCopy.Status == Status.Borrowed&&o.IsReturned==false)
                .Select(o => new OperationDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    BookCopyId = o.BookCopyId,
                    DeadLine = o.DeadLine,
                    PaymentMethod = o.PaymentMethod,
                    OperationType = o.OperationType
                })
                .ToListAsync();

            if (operations.Count == 0)
            {
                throw new InvalidOperationException($"No active borrow operations found.");
            }
            return operations;
        }

        public async Task<IEnumerable<OperationDto>> GetReturnedOperationsAsync()
        {
            var operation  = await _context.TbOperations
                .Where(o=> o.IsReturned==true)
                .Select (o => new OperationDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    BookCopyId = o.BookCopyId,
                    DeadLine = o.DeadLine,
                }) .ToListAsync(); 

            if (operation.Count == 0)
            {
                throw new InvalidOperationException($"No returned operations found."); 
            }
            return operation;
        }

        public async Task<IEnumerable<OperationDto>> GetOperationsByBookCopyAsync(int bookCopyId)
        {
            var books = await _context.TbOperations
                .Where (o=> o.BookCopyId == bookCopyId)
                .Select(o=> new OperationDto
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    BookCopyId = o.BookCopyId,
                    DeadLine = o.DeadLine,
                    PaymentMethod = o.PaymentMethod,
                    OperationType = o.OperationType
                } ) .ToListAsync();

            if (books.Count == 0)
            {
                throw new ArgumentException($"No operations found for book copy with ID {bookCopyId}.");
            }

                return books;
        }

    }
}