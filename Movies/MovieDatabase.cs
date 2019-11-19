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
    public class MovieDatabase
    {
        private List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public MovieDatabase() {
            
            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }
        public List<Movie> Search(string search)
        {
            List<Movie> results = new List<Movie>();
            foreach(Movie m in movies)
            {
                if (m.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || m.Director!=null && m.Director.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(m);
                }
            }
            return results;
        }

       public List<Movie> FilterByMPAA(List<string> mpaa)
        {
            List<Movie> r = new List<Movie>();
            foreach(Movie m in movies)
            {
                if (mpaa.Contains(m.MPAA_Rating))
                    r.Add(m);
            }
            return r;
        }
        public List<Movie> FilterByMPAAAndSearch(List<string> mpaa, string search)
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

        public List<Movie> FilterIMDB(float min, List<Movie> m)
        {
            List<Movie> r = new List<Movie>();

            foreach(Movie l in m)
            {
                if (l.IMDB_Rating != null && l.IMDB_Rating >= min)
                    r.Add(l);
                
            }
            return r;
        }
        public List<Movie> All { get { return movies; } }
    }
}
