using System.Collections.Generic;
using System.Threading.Tasks;
using GenericRestService.ControllerFactory;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOffice.API.Controllers {
  [ApiController]
  [GenericRestControllerNameConvention]
  [Route ("[controller]")]
  public class GenericRestController<T, IdType> : ControllerBase where T : class, IEntity<IdType> {
    private IBaseService<T, IdType> _baseService { get; set; }
    public GenericRestController (IBaseService<T, IdType> baseService) {
      _baseService = baseService;
    }

    [HttpGet]
    public ICollection<T> find () {
      return _baseService.find ();
    }

    [HttpGet]
    [Route ("{id}")]
    public T findById (IdType id) {
      return _baseService.findById (id);
    }
  }
}