using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Layer.Enities;

namespace University.Application.Layer.Common.Interfaces
{
    public interface ICourseRepository:IGenericRepositoryAsync<Course>
    {
    }
}
