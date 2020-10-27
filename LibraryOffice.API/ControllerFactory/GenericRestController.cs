using System.Collections.Generic;
using System.Threading.Tasks;
using GenericRestService.ControllerFactory;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOffice.API.Controllers {
  [ApiController]
  [GenericRestControllerNameConvention]
  [Route ("api/[controller]")]
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

    [HttpPost]
    public T create (T model) {
      return _baseService.Create (model);
    }

    [HttpPut]
    public T update (T model) {
      return _baseService.Update (model);
    }

    [HttpDelete]
    public int delete (T model) {
      return _baseService.Delete (model);
    }

    [HttpDelete]
    [Route ("id")]
    public int deleteById (IdType id) {
      return _baseService.DeleteById (id);
    }
  }
}