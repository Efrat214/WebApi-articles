using System;
using System.Collections.Generic;

namespace EntityFrameWork;

public partial class WordToCategory
{
    public int Id { get; set; }

    public string Word { get; set; } = null!;

    public int Category { get; set; }

    public int Count { get; set; }

    public int Frequency { get; set; }

    public virtual Category CategoryNavigation { get; set; } = null!;
}
