using System;
using System.Collections.Generic;

namespace Dbfirst.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Location { get; set; }

    public virtual Order? Order { get; set; }
}
