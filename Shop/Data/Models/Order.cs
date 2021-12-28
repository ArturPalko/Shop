using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Shop.Data.Models
{
    public class Order
    {

        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введіть ім'я")]
        [StringLength(5)]
        [Required(ErrorMessage ="Довжина імені не меньше 5 символів")]
        public string name { get; set; }

        [Display(Name = "Прізвище")]
        [StringLength(5)]
        [Required(ErrorMessage = "Довжина прізвища не меньше 5 символів")]
        public string surname { get; set; }

        [Display(Name = "Адреса")]
        public string adress { get; set; }

        [Display(Name = "Номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(5)]
        [Required(ErrorMessage = "Довжина номера не меньше 10 символів")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(15)]
        [Required(ErrorMessage = "Довжина enmail не меньше 5 символів")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }

    }
}