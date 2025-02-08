using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class OrderCustomer
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public string ImageName { get; set; } = null!;

    public DateTime? DateRegister { get; set; }

    public int? IdCategory { get; set; }

    public int? IdUser { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<LogOrderCustomer> LogOrderCustomers { get; set; } = new List<LogOrderCustomer>();
}
