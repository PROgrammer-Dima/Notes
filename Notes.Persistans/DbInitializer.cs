﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Persistans
{
    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
