using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ayaty.Shared.Bll.Interfaces;
using Ayaty.Shared.Dto.Paging;

namespace Ayaty.Shared.Bll.Business
{
    public class PagingManagement : IPaging
    {
        #region Feilds



        #endregion Feilds

        #region Ctor

        public PagingManagement()
        {
        }

        #endregion Ctor

        #region Public Methods

        public async Task<PageList<TEntity>> CreateAsync<TEntity,TSource>(IQueryable<TSource> source, PagingDto dto, Func<TSource,TEntity> mapping)
        {
            var count = await source.CountAsync();
            List<TSource> items;

            if (dto.PageSize == 0 || dto.PageNumber == 0)
            {
                items = await source.ToListAsync();
                return new PageList<TEntity>(items.Select(mapping),count);
            }
             items = await source.Skip((dto.PageNumber - 1) * dto.PageSize).Take(dto.PageSize).ToListAsync();
            return new PageList<TEntity>(items.Select(mapping),count,dto);
        }

        #endregion Public Methods

        #region private Methods



        #endregion private Methods



    }
}