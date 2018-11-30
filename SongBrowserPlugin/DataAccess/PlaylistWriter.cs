﻿using SimpleJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongBrowserPlugin.DataAccess
{
    class PlaylistWriter
    {
        private static Logger _log = new Logger("PlaylistWriter");

        public static bool WritePlaylist(Playlist p, String fileName)
        {
            _log.Debug("WritePlaylist - {0}", fileName);

            JSONNode root = new JSONObject();
            root.Add("playlistTitle", p.Title);
            root.Add("playlistAuthor", p.Author);
            root.Add("image", p.Image);

            JSONArray songs = new JSONArray();
            root.Add("songs", songs);
            foreach (PlaylistSong ps in p.Songs)
            {
                var jsonSong = new JSONObject();
                jsonSong.Add("key", ps.Key);
                jsonSong.Add("songName", ps.SongName);
                jsonSong.Add("levelId", ps.LevelId);

                songs.Add(jsonSong);
            }

            File.WriteAllText(fileName, root.ToString(4));        
            return true;
        }
    }
}