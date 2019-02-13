//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace shanuMusicPlayerMVC
{
    using System;
    using System.Collections.Generic;
    public class MusicDataContext : DbContext
    {
        public DbSet<AlbumMastera> Albums { get; set; }
        public DbSet<MusicPlayerMastera> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=musicData.db");
        }
    }

    public partial class AlbumMastera
    {
        public int AlbumMasteraID { get; set; }
        public string AlbumName { get; set; }
        public string ImageName { get; set; }
    }

    public partial class MusicPlayerMastera
    {
        public int MusicPlayerMasteraID { get; set; }
        public string SingerName { get; set; }
        public string AlbumName { get; set; }
        public string MusicFileName { get; set; }
        public string Description { get; set; }
    }
}