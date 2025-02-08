using System;
using System.Collections.Generic;

namespace BE_FASTY_FOOD.Models;

public partial class LogOrderCustomer
{
    public int Id { get; set; }

    public int? IdOrderCustomer { get; set; }

    public int? IdUser { get; set; }

    public virtual OrderCustomer? IdOrderCustomerNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
