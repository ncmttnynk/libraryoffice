using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace GenericRestService.ControllerFactory {
  public static class EntityTypes {
    public static Dictionary<TypeInfo, List<TypeInfo>> model_types => new Dictionary<TypeInfo, List<TypeInfo>> () {
      {
      typeof (Book).GetTypeInfo (), new List<TypeInfo> () { typeof (Book).GetTypeInfo (), typeof (Guid).GetTypeInfo () }
      }
    };
  }
}