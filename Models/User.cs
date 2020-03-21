using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Reponsitory_Demo.Models
{
    public class User
    {
        [Key, Column(Order = 1)] // properties idUser is primary key
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] // chỉ định kiểu giá trị cho db
        public int idUser { get; set; }
        [Required]
        //StringLength(): có 2 parameter maximum length and MinimumLength
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        //RegularExpression: dùng biểu thức chính quy kiểm tra xem, người dùng có nhập đúng yêu cầu chưa.
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]

        public string Password { get; set; }
        //[NotMapped]: dùng biểu thức này, cho các trường thuộc tính không có trong table Users, 
        //nếu không có ta sẽ bị báo lỗi, vì model User sẽ đại diện cho từng cột dữ liệu trong table Use
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}