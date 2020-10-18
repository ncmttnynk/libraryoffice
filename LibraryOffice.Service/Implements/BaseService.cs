using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public abstract class BaseService<T, IdType> : IBaseService<T, IdType> {
  protected readonly IBaseRepository<T, IdType> repository;

  protected BaseService (IBaseRepository<T, IdType> repository) {
    this.repository = repository;
  }

  public ICollection<T> find (
    Expression<Func<T, bool>> filter = null,
    params string[] includes) {
    return repository.find (filter, includes);
  }

  public T findById (IdType Id) {
    return repository.findById (Id);
  }

  public virtual T Create (T entity) {
    return repository.Create (entity);
  }

  public virtual T Update (T entity) {
    return repository.Update (entity);
  }

  public void UpdateStatusById (IdType id, bool status) {
    repository.UpdateStatusById (id, status);
  }

  public void Delete (T entity) {
    repository.Delete (entity);
  }

  public void DeleteById (IdType Id) {
    repository.DeleteById (Id);
  }

  public void SoftDelete (IdType Id) {
    repository.SoftDelete (Id);
  }

  public bool Exist (IdType Id) {
    return repository.Exist (Id);
  }

  public bool Exist (Expression<Func<T, bool>> expression) {
    return repository.Exist (expression);
  }

  public int GetTotalRecordCount () {
    return repository.GetTotalRecordCount ();
  }
}