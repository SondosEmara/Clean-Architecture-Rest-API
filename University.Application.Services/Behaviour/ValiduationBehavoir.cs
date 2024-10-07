using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Layer.Behaviour
{
    //Task 1(AddStudentCommand) / Task 2 (GetStudentByIdQuery) that in Pipline For each Task Before Handle the task and enter to call the services need to go first to the 
    //Handle Function  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    //To Check if exist any validation erorr of the input DTO

    //NOTE.............for only the request in the mediator not any request 
    //That handle for each request of the command/query
    //THat will be if the trequest is IRequest only
    //IPipelineBehavior that correspond to the MedatorR

    //If I have IValidator<STudentCommand> and the StudentCommand  not have a  absrtract validation not make error but the validators is null..

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ////that request 
            //Console.WriteLine($"Handling {typeof(TRequest).Name}");
            ////Because it is delegate next() call the handle function name ex:StudentCommandHandler.Handle
            //var response = await next();
            ////That the response
            //Console.WriteLine($"Handled {typeof(TResponse).Name}");
            //return response;
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select(x => x.PropertyName + ": " + x.ErrorMessage).FirstOrDefault();

                    throw new ValidationException(message);
                }
            }
            return await next();
        }
    }


}
