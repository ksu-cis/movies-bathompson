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
        public List<Movie> movies = new List<Movie>();

        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();

        [BindProperty]
        public float minIMDB { get; set;  }


        public void OnGet()
        {
            movies = MovieDatabase.All;
        }


        public void OnPost()
        {
            movies = MovieDatabase.All;
            if (search!=null)
            {
                movies = MovieDatabase.Search(movies, search);
            }
            if(mpaa.Count>0)
            {
                movies = MovieDatabase.FilterByMPAA(movies, mpaa);
            }
            if(minIMDB is float min)
            {
                movies = MovieDatabase.FilterByMinIMDB(movies, min);
            }
        }
    }
}
