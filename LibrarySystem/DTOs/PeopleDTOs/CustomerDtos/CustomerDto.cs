using LibrarySystem.DTOs.People.PersonDtos;
using LibrarySystem.Models;
using LibrarySystem.DTOs.OperationDtos;
using System.ComponentModel.DataAnnotations;
namespace LibrarySystem.DTOs.People.CustomerDtos
{
    public class CustomerDto : PersonDto
    {
        [Required, EnumDataType(typeof(MembershipType))]
        public MembershipType MembershipType { get; set; }
        [Required]
        public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();

    }
}
