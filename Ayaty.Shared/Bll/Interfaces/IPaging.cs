using System;
using System.Linq;
using System.Threading.Tasks;
using Ayaty.Shared.Dto.Paging;

namespace Ayaty.Shared.Bll.Interfaces
{
    public interface IPaging
    {
        Task<PageList<TEntity>> CreateAsync<TEntity, TSource>(IQueryable<TSource> source, PagingDto dto,
            Func<TSource, TEntity> mapping);
    }
}