import { Injectable } from '@angular/core';
import{ HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Genre } from '../models/Genre';
import { ArtistsPaged } from '../models/Artist';
import { GenreDetails } from '../models/GenreDetails';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenresService {

  constructor(private http:HttpClient) { }

  getAllGenres():Observable<Genre[]> {
    return this.http.get<Genre[]>(`${environment.baseUrl}/Genres`);
  }

  getGenreDetails(id?:number):Observable<GenreDetails> {
    return this.http.get<GenreDetails>(`${environment.baseUrl}/Genres/`+id);
  }

  getArtistsOfGenre(id?:number, page:number=1):Observable<ArtistsPaged> {
    return this.http.get<ArtistsPaged>(`${environment.baseUrl}/Genres/`+id+`/artists?page=`+page);
  }

  getArtistsOfSubgenre(id?:number, page:number=1):Observable<ArtistsPaged> {
    return this.http.get<ArtistsPaged>(`${environment.baseUrl}/Genres/subgenres/`+id+`/artists?page=`+page);
  }

}
