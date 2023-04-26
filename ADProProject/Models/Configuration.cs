using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADProProject.Models;

[Table("configuration")]
public partial class Configuration
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cname")]
    [StringLength(100)]
    public string? Cname { get; set; }

    [Column("cvalue")]
    public string? Cvalue { get; set; }
}
