using System;
using System.Collections.Generic;
using System.Reflection;
namespace GenericRestService.ControllerFactory {
  public static class EntityTypes {
    public static Dictionary<TypeInfo, List<TypeInfo>> model_types => new Dictionary<TypeInfo, List<TypeInfo>> () {
      {
      typeof (Book).GetTypeInfo (), new List<TypeInfo> () { typeof (Book).GetTypeInfo (), typeof (Guid).GetTypeInfo () }
      }, {
      typeof (Publisher).GetTypeInfo (),
      new List<TypeInfo> () { typeof (Publisher).GetTypeInfo (), typeof (Guid).GetTypeInfo () }
      }
    };
  }
}