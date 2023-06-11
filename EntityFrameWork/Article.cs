using System;
using System.Collections.Generic;

namespace EntityFrameWork;

public partial class Article
{
    public int Id { get; set; }

    public int? Category { get; set; }

    public string Link { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual ICollection<ArticaleToUser> ArticaleToUsers { get; set; } = new List<ArticaleToUser>();

    public virtual Category? CategoryNavigation { get; set; }

    public virtual ICollection<VocabularyToAriacle> VocabularyToAriacles { get; set; } = new List<VocabularyToAriacle>();
}
