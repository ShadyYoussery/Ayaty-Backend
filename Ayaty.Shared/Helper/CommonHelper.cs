using System;
using System.Linq;
using System.Linq.Expressions;
using Ayaty.Context.Interfaces;
using Z.EntityFramework.Plus;

namespace Ayaty.Shared.Helper
{
    public static class CommonHelper
    {

        public static int LangaugeId => 1;
        public static IQueryable<TEntity> WhereByLanguage<TEntity>(this IQueryable<TEntity> entity) where TEntity : ILanguageId
        {
            return entity.Where(t => t.LanguageId == LangaugeId);
        }

        /// <summary>
        /// create FutureValue by DeferredAny method in EF+
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="entities"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static QueryFutureValue<bool> AnyDeferred<TSource>(this IQueryable<TSource> entities, Expression<Func<TSource, bool>> predicate)
        {
            return entities.DeferredAny(predicate).FutureValue();
        }

    }
}