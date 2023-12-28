using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public abstract class BaseRepository<T, IdType> : IBaseRepository<T, IdType> where T : class, IEntity<IdType>
{
    protected readonly LibraryOfficeDbContext currentDbcontext;

    protected BaseRepository(LibraryOfficeDbContext dbContext)
    {
        currentDbcontext = dbContext;
    }

    public ICollection<T> find(Expression<Func<T, bool>> filter = null, params string[] includes)
    {
        IQueryable<T> queryable = currentDbcontext.Set<T>();
        if (includes.Any()) includes.ToList().ForEach(i => { queryable = queryable.Include(i); });

        if (filter != null) queryable = queryable.Where(filter);

        return queryable.ToList();
    }

    public T findById(IdType Id)
    {
        return currentDbcontext.Set<T>().FirstOrDefault(e => e.Id.Equals(Id));
    }

    public T Create(T entity)
    {
        currentDbcontext.Set<T>().Add(entity);
        currentDbcontext.SaveChanges();
        return entity;
    }

    public virtual T Update(T entity)
    {
        currentDbcontext.Set<T>().Update(entity);
        currentDbcontext.SaveChanges();
        return entity;
    }

    public void UpdateStatusById(IdType id, bool status)
    {
        var entity = findById(id);
        entity.IsActive = status;
        currentDbcontext.Set<T>().Update(entity);
        currentDbcontext.SaveChanges();
    }

    public void Delete(T entity)
    {
        currentDbcontext.Set<T>().Remove(entity);
        currentDbcontext.SaveChanges();
    }

    public void DeleteById(IdType Id)
    {
        currentDbcontext.Set<T>().Remove(findById(Id));
        currentDbcontext.SaveChanges();
    }

    public void SoftDelete(IdType Id)
    {
        var item = findById(Id);
        item.IsDeleted = true;
        currentDbcontext.Set<T>().Update(item);
        currentDbcontext.SaveChanges();
    }

    public bool Exist(IdType Id)
    {
        return currentDbcontext.Set<T>().Any(e => e.Id.Equals(Id) && !e.IsDeleted);
    }

    public bool Exist(Expression<Func<T, bool>> predicate)
    {
        return currentDbcontext.Set<T>().Where(entity => !entity.IsDeleted).Any(predicate);
    }

    public int GetTotalRecordCount()
    {
        return currentDbcontext.Set<T>().Count(entity => !entity.IsDeleted);
    }
}