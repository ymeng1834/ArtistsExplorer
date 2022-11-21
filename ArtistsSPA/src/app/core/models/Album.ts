export interface AlbumsPaged {
    data:            Album[];
    totalRowCount:   number;
    pageSize:        number;
    totalPages:      number;
    pageIndex:       number;
    hasPreviousPage: boolean;
    hasNextPage:     boolean;
}

export interface Album {
    spotifyId:   string;
    name:        string;
    coverUrl:    string;
    releaseDate: string;
}
