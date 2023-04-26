using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADProProject.Models;

[Table("employees")]
public partial class Employee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string? Name { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("mobileno")]
    [StringLength(15)]
    public string? Mobileno { get; set; }

    [Column("address")]
    public string Address { get; set; } = null!;

    [Column("isactive")]
    public bool? Isactive { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
