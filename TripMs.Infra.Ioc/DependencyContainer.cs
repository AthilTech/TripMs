using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TripMs.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
       {


            #region Trip

              services.AddTransient<IRepository<Trip>, Repository<Trip>>();
              services.AddTransient<IRequestHandler<PostCommand<Trip>, string>, PostHandler<Trip>>();
              services.AddTransient<IRequestHandler<PutCommand<Trip>, string>, PutHandler<Trip>>();
              services.AddTransient<IRequestHandler<DeleteCommand<Trip>, string>, DeleteHandler<Trip>>();
          services.AddTransient<IRequestHandler<GetListQuery<Trip>, IEnumerable<Trip>>, GetListHandler<Trip>>();
          services.AddTransient<IRequestHandler<GetQuery<Trip>, Trip>, GetHandler<Trip>>();

            #endregion


        }
    }
}
