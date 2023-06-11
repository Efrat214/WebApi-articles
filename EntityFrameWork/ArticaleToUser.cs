using System;
using System.Collections.Generic;

namespace EntityFrameWork;

public partial class ArticaleToUser
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? Articale { get; set; }

    public virtual Article? ArticaleNavigation { get; set; }

    public virtual User? User { get; set; }
}
