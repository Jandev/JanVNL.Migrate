using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Environment.ShellBuilders.Models;
using Orchard.Mvc.Routes;

namespace JanVNL.Migrate {
    public class Routes : IRouteProvider {
        
        public Routes() 
		{
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (RouteDescriptor routeDescriptor in GetRoutes()) {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
			return new[] {
                             new RouteDescriptor {
                                                     Priority = 5,
                                                     Route = new Route(
                                                         "Migrate",
                                                         new RouteValueDictionary {
                                                                                      {"area", "JanVNL.Migrate"},
                                                                                      {"controller", "Migrate"},
                                                                                      {"action", "index"}
                                                                                  },
                                                         null,
                                                         new RouteValueDictionary {
                                                                                      {"area", "JanVNL.Migrate"}
                                                                                  },
                                                         new MvcRouteHandler())
                                                 },
										new RouteDescriptor {
                                            Priority = 5,
                                            Route = new Route(
                                                         "Redirect",
                                                         new RouteValueDictionary {
                                                                                      {"area", "JanVNL.Migrate"},
                                                                                      {"controller", "Migrate"},
                                                                                      {"action", "redirect"}
                                                                                  },
                                                         null,
                                                         new RouteValueDictionary {
                                                                                      {"area", "JanVNL.Migrate"}
                                                                                  },
                                                         new MvcRouteHandler())
                                                 }
                         };
        }
    }
}