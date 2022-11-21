import { Genre } from "./Genre";

export interface GenreDetails {
    id:        number;
    name:      string;
    subgenres: Genre[];
}
