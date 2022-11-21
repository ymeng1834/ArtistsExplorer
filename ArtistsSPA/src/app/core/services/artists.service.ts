import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AlbumsPaged } from '../models/Album';
import { ArtistDetails } from '../models/ArtistDetails';

@Injectable({
  providedIn: 'root'
})
export class ArtistsService {

  constructor(private http:HttpClient) { }

  getArtistDetails(id?:string): Observable<ArtistDetails> {
    return this.http.get<ArtistDetails>(`${environment.baseUrl}/Artists/`+id);
  }

  getAlbumsOfArtist(id?:string, page:number=1): Observable<AlbumsPaged> {
    return this.http.get<AlbumsPaged>(`${environment.baseUrl}/Artists/`+id+`/albums?page=`+page);
  }

  getSinglesOfArtist(id?:string, page:number=1): Observable<AlbumsPaged> {
    return this.http.get<AlbumsPaged>(`${environment.baseUrl}/Artists/`+id+`/singles?page=`+page);
  }
}
