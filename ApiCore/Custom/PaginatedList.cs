﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Custom
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage{
            get{
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage{
            get{
                return (PageIndex < TotalPages);
            }
        }

        public int? NextPageNumber => HasNextPage ? PageIndex + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? PageIndex - 1 : (int?)null;

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalCount = count; //Total de Registros
            PageIndex = pageIndex; //Pagina actual en la que estamos
            PageSize = pageSize; //Total de registros por Pagina
            TotalPages = (int)Math.Ceiling(count / (double)pageSize); //Total de paginas

            this.AddRange(items);
        }

        //public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        //{
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        //    return new PaginatedList<T>(items, count, pageIndex, pageSize);
        //}

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
