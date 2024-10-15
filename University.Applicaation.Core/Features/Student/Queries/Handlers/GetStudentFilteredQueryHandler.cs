//using AutoMapper;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using University.Application.Layer.Common.Bases;
//using University.Application.Layer.Common.Interfaces;
//using University.Application.Layer.Features.Students.Queries.Models;
//using University.Application.Layer.Features.Students.Queries.Results;
//using University.Application.Layer.Helpers;
//using University.Domain.Layer.Enities;

//namespace University.Application.Layer.Features.Students.Queries.Handlers
//{
//    public class GetStudentFilteredQueryHandler : IRequestHandler<GetStudentFilteredQuery, Response<IQueryable<Student>>>
//    {
//        private readonly IStudentRepositry _studentRepositry;
//        private readonly IMapper _mapper;
//        public GetStudentFilteredQueryHandler(IStudentRepositry studentRepositry,IMapper mapper)
//        {
//            _studentRepositry = studentRepositry;
//            _mapper = mapper;
//        }
//        public async Task<Response<IQueryable<Student>>> Handle(GetStudentFilteredQuery request, CancellationToken cancellationToken)
//        {
//            var students = _studentRepositry
//                          .GetAllNoTracking();
//            if (!string.IsNullOrEmpty(request.SerachTerm)) students = students.Where(stud=>stud.UserName ==request.SerachTerm);

//            if(request.OrderBy!=null)
//            {
//                switch (request.OrderBy)
//                {
//                    case OrderStudentEnum.studID:
//                        students = students.OrderByDescending(stud => stud.Id);
//                        break;
//                    case OrderStudentEnum.studName:
//                        students = students.OrderByDescending(stud => stud.UserName);
//                        break;
//                    _: throw new NotImplementedException();
//                }
//            }
//            return ResponseHandler.Success(students);
//        }
//    }
//}
