using DryIoc;
using Bell.Common.DryIoc;
using Bell.Common.Exceptions;
using Bell.Common.Resources;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Bell.WebApi.Json
{
    public class JsonInterfaceBinder<TObjectType> : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (DryIocConfiguration.Container == null)
            {
                throw new BellCommonException(
                    ErrorMessageKeys.DRYIOC_CONFIGURATION_CONTAINER_SHOULD_NOT_BE_NULL);
            }

            if (bindingContext.ModelType is TObjectType)
            {
                var concreteTypeNeeded = DryIocConfiguration.Container.Resolve<TObjectType>().GetType();

                bindingContext.Model = DryIocConfiguration.Container.Resolve<TObjectType>();

                ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            }

            await Task.CompletedTask;
        }
    }

}
