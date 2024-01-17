using System;
using System.Collections.Generic;

namespace DatabaseCompiledModels.Models;

public partial class TestValue
{
    public int Id { get; set; }

    public string TestValue1 { get; set; } = null!;

    public virtual ICollection<TestV> TestVs { get; set; } = new List<TestV>();
}
