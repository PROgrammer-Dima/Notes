﻿using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Application.Interfaces;
using Notes.Persistans.EntityTypeConfiguration;
using System.Data.Common;


namespace Notes.Persistans
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
