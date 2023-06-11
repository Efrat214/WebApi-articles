using System;
using System.Collections.Generic;

namespace EntityFrameWork;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string Mail { get; set; } = null!;

    public int? Level { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual ICollection<ArticaleToUser> ArticaleToUsers { get; set; } = new List<ArticaleToUser>();

    public virtual Level? LevelNavigation { get; set; }
}
