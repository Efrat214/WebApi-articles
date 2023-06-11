using System;
using System.Collections.Generic;

namespace EntityFrameWork;

public partial class VocabularyToAriacle
{
    public int Id { get; set; }

    public int? Articale { get; set; }

    public int? Level { get; set; }

    public string? Word { get; set; }

    public virtual Article? ArticaleNavigation { get; set; }

    public virtual Level? LevelNavigation { get; set; }
}
