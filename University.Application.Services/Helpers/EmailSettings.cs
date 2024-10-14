using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Layer.Helpers
{
    public  class EmailSettings
    {
        public string Host { get; set; } = null!;
        public string Password { get; set; } = null!;

        public int Port { get; set; }

        public string FromEmail { get; set; } = null!;
    }
}
