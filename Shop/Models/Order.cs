using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shop.Models;
using System.ComponentModel.DataAnnotations;





namespace Shop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введіть ім'я")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина імені повинна бути не менше 5 символів")]
        public string Name { get; set; }

        [Display(Name = "Прізвище")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина прізвища повинна бути не менше 5 символів")]
        public string SurName { get; set; }

        [Display(Name = "Адреса")]
        [StringLength(35)]
        [Required(ErrorMessage = "Довжина адреси повинна бути не менше 5 символів")]
        public string Adress { get; set; }

        [Display(Name = "Номер телефону")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Довжина номера повинна бути не менше 10 знаків")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина email повинна бути не менше 15 символів")]
        public string Email { get; set; }

        [StringLength(20)]
        public string CommunicationType { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}