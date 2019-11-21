using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;
        public static List<Movie> All
        {
            get
            {
                if (movies == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                return movies;
            }
        }
        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public static List<Movie> Search(List<Movie> l, string search)
        {
            List<Movie> results = new List<Movie>();
            foreach(Movie m in l)
            {
                if (m.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || m.Director!=null && m.Director.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(m);
                }
            }
            return results;
        }

       public static List<Movie> FilterByMPAA(List<Movie> m, List<string> mpaa)
        {
            List<Movie> r = new List<Movie>();
            foreach(Movie l in m)
            {
                if (mpaa.Contains(l.MPAA_Rating))
                    r.Add(l);
            }
            return r;
        }
        public static List<Movie> FilterByMPAAAndSearch(List<string> mpaa, string search)
        {
            List<Movie> r = new List<Movie>();
            foreach (Movie m in movies)
            {
                if ((m.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || m.Director != null && m.Director.Contains(search, StringComparison.OrdinalIgnoreCase))&& mpaa.Contains(m.MPAA_Rating))
                {
                    r.Add(m);
                }
            }
            return r;
        }

        public static List<Movie> FilterByMinIMDB(List<Movie> m, float min)
        {
            List<Movie> r = new List<Movie>();

            foreach(Movie l in m)
            {
                if (l.IMDB_Rating != null && l.IMDB_Rating >= min)
                    r.Add(l);
                
            }
            return r;
        }
        
    }
}
