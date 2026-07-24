using LibrarySystem.DTOs.OperationDtos;
using LibrarySystem.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] CreateOperationDto dto)
        {
             await _operationService.BorrowBookAsync(dto);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook([FromBody] int operationId)
        {
             await _operationService.ReturnBookAsync(operationId);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Buy")]
        public async Task<IActionResult> BuyBook([FromBody] CreateOperationDto dto)
        {
            await _operationService.BuyBookAsync(dto);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("refund")]
        public async Task<IActionResult> RefundBook([FromBody] CreateOperationDto dto)
        {
            await _operationService.RefundBookAsync(dto);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var operations = await _operationService.GetAllOperationsAsync();
            return Ok(operations);

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var operation = await _operationService.GetOperationByIdAsync(id);
            return Ok(operation);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Customer/{customerId}")]
        public async Task<IActionResult> GetOperationsByCustomer(int customerId)
        {
            var operations = await _operationService.GetOperationsByCustomerAsync(customerId);
            return Ok(operations);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Employee/{employeeId}")]
        public async Task<IActionResult> GetOperationsByEmployee(int employeeId)
        {
            var operations = await _operationService.GetOperationsByEmployeeAsync(employeeId);
            return Ok(operations);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("ActiveBorrowed")]
        public async Task<IActionResult> GetActiveBorrowOperations()
        {
            var operations = await _operationService.GetActiveBorrowOperationsAsync();
            return Ok(operations);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("Returned")]
        public async Task<IActionResult> GetReturnedOperations()
        {
            var operations = await _operationService.GetReturnedOperationsAsync();
            return Ok(operations);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("BookCopy/{bookCopyId}")]
        public async Task<IActionResult> GetOperationsByBookCopy(int bookCopyId)
        {
            var operations = await _operationService.GetOperationsByBookCopyAsync(bookCopyId);
            return Ok(operations);
        }

    }
}
