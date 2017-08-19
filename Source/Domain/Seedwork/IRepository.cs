using MundiPagg.Benfeitor.Domain.Seedwork.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Benfeitor.Domain.Seedwork {

    public interface IRepository<TEntity> : IDisposable where TEntity : class {

        /// <summary>
        /// 
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Add(TEntity item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Remove(TEntity item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Modify(TEntity item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Attach(TEntity item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Detach(TEntity item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persisted"></param>
        /// <param name="current"></param>
        void Merge(TEntity persisted, TEntity current);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        TEntity FindOne(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] include);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        TEntity FindOne(ISpecification<TEntity> specification, params Expression<Func<TEntity, object>>[] include);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] include);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindAll(ISpecification<TEntity> specification, params Expression<Func<TEntity, object>>[] include);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="KProperty"></typeparam>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <param name="orderBy"></param>
        /// <param name="ascending"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindAll<KProperty>(int startIndex, int length, Expression<Func<TEntity, KProperty>> orderBy, bool ascending, params Expression<Func<TEntity, object>>[] include);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="KProperty"></typeparam>
        /// <param name="filter"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <param name="orderBy"></param>
        /// <param name="ascending"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindAll<KProperty>(Expression<Func<TEntity, bool>> filter, int startIndex, int length, Expression<Func<TEntity, KProperty>> orderBy, bool ascending, params Expression<Func<TEntity, object>>[] include);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="KProperty"></typeparam>
        /// <param name="specification"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <param name="orderBy"></param>
        /// <param name="ascending"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindAll<KProperty>(ISpecification<TEntity> specification, int startIndex, int length, Expression<Func<TEntity, KProperty>> orderBy, bool ascending, params Expression<Func<TEntity, object>>[] include);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        int Count(ISpecification<TEntity> specification);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> filter);

    }
}
