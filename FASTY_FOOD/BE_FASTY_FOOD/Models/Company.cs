using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Ruc { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime? DateRegister { get; set; }

    public bool? StatusCompany { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
