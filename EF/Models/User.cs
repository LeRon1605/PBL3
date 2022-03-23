﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF.Models
{
    [Serializable]
    public class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [DisplayName("Họ và tên")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Tên người dùng phải có độ dài từ 10 - 50")]
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        public string Name { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ người dùng không được để trống")]
        public string Address { get; set; }
        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Giới tính không được để trống")]
        [RegularExpression("Nam|Nữ", ErrorMessage = "Invalid Status")]
        public string Gender { get; set; }
        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birth { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }

        [DisplayName("Địa chỉ Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ")]
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Mật khẩu chỉ chứa kí tự")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Mật khẩu có độ dài từ 8 - 32")]
        public string Password { get; set; }
        public bool isActivated { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }
        public List<Order> Orders { get; set; }
        public List<Comment> Comments { get; set; }
    }
}