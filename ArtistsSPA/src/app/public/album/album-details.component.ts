import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeHtml, SafeResourceUrl} from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { AlbumDetails } from 'src/app/core/models/AlbumDetails';
import { AlbumService } from 'src/app/core/services/album.service';

@Component({
  selector: 'app-album-details',
  templateUrl: './album-details.component.html',
  styleUrls: ['./album-details.component.css']
})
export class AlbumDetailsComponent implements OnInit {

  id?:string;
  album?:AlbumDetails;
  sanitizedUrl?:SafeResourceUrl;

  constructor(private route:ActivatedRoute, private albumService:AlbumService, private sanitizer:DomSanitizer) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => { 
      this.id = p['albumId'];
      this.sanitizedUrl = this.sanitizer.bypassSecurityTrustResourceUrl("https://open.spotify.com/embed/album/"+this.id+"?utm_source=oembed&theme=0");
    });
    this.albumService.getAlbumDetails(this.id).subscribe(a => { this.album = a });
  }

}
