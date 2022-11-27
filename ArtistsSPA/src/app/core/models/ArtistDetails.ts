import { Subgenre } from "./Subgenre";

export interface ArtistDetails {
    spotifyId: string;
    name:      string;
    imageUrl:  string;
    followers: number;
    genres:    Subgenre[];
}
