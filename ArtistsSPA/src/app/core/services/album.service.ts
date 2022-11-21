import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AlbumDetails } from '../models/AlbumDetails';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  constructor(private http:HttpClient) { }

  getAlbumDetails(id?:string): Observable<AlbumDetails> {
    return this.http.get<AlbumDetails>(`${environment.baseUrl}/Albums/`+id);
  }
}
