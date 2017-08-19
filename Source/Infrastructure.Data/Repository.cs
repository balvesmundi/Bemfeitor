using MundiPagg.Benfeitor.Domain.Seedwork;
using MundiPagg.Benfeitor.Domain.Seedwork.Specifications;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Seedwork {

    /// <summary>
    /// Repository base class
    /// </summary>
    /// <typeparam name="TEntity">The type of underlying entity in this repository</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {

        #region Members

        IQueryableUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IQueryableUnitOfWork unitOfWork) {

            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");

            _unitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository Members

        /// <summary>
        /// 
        /// </summary>
        public IUnitOfWork UnitOfWork {
            get {
                return _unitOfWork;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(TEntity item) {

            if (item == null) throw new ArgumentNullException();

            Set().Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove(TEntity item) {

            if (item == null) throw new ArgumentNullException();

            _unitOfWork.Attach(item);

            Set().Remove(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Modify(TEntity item) {

            if (item == null) throw new ArgumentNullException();

            _unitOfWork.SetModified(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Attach(TEntity item) {

            if (item == null) throw new ArgumentNullException();

            _unitOfWork.Attach(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Detach(TEntity item) {

            if (item == null) throw new ArgumentNullException();

            _unitOfWork.Detach(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persisted"></param>
        /// <param name="current"></param>
        public virtual void Merge(TEntity persisted, TEntity current) {
            _unitOfWork.ApplyCurrentValues(persisted, current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] include) {

            IQueryable<TEntity> set = Set();

            foreach (var item in include) set = set.Include(item);

            return set.FirstOrDefault(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="include"></param>
        /// <returns></returns> 
        public virtual TEntity FindOne(ISpecification<TEntity> specification, params Expression<Func<TEntity, object>>[] include) {
            return FindOne(specification.SatisfiedBy(), include);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] include) {

            IQueryable<TEntity> set = Set();

            foreach (var item in include) set = set.Include(item);

            return set.Where(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> FindAll(ISpecification<TEntity> specification, params Expression<Func<TEntity, object>>[] include) {
            return FindAll(specification.SatisfiedBy(), include);
        }

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
        public IQueryable<TEntity> FindAll<KProperty>(int startIndex, int length, Expression<Func<TEntity, KProperty>> orderBy, bool ascending, params Expression<Func<TEntity, object>>[] include) {

            IQueryable<TEntity> set = Set();

            foreach (var item in include) set = set.Include(item);

            if (ascending) {
                set = set.OrderBy(orderBy);
            } else {
                set = set.OrderByDescending(orderBy);
            }

            return set.Skip(startIndex).Take(length);
        }

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
        public virtual IQueryable<TEntity> FindAll<KProperty>(Expression<Func<TEntity, bool>> filter, int startIndex, int length, Expression<Func<TEntity, KProperty>> orderBy, bool ascending, params Expression<Func<TEntity, object>>[] include) {

            IQueryable<TEntity> set = Set();

            foreach (var item in include) set = set.Include(item);

            var items = set.Where(filter);

            if (ascending) {
                items = items.OrderBy(orderBy);
            } else {
                items = items.OrderByDescending(orderBy);
            }

            return items.Skip(startIndex).Take(length);
        }

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
        public virtual IQueryable<TEntity> FindAll<KProperty>(ISpecification<TEntity> specification, int startIndex, int length, Expression<Func<TEntity, KProperty>> orderBy, bool ascending, params Expression<Func<TEntity, object>>[] include) {
            return FindAll(specification.SatisfiedBy(), startIndex, length, orderBy, ascending, include);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int Count() {
            return Set().Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        public virtual int Count(ISpecification<TEntity> specification) {
            return Count(specification.SatisfiedBy());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<TEntity, bool>> filter) {
            return Set().Count(filter);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose() {
            if (_unitOfWork != null) _unitOfWork.Dispose();
        }

        #endregion

        #region Private Methods

        private IDbSet<TEntity> Set() {
            return _unitOfWork.CreateSet<TEntity>();
        }

        #endregion
    }
}
