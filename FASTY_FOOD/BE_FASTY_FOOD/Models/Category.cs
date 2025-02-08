using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class Category
{
    public int Id { get; set; }

    public string NameCategory { get; set; } = null!;

    public DateTime? DateRegister { get; set; }

    public bool? StatusCategory { get; set; }

    public virtual ICollection<OrderCustomer> OrderCustomers { get; set; } = new List<OrderCustomer>();
}
