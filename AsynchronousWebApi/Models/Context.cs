﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AsynchronousWebApi.Models
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}