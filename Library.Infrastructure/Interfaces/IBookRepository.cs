﻿using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetByISBN(string ISBN);
    }
}
