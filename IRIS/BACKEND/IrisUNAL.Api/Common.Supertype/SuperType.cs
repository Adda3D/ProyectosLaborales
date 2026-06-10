using IrisUNAL.Api.Data;
using IrisUNAL.Api.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace IrisUNAL.Api.Common.Supertype
{
    public enum CrudActions
    {
        None = 0,
        Insert,
        UpdateStatus,
        Update,
        Delete,
    }

    public class SuperType<TEntity> : IDisposable where TEntity : class
    {
        protected DbContext context = null;
        DbSet<TEntity> objectSet = null;
        public bool SetAduditFields { get; set; }


        public DbSet<TEntity> ObjectSet
        {
            get { return objectSet; }
        }

        public DbContext Context
        {
            get
            {
                return context;
            }
            set
            {
                CreateContext(value);
            }
        }

        protected virtual void CreateContext(DbContext context, bool setAduditFields = true)
        {
            this.SetAduditFields = setAduditFields;
            this.context = context;
            objectSet = context.Set<TEntity>();
        }

        public SuperType()
        {
            Context = new ApplicationDbContext();
        }

        public SuperType(DbContext context, bool setAduditFields = true)
        {
            CreateContext(context);
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (this.SetAduditFields)
                SetAuditingValues(entity, CrudActions.Insert);
            objectSet.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (this.SetAduditFields)            
                SetAuditingValues(entity, CrudActions.Update);

            context.Entry<TEntity>(entity).State = EntityState.Modified;

            SetNotModifiedField(entity, "fechacreacion");
            SetNotModifiedField(entity, "usuariocreacion");

            context.SaveChanges();
            return entity;
        }

        public virtual TEntity AddUpdate(TEntity entity, string pkName, bool withFind = false)
        {
            var propPk = typeof(TEntity).GetProperty(pkName);
            if (withFind)
            {
                TEntity entityTemp = this.Get(Convert.ToInt64(propPk.GetValue(entity)));
                if (entityTemp == default(TEntity))
                    Add(entity);
                else
                {
                    context.Entry<TEntity>(entityTemp).State = EntityState.Detached;
                    //Update(entityTemp);
                    Update(entity);
                }
            }
            else
            {
                if (Convert.ToInt64(propPk.GetValue(entity)) == 0)
                    Add(entity);
                else
                    Update(entity);
            }
            return entity;

        }

        public virtual void Delete(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual void Delete(Int64 id)
        {
            var entity = Get(id);
            Delete(entity);
        }

        public virtual TEntity Get(long id)
        {
            return objectSet.Find(id);
        }

        public virtual void Delete(string id)
        {
            var entity = Get(id);
            Delete(entity);
        }

        public virtual TEntity Get(string id)
        {
            return objectSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IEnumerable<TEntity> list = new List<TEntity>();
            var query = from item in context.Set<TEntity>()
                        select item;

            return query;
        }

        public virtual IEnumerable<TEntity> Get(params Expression<Func<TEntity, object>>[] naProperties)
        {
            IEnumerable<TEntity> list = new List<TEntity>();
            var query = from item in context.Set<TEntity>()
                        select item;

            foreach (Expression<Func<TEntity, object>> nProperty in naProperties)
                query = query.Include<TEntity, object>(nProperty);

            return query;
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] naProperties)
        {
            IQueryable<TEntity> query = null;

            if (predicate == null)
                return this.Get();
            else
            {
                query = from item in context.Set<TEntity>().Where<TEntity>(predicate)
                        select item;
            }
            
            foreach (Expression<Func<TEntity, object>> nProperty in naProperties)
                query = query.Include<TEntity, object>(nProperty);
            
            return query;
        }
        
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return this.Get();
            else
            {
                var query = from item in context.Set<TEntity>().Where<TEntity>(predicate)
                            select item;

                return query;
            }

        }
        

        public virtual int Count()
        {
            var registros = (from item in context.Set<TEntity>()
                       select item).Count();

            return registros;
        }

        public virtual int CountFiltered(Expression<Func<TEntity, bool>> predicate = null)
        {
            var registros = 0;
            if (predicate == null)
            {
                registros = (from item in context.Set<TEntity>()
                             select item).Count();
            }
            else
            {
                registros = (from item in context.Set<TEntity>().Where(predicate)
                             select item).Count();
            }

            return registros;
        }

        public virtual IEnumerable<TEntity> Get(int skip, int take, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, int>> orderBy = null, bool isDesc = true)
        {
            IQueryable<TEntity> query = null;
            if (predicate == null)
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }
            else
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }

            return query;
        }

        public virtual IEnumerable<TEntity> Get(int skip, int take, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, Int64>> orderBy = null, bool isDesc = true)
        {
            IQueryable<TEntity> query = null;
            if (predicate == null)
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }
            else
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }

            return query;
        }

        public virtual IEnumerable<TEntity> Get(int skip, int take, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, string>> orderBy = null, bool isDesc = true)
        {
            IQueryable<TEntity> query = null;
            if (predicate == null)
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }
            else
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }

            return query;
        }

        public virtual IEnumerable<TEntity> Get(int skip, int take, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, DateTime>> orderBy = null, bool isDesc = true)
        {
            IQueryable<TEntity> query = null;
            if (predicate == null)
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }
            else
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }

            return query;
        }

        //public virtual IEnumerable<TEntity> GetExpressions(int skip, int take, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<Models.Investigacion.Investigacion_Resolucion, object>> orderByFunc = null, Expression<Func<TEntity, string>> orderBy = null, bool isDesc = true, params Expression<Func<TEntity, object>>[] naProperties)
        //{
        //    IQueryable<TEntity> query = null;
        //    if (predicate == null)
        //    {
        //        if (orderBy == null)
        //        {
        //            query = from item in context.Set<TEntity>().Skip(skip).Take(take)
        //                    select item;                    
        //        }
        //        else
        //        {
        //            if (isDesc)
        //                query = from item in context.Set<TEntity>().OrderByDescending(orderBy).Skip(skip).Take(take)
        //                        select item;
        //            else
        //            {
        //                query = from item in context.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take)
        //                        select item;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (orderBy == null)
        //            query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
        //                    select item;
        //        else
        //        {
        //            if (isDesc)
        //                query = from item in context.Set<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
        //                        select item;
        //            else
        //                query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
        //                        select item;
        //        }
        //    }

        //    foreach (Expression<Func<TEntity, object>> nProperty in naProperties)
        //        query = query.Include<TEntity, object>(nProperty);


        //    return query;
        //}


        // Método solo para ordenamiento con string
        public virtual IEnumerable<TEntity> GetExpressions(
            int skip,
            int take,
            Expression<Func<TEntity, bool>> predicate = null,
            Expression<Func<TEntity, string>> orderBy = null,
            bool isDesc = true,
            params Expression<Func<TEntity, object>>[] naProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = isDesc ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }

            query = query.Skip(skip).Take(take);

            foreach (var includeProperty in naProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        // Método para casos generales con object
        public virtual IEnumerable<TEntity> GetExpressionsWithObjectOrder(
            int skip,
            int take,
            Expression<Func<TEntity, bool>> predicate = null,
            Expression<Func<TEntity, object>> orderByFunc = null,
            bool isDesc = true,
            params Expression<Func<TEntity, object>>[] naProperties)
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderByFunc != null)
            {
                query = isDesc ? query.OrderByDescending(orderByFunc) : query.OrderBy(orderByFunc);
            }

            query = query.Skip(skip).Take(take);

            foreach (var includeProperty in naProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }



        public virtual IEnumerable<TEntity> GetExpressions(int skip, int take, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, DateTime>> orderBy = null, bool isDesc = true, params Expression<Func<TEntity, object>>[] naProperties)
        {
            IQueryable<TEntity> query = null;
            if (predicate == null)
            {
                if (orderBy == null)
                {
                    query = from item in context.Set<TEntity>().Skip(skip).Take(take)
                            select item;
                }
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                    {
                        query = from item in context.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                    }
                }
            }
            else
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }

            foreach (Expression<Func<TEntity, object>> nProperty in naProperties)
                query = query.Include<TEntity, object>(nProperty);


            return query;
        }

        public virtual IEnumerable<TEntity> GetExpressions(int skip, int take, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, int>> orderBy = null, bool isDesc = true, params Expression<Func<TEntity, object>>[] naProperties)
        {
            IQueryable<TEntity> query = null;
            if (predicate == null)
            {
                if (orderBy == null)
                {
                    query = from item in context.Set<TEntity>().Skip(skip).Take(take)
                            select item;
                }
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                    {
                        query = from item in context.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                    }
                }
            }
            else
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }

            foreach (Expression<Func<TEntity, object>> nProperty in naProperties)
                query = query.Include<TEntity, object>(nProperty);


            return query;
        }

        public virtual IEnumerable<TEntity> Get(int skip, int take, string predicate = null, Expression<Func<TEntity, string>> orderBy = null, bool isDesc = true)
        {
            IQueryable<TEntity> query = null;
            if (string.IsNullOrEmpty(predicate))
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }
            else
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
                            select item;
                else
                {
                    if (isDesc)
                        query = from item in context.Set<TEntity>().Where(predicate).OrderByDescending(orderBy).Skip(skip).Take(take)
                                select item;
                    else
                        query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                                select item;
                }
            }

            return query;
        }

        public virtual IEnumerable<TEntity> Get(int skip, int take, string predicate = null, string orderBy = null)
        {
            IQueryable<TEntity> query = null;
            if (string.IsNullOrEmpty(predicate))
            {
                if (string.IsNullOrEmpty(orderBy))
                    query = from item in context.Set<TEntity>().Skip(skip).Take(take)
                            select item;
                else
                {
                    query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                            select item;
                }
            }
            else
            {
                if (orderBy == null)
                    query = from item in context.Set<TEntity>().Where(predicate).Skip(skip).Take(take)
                            select item;
                else
                    query = from item in context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip).Take(take)
                            select item;                
            }

            return query;
        }

        public void Dispose()
        {
            Dispose(true);            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (this.context != null)
                {
                    this.context.Dispose();
                    this.context = null;
                }


                if (this.objectSet != null)
                {
                    this.objectSet = null;
                }

                //if (this.Entidad != null)
                //{
                //    GC.SuppressFinalize(this.Entidad);
                //    this.Entidad = null;
                //}


            }
        }

        public virtual TEntity SetValue(TEntity entity, string propertyName, object valueToSet)
        {
            Type type = typeof(TEntity);
            if (type.Name.ToLower() == "object")
                type = entity.GetType();
            PropertyInfo currentProperty = type.GetProperty(propertyName.ToLower());
            if (currentProperty != null)
            {
                Type ptype = Nullable.GetUnderlyingType(currentProperty.PropertyType) ?? currentProperty.PropertyType;
                if (valueToSet != null)
                    currentProperty.SetValue(entity, Convert.ChangeType(valueToSet, ptype), null);
            }
            return entity;
        }

        public virtual TEntity SetAuditingValues(TEntity entity, CrudActions crudAction)
        {
            Type type = null;
            if (typeof(TEntity).Name != "Object")
                type = typeof(TEntity);
            else
                type = entity.GetType();

            switch (crudAction)
            {
                case CrudActions.Insert:
                    SetValue(entity, "FechaCreacion", DateTime.Now);
                    SetValue(entity, "UsuarioCreacion", GlobalParams.usuariocontroller);

                    //        SetValue(entity, "MaquinaCreacion", currentContextInfo.UserMachine);
                    break;
                case CrudActions.Update:
                    SetValue(entity, "FechaActualizacion", DateTime.Now);
                    SetValue(entity, "UsuarioActualizacion", GlobalParams.usuariocontroller);
                    //        SetValue(entity, "MaquinaActualizacion", currentContextInfo.UserMachine);
                    break;
            }
            return entity;
        }

        public virtual TEntity SetNotModifiedField(TEntity entity, string propertyname)
        {
            //No actualizar fechacreacion - usuariocreacion
            var type = entity.GetType();
            PropertyInfo currentProperty = type.GetProperty(propertyname.ToLower());

            if (currentProperty != null)
            {
                context.Entry<TEntity>(entity).Property(propertyname.ToLower()).IsModified = false;
            }

            return entity;
        }

        public virtual Expression<Func<T, string>> CreateExpressionOrderBy<T>(string propertyName)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type);
            var access = Expression.Property(parameter, property);
            var convert = Expression.Convert(access, typeof(string));
            var function = Expression.Lambda<Func<T, string>>(convert, parameter);

            return function;
        }

        public virtual Expression<Func<T, DateTime>> CreateExpressionOrderByDate<T>(string propertyName)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type);
            var access = Expression.Property(parameter, property);
            var convert = Expression.Convert(access, typeof(DateTime));
            var function = Expression.Lambda<Func<T, DateTime>>(convert, parameter);

            return function;
        }

        public virtual Expression<Func<T, int>> CreateExpressionOrderByInt<T>(string propertyName)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type);
            var access = Expression.Property(parameter, property);
            var convert = Expression.Convert(access, typeof(int));
            var function = Expression.Lambda<Func<T, int>>(convert, parameter);

            return function;
        }

    }
}