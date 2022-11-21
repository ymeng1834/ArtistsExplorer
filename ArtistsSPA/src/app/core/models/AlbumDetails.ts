import { Artist } from "./Artist";

export interface AlbumDetails {
    spotifyId:   string;
    name:        string;
    coverUrl:    string;
    artists:     Artist[];
    releaseDate: string;
    type:        string;
    numOfTracks: number;
    popoularity: number;
}
