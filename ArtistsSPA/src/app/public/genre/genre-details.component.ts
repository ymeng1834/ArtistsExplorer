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

  id?:number;
  genre?:GenreDetails;
  artists?:ArtistsPaged;
  subgenre?:boolean;
  title?:string;
  hasPrev?:string;
  hasNext?:string;
  
  constructor(private route:ActivatedRoute, private genreService:GenresService) { }

  ngOnInit(): void {
    this.subgenre = false;
    this.route.params.subscribe(p => { this.id = p['genreId'] });
    this.genreService.getGenreDetails(this.id).subscribe(g => {this.genre = g});
    this.title = "Popular artists";
    this.genreService.getArtistsOfGenre(this.id).subscribe(a => {this.artists = a});

    this.hasPrev = this.artists?.hasPreviousPage ? "" : "disabled";
    this.hasNext = this.artists?.hasNextPage ? "" : "disabled";
  }

  updateArtists(subgenreId:number, subgenreName:string): void {
    this.subgenre = true;
    this.id = subgenreId;
    this.title = "Popular artists in " + subgenreName;
    this.genreService.getArtistsOfSubgenre(this.id).subscribe(a => {this.artists = a});
  }

  prevPage(currPage:number=1): void {
    if (this.subgenre) {
      this.genreService.getArtistsOfSubgenre(this.id, currPage-1).subscribe(a => {this.artists = a});
    }
    else {
      this.genreService.getArtistsOfGenre(this.id, currPage-1).subscribe(a => {this.artists = a});
    }
  }

  nextPage(currPage:number=1): void {
    if (this.subgenre) {
      this.genreService.getArtistsOfSubgenre(this.id, currPage+1).subscribe(a => {this.artists = a});
    }
    else {
      this.genreService.getArtistsOfGenre(this.id, currPage+1).subscribe(a => {this.artists = a});
    }
  }

}
