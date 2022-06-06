using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiSample.Interfaces
{
    public interface IRouteableService
    {
        void MapRoutes(WebApplication app);
    }
}
