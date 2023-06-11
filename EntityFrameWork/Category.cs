using System;
using System.Collections.Generic;

namespace EntityFrameWork;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? NumArticals { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual ICollection<WordToCategory> WordToCategories { get; set; } = new List<WordToCategory>();
}
