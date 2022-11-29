export class Product {
    id: number;
    category: string;
    size: string;
    price: number;
    title: string;
    gameDescription: string;
    gameId: string;
    platform: string;
    gameReleaseDate: Date;

    constructor(id: number, category: string, size: string, price: number, title: string, gd: string,
        gid: string, p: string, grd: Date) {
        this.id = id;
        this.category = category;
        this.size = size;
        this.price = price;
        this.title = title;
        this.gameDescription = gd;
        this.gameId = gid;
        this.platform = p;
        this.gameReleaseDate = grd;
        
    }
}