using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Presentaion.AppMetaData
{
    public static class Router
    {
        private const string DefaultRoot = "Api";
        private const string Version = "V1";
        private const string DefatultRule = $"{DefaultRoot}/{Version}/";

        //Assoicate to the Student Apis.
        public static class  StudentRouting
        {
            private const string DefaultPrefix = $"{DefatultRule}Student";      
            public const string GetStudentsList = $"{DefaultPrefix}/get-all-students";
            public const string GetStudentById = $"{DefaultPrefix}/get-student";
            public const string CreateStudent = $"{DefaultPrefix}/create-new-student";
            public const string UpdateStudent= $"{DefaultPrefix}/update-student";
            public const string GetStudentPaginaedList= $"{DefaultPrefix}/get-student-paginaed-list";
        }

        public static class UserRouting
        {
            private const string DefaultPrefix = $"{DefatultRule}User";
            public const string RegisterUser = $"{DefaultPrefix}/register-new-user";
        }

    }
}
