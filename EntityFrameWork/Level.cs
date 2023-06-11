using System;
using System.Collections.Generic;

namespace EntityFrameWork;

public partial class Level
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NumOfWords { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<VocabularyToAriacle> VocabularyToAriacles { get; set; } = new List<VocabularyToAriacle>();
}
