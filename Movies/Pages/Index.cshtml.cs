using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {

        public MovieDatabase movieDatabase = new MovieDatabase();
        public List<Movie> movies;

        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();

        [BindProperty]
        public float minIMDB { get; set;  }
        public void OnGet()
        {
            movies = movieDatabase.All;
        }
        public void OnPost()
        {
            if (search != null && mpaa.Count > 0)
            {
                movies = movieDatabase.FilterByMPAAAndSearch(mpaa, search);
            }
            else if (search != null)
                movies = movieDatabase.Search(search);
            else if (mpaa.Count > 0)
                movies = movieDatabase.FilterByMPAA(mpaa);
            if (minIMDB is float min)
                movies = movieDatabase.FilterIMDB(min, movies);
            else
                movies = movieDatabase.All;
        }
    }
}
