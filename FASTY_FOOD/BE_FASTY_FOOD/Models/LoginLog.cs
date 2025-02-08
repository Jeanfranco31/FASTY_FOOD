using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class LoginLog
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public int? Attemp { get; set; }

    public DateTime? DateLogged { get; set; }

    public bool? StatusAccount { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
