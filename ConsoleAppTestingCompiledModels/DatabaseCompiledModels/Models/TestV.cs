using System;
using System.Collections.Generic;

namespace DatabaseCompiledModels.Models;

public partial class TestV
{
    public int Id { get; set; }

    public int TestValueId { get; set; }

    public string TestValues { get; set; } = null!;

    public virtual TestValue TestValue { get; set; } = null!;
}
