using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class MenuOption
{
    public int Id { get; set; }

    public string NameOption { get; set; } = null!;

    public string IconName { get; set; } = null!;

    public DateTime? DateRegister { get; set; }

    public bool? StatusOption { get; set; }

    public virtual ICollection<SubMenu> SubMenus { get; set; } = new List<SubMenu>();
}
