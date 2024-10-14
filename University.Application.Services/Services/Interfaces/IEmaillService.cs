using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Layer.Services.Interfaces
{
    public interface IEmaillService
    {
        public Task<string> SendEmailAsync(string email,string message);
    }
}
