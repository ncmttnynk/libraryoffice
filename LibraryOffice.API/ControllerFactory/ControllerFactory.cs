using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GenericRestService.ControllerFactory;
using LibraryOffice.API.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
namespace LibraryOffice.API.ControllerFactory {
  public class GenericRestControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature> {
    public void PopulateFeature (IEnumerable<ApplicationPart> parts, ControllerFeature feature) {
      foreach (var model_type in EntityTypes.model_types) {
        Type[] typeArgs = { model_type.Value[0], model_type.Value[1] };
        var controller_type = typeof (GenericRestController<,>).MakeGenericType (typeArgs).GetTypeInfo ();
        feature.Controllers.Add (controller_type);
      }
    }
  }
}