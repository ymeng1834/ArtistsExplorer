import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtistsPaged } from 'src/app/core/models/Artist';
import { GenreDetails } from 'src/app/core/models/GenreDetails';
import { GenresService } from 'src/app/core/services/genres.service';

@Component({
  selector: 'app-genre-details',
  templateUrl: './genre-details.component.html',
  styleUrls: ['./genre-details.component.css']
})
export class GenreDetailsComponent implements OnInit {

  genreId?:number;
  subgenreId?:number;
  subgenre:boolean=false;
  genre?:GenreDetails;
  artists?:ArtistsPaged;
  
  constructor(private route:ActivatedRoute, private genreService:GenresService) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => {
      this.genreId = p['genreId'];
      if (p['subgenreId']) {
        this.subgenreId = p['subgenreId'];
        this.subgenre = true;
      }
      this.getArtists()
    });
    this.genreService.getGenreDetails(this.genreId).subscribe(g => { this.genre = g; });
  }

  getArtists(): void {
    if (this.subgenre) {
      this.genreService.getArtistsOfSubgenre(this.subgenreId).subscribe(a => {this.artists = a});
    }
    else {
      this.genreService.getArtistsOfGenre(this.genreId).subscribe(a => { this.artists = a; });
    }
  }

  prevPage(currPage:number=1): void {
    if (this.subgenre) {
      this.genreService.getArtistsOfSubgenre(this.subgenreId, currPage-1).subscribe(a => {this.artists = a});
    }
    else {
      this.genreService.getArtistsOfGenre(this.genreId, currPage-1).subscribe(a => {this.artists = a});
    }
  }

  nextPage(currPage:number=1): void {
    if (this.subgenre) {
      this.genreService.getArtistsOfSubgenre(this.subgenreId, currPage+1).subscribe(a => {this.artists = a});
    }
    else {
      this.genreService.getArtistsOfGenre(this.genreId, currPage+1).subscribe(a => {this.artists = a});
    }
  }
}
