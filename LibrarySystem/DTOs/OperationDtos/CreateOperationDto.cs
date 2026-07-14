using LibrarySystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.OperationDtos
{
    public class CreateOperationDto
    {
        [Required, Range(1, int.MaxValue)]
        public int CustomerId { get; set; }
        [Required, Range(1, int.MaxValue)]
        public int BookCopyId { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required, EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; }
        [Required, EnumDataType(typeof(OperationType))]
        public OperationType OperationType { get; set; }
    }
}
