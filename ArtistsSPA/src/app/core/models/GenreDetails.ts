import { Subgenre } from "./Subgenre";

export interface GenreDetails {
    id: number;
    name: string;
    icon: string;
    overview: string;
    externalUrl: string;
    subgenres: Subgenre[];
}
