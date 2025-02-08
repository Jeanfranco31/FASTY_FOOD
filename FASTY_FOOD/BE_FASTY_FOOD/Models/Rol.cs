using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Rolname { get; set; } = null!;

    public DateTime? DateRegister { get; set; }

    public bool? StatusRol { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
