using System;
using System.Collections.Generic;

namespace Ayaty.Shared.Dto.Paging
{
    public class PageList<TEntity> : List<TEntity>
    {
        #region Ctor

        public PageList(List<TEntity> item, int count)
        {
            TotalCount = count;
            PageSize = count;
            CurrentPage = 1;
            TotalPages = 1;
            this.AddRange(item);
        }
        public PageList(IEnumerable<TEntity> item, int count)
        {
            TotalCount = count;
            PageSize = count;
            CurrentPage = 1;
            TotalPages = 1;
            this.AddRange(item);
        }
        public PageList(List<TEntity> item, int count, PagingDto dto)
        {
            TotalCount = count;
            PageSize = dto.PageSize;
            CurrentPage = dto.PageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)dto.PageSize);
            this.AddRange(item);
        }

        public PageList(IEnumerable<TEntity> item, int count, PagingDto dto)
        {
            TotalCount = count;
            PageSize = dto.PageSize;
            CurrentPage = dto.PageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)dto.PageSize);
            this.AddRange(item);
        }

        #endregion Ctor


        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }


    }
}