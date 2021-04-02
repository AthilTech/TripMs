using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TripMs.Domain.Commands
{
    public class PutCommand<T> : IRequest<string> where T : class
    {

        public T Obj { get; }
        public PutCommand(T obj)
        {
            Obj = obj;
        }


    }

}
