import { Component, OnInit } from '@angular/core';
import { Genre } from 'src/app/core/models/Genre';
import { GenresService } from 'src/app/core/services/genres.service';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css']
})
export class GenreComponent implements OnInit {

  genres?:Genre[];
  constructor(private genreService:GenresService) { }

  ngOnInit(): void {
    this.genreService.getAllGenres().subscribe(g => {
      this.genres = this.addIcon(g);
    })
  }

  addIcon(genres:Genre[]): Genre[] {
    for(var i=0; i<genres.length; ++i) {
      switch(genres[i].id) {
        case 1:
          genres[i].icon = `π§βπ€`;
          break;
        case 2:
          genres[i].icon = `π₯`;
          break;
        case 3:
          genres[i].icon = `π`;
          break;
        case 4:
          genres[i].icon = `π€`;
          break;
        case 5:
          genres[i].icon = `πͺ`;
          break;
        case 6:
          genres[i].icon = `π€`;
          break;
        case 7:
          genres[i].icon = `πΈ`;
          break;
        case 8:
          genres[i].icon = `π€ `;
          break;
        case 9:
          genres[i].icon = `πͺ`;
          break;
        case 10:
          genres[i].icon = `π»`;
          break;
        case 11:
          genres[i].icon = `π·`;
          break;
        case 12:
          genres[i].icon = `ποΈ`;
          break;
        case 13:
          genres[i].icon = `βοΈ`;
          break;
        case 14:
          genres[i].icon = `π§`;
          break;
        case 15:
          genres[i].icon = `πΊοΈ`;
          break;
      }
    }
    return genres;
  }
}
