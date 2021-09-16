using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clarity.Presentation.Models
{
    public class SaveUserProfileRequest
    {

        public Guid UID { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
