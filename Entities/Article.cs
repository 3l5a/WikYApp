using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;
public class Article
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Vous devez indiquer un thème")]
    //[Compare("ThemeVerif")]
    [Remote("IsThemeUnique", "Article", ErrorMessage = "Ce thème est déjà pris")]
    public string Theme { get; set; }

    [Required]
    [StringLength(30)]
    public string AuthorName { get; set; }

    public DateTime DateCreated { get; set; } 

    public DateTime DateUpdated { get; set; }

    [Required]
    public string Content { get; set; }

    public virtual List<Comment> Comments { get; set; } = [];
}
