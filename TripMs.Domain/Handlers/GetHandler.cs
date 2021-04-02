using TripMs.Domain.Interfaces;
using TripMs.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TripMs.Domain.Handlers
{
    public class GetHandler<T> : IRequestHandler<GetQuery<T>, T> where T : class
    {
        private readonly IRepository<T> repository;
        public GetHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }

        public Task<T> Handle(GetQuery<T> request, CancellationToken cancellationToken)
        {

            var result = repository.Get(request.Condition, request.Includes);
            return Task.FromResult(result);
        }

    }
}
