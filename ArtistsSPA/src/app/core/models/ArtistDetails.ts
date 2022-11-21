import { Genre } from "./Genre";

export interface ArtistDetails {
    spotifyId: string;
    name:      string;
    imageUrl:  string;
    followers: number;
    genres:    Genre[];
}
