using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADProProject.Models;

[Table("menus")]
public partial class Menu
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(100)]
    public string? Title { get; set; }

    [Column("link")]
    [StringLength(100)]
    public string? Link { get; set; }

    [Column("icon")]
    [StringLength(100)]
    public string? Icon { get; set; }

    [Column("srno")]
    public int? Srno { get; set; }

    [Column("parentmenuid")]
    public int? Parentmenuid { get; set; }

    [InverseProperty("Menu")]
    public virtual ICollection<Rolemenu> Rolemenus { get; set; } = new List<Rolemenu>();
}
