// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var movieEntries = document.getElementsByClassName("movie-entry");
var form = document.getElementById("search-and-filter-by-form");

form.addEventListener('submit', function (event) {
    event.preventDefault();
    var term = document.getElementById("search").value;
    var mpaa=[];
    var mpaaCheck = document.getElementsByClassName("mpaa");
    var minImdb = document.getElementById("minIMDB").value;
    for (var j = 0; j < mpaaCheck.length; j++) {
        if (mpaaCheck[j].checked) {
            mpaa.push(mpaaCheck[j].value);
        }
    }
    var i, entry;
        for (i = 0; i < movieEntries.length; i++) {
            entry = movieEntries[i];
            entry.style.display = "block";
            if (term) {
                if (!entry.dataset.title.toLowerCase().includes(term.toLowerCase())) {
                    entry.style.display = "none";
                }
            }

            if (mpaa.length > 0) {
                if (!mpaa.includes(entry.dataset.mpaa)) {
                    entry.style.display = "none";
                }
            }

            if (minImdb) {
                if (!entry.dataset.imdb || parseFloat(minImdb) > parseFloat(entry.dataset.imdb)) {
                    entry.style.display = "none";
                }
            }
        }

    
});