import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CoreModule } from './core/core.module';
import { GenreComponent } from './public/genre/genre.component';
import { GenreDetailsComponent } from './public/genre/genre-details.component';
import { HttpClientModule} from '@angular/common/http';
import { ArtistDetailsComponent } from './public/artist/artist-details.component';
import { AlbumDetailsComponent } from './public/album/album-details.component';

@NgModule({
  declarations: [
    AppComponent,
    GenreComponent,
    GenreDetailsComponent,
    ArtistDetailsComponent,
    AlbumDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    CoreModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
