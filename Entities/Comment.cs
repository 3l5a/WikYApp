using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities;
public class Comment
{
    public int Id { get; set; }

    [Required]
    public string AuthorName { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    [Required]
    [StringLength(100)]
    public string Content { get; set; }

    public int ArticleId { get; set; }

    public virtual Article Article { get; set; }
}
