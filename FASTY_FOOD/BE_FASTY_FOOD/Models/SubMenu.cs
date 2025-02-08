using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class SubMenu
{
    public int Id { get; set; }

    public string NameSubOption { get; set; } = null!;

    public DateTime? DateRegister { get; set; }

    public int? IdOption { get; set; }

    public virtual MenuOption? IdOptionNavigation { get; set; }
}
