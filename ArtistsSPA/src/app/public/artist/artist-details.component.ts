import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlbumsPaged } from 'src/app/core/models/Album';
import { ArtistDetails } from 'src/app/core/models/ArtistDetails';
import { ArtistsService } from 'src/app/core/services/artists.service';

@Component({
  selector: 'app-artist-details',
  templateUrl: './artist-details.component.html',
  styleUrls: ['./artist-details.component.css']
})
export class ArtistDetailsComponent implements OnInit {

  id?:string;
  artist?:ArtistDetails;
  albums?:AlbumsPaged;
  singles?:AlbumsPaged;

  constructor(private route:ActivatedRoute, private artistService:ArtistsService) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => { this.id = p['artistId'] });
    this.artistService.getArtistDetails(this.id).subscribe(a => { this.artist = a });
    this.artistService.getAlbumsOfArtist(this.id).subscribe(a => { this.albums = a });
    this.artistService.getSinglesOfArtist(this.id).subscribe(s => { this.singles = s });
  }

  navigate(currPage:number=1, album:boolean, next:boolean): void {
    let pageNum = next ? currPage+1 : currPage-1;
    if (album) {
      this.artistService.getAlbumsOfArtist(this.id, pageNum).subscribe(a => { this.albums = a });
    }
    else {
      this.artistService.getSinglesOfArtist(this.id, pageNum).subscribe(s => { this.singles = s });
    }
  }

}
