using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class User
{
    public int Id { get; set; }

    public string IdNumber { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public DateTime DateRegister { get; set; }

    public bool? StatusUser { get; set; }

    public int? IdRol { get; set; }

    public int? IdCompany { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<LogOrderCustomer> LogOrderCustomers { get; set; } = new List<LogOrderCustomer>();

    public virtual ICollection<LoginLog> LoginLogs { get; set; } = new List<LoginLog>();

    public virtual ICollection<OrderCustomer> OrderCustomers { get; set; } = new List<OrderCustomer>();
}
