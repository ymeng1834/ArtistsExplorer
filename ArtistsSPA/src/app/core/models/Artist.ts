export interface ArtistsPaged {
    data:            Artist[];
    totalRowCount:   number;
    pageSize:        number;
    totalPages:      number;
    pageIndex:       number;
    hasPreviousPage: boolean;
    hasNextPage:     boolean;
}

export interface Artist {
    spotifyId: string;
    name:      string;
    imageUrl?:  string;
}

