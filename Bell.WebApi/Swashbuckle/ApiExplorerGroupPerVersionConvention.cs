using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Bell.WebApi.Swashbuckle
{
    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        /// <summary>
        /// Pulls the version off of a controller's namespace and groups it
        /// in the corresponding API group
        /// </summary>
        public void Apply(ControllerModel controller)
        {
            // Pulls the 
            var controllerNamespace = controller.ControllerType.Namespace; 
            var apiVersion = controllerNamespace.Split('.').Last().ToLower();

            controller.ApiExplorer.GroupName = apiVersion;
        }
    }
}
