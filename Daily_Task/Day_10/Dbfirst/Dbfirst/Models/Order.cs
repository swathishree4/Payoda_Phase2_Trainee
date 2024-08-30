using System;
using System.Collections.Generic;

namespace Dbfirst.Models;

public partial class Order
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string? ProductName { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual Customer IdNavigation { get; set; } = null!;
}
