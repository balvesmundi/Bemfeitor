using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Seedwork {

    /// <summary>
    /// Extensions methods for EntityTypeConfiguration
    /// </summary>
    public static class EntityTypeConfigurationExtensions {
        
        /// <summary>
        /// Extension method for map private binary properties
        /// <example>
        /// modelBuilder.Entity{Customer}()
        ///             .Property{Customer}("Image")
        /// </example>
        /// </summary>
        /// <typeparam name="TEntityType">The type of entity to map</typeparam>
        /// <param name="entityConfiguration">Asociated EntityTypeConfiguration</param>
        /// <param name="propertyName">The name of private binary property</param>
        /// <returns>A StringPropertyConfiguration for this map</returns>
        public static StringPropertyConfiguration Property<TEntityType>(this EntityTypeConfiguration<TEntityType> entityConfiguration, string propertyName)
           where TEntityType : class {

            var propertyInfo = typeof(TEntityType).GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            if (propertyInfo != null) {

                var arg = Expression.Parameter(typeof(TEntityType), "parameterName");
                var memberExpression = Expression.Property((Expression)arg, propertyInfo);

                //Create the expression to map
                var expression = (Expression<Func<TEntityType, string>>)Expression.Lambda(memberExpression, arg);

                return entityConfiguration.Property(expression);
            } else
                throw new InvalidOperationException("The property not exist");
        }
    }
}
