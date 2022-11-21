import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlbumDetailsComponent } from './public/album/album-details.component';
import { ArtistDetailsComponent } from './public/artist/artist-details.component';
import { GenreDetailsComponent } from './public/genre/genre-details.component';
import { GenreComponent } from './public/genre/genre.component';

const routes: Routes = [
  {path: "", component: GenreComponent},
  {path: "genres/:genreId", component: GenreDetailsComponent},
  {path: "artists/:artistId", component: ArtistDetailsComponent},
  {path: "albums/:albumId", component: AlbumDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
