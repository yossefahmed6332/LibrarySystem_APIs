using LibrarySystem.DTOs.People.PersonDtos;
using LibrarySystem.Models;
using System.ComponentModel.DataAnnotations;
namespace LibrarySystem.DTOs.People.CustomerDtos
{
    public class UpdateCustomerDto : UpdateUserDto
    {
        [Required, EnumDataType(typeof(MembershipType))]
        public MembershipType MembershipType { get; set; }
    }
}
