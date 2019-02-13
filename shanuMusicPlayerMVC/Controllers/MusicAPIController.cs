using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shanuMusicPlayerMVC.Controllers
{
    public class MusicAPIController : ApiController
    {

        // To select Album Details
        [HttpGet]
        public IEnumerable<AlbumMastera> getAlbums(string AlbumName)
        {
            List<AlbumMastera> albums;
            using (var db = new MusicDataContext())
            {
                if (AlbumName == null)
                {
                    albums = db.Albums.ToList();
                }
                else
                {
                    albums = db.Albums.Where(album => album.AlbumName == AlbumName).ToList();
                }
            }

            return albums;
        }

        // To insertKIDSLEARN
        [HttpGet]
        public IEnumerable<string> insertAlbum(string AlbumName, string ImageName)
        {
            if (AlbumName == null || ImageName == null)
            {
                return new List<string>();
            }
            using (var db = new MusicDataContext())
            {
                db.Albums.Add(new AlbumMastera{AlbumName = AlbumName, ImageName = ImageName});
                db.SaveChanges();
            }
            return new List<string>();
        }



        // to Search all Music Album Details
        [HttpGet]
        public IEnumerable<MusicPlayerMastera> getMusicSelectALL(string AlbumName)
        {
            List<MusicPlayerMastera> songs;
            
            using (var db = new MusicDataContext())
            {
                if (AlbumName == null)
                {
                    songs = db.Songs.ToList();
                }
                else
                {
                    songs = db.Songs.Where(song => song.AlbumName == AlbumName).ToList();
                }
            }

            return songs;
        }

        // To insert Music Details
        [HttpGet]
        public IEnumerable<string> insertMusic(string SingerName, string AlbumName, string MusicFileName, string Description)
        {
            if (SingerName == null)
                SingerName = "";

            if (MusicFileName == null)
                MusicFileName = "";

            if (AlbumName == null)
                AlbumName = "";

            if (Description == null)
                Description = "";
            using (var db = new MusicDataContext())
            {
                db.Songs.Add(new MusicPlayerMastera
                {
                    Description = Description, AlbumName = AlbumName, MusicFileName = MusicFileName,
                    SingerName = SingerName
                });
                db.SaveChanges();
            }
            return new List<string>();
        }

        // To Update Music Details
        [HttpGet]
        public IEnumerable<string> updateMusic(string MusicPlayerMasteraID, string SingerName, string AlbumName, string MusicFileName, string Description)
        {
            var EmptyList = new List<string>();
            if (MusicPlayerMasteraID == null)
                return EmptyList;

            if (SingerName == null)
                return EmptyList;

            if (MusicFileName == null)
                return EmptyList;

            if (AlbumName == null)
                return EmptyList;

            if (Description == null)
                return EmptyList;
            using (var db = new MusicDataContext())
            {
                var song = db.Songs.FirstOrDefault(s => s.MusicPlayerMasteraID.ToString() == MusicPlayerMasteraID);
                if (song != null)
                {
                    song.AlbumName = AlbumName;
                    song.Description = Description;
                    song.MusicFileName = MusicFileName;
                    song.SingerName = SingerName;
                }
                db.SaveChanges();
            }
            return EmptyList;
        }



        // To Delete Music Details
        [HttpGet]
        public IEnumerable<string> deleteMusic(string MusicPlayerMasteraID)
        {
            if (MusicPlayerMasteraID == null)
                MusicPlayerMasteraID = "0";

            using (var db = new MusicDataContext())
            {
                var song = db.Songs.FirstOrDefault(s=>s.MusicPlayerMasteraID.ToString() == MusicPlayerMasteraID);
                if (song!=null)
                {
                    db.Songs.Remove(song);
                    db.SaveChanges();
                }
            }
            return new List<string>();
        }
    }
}
