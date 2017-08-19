using System;
using System.Linq.Expressions;

namespace MundiPagg.Benfeitor.Domain.Seedwork.Specifications {

    /// <summary>
    /// http://en.wikipedia.org/wiki/Specification_pattern
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public interface ISpecification<TEntity> where TEntity : class {
        
        /// <summary>
        /// Check if this specification is satisfied by a 
        /// specific expression lambda
        /// </summary>
        /// <returns></returns>
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
