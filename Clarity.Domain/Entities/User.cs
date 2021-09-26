using Clarity.Domain.Entities;
using System;

namespace Clarity.Domain.Entities
{
    public class User
    {
      public Guid UID { get; set; }
      public string Name { get; set; }
      public int Age { get; set; }
      public Wallet Wallet { get; set; }

    }
}