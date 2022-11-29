import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { LoginRequest, LoginResults } from "../shared/LoginResults";
import { Order, OrderItem } from "../shared/Order";
import { Product } from "../shared/Product";

@Injectable()
export class Store {

    constructor(private http: HttpClient) {

    }
    public products: Product[] = [] = [] as any[];
    public order: Order = new Order();
    public token: string | undefined = "";
    public expiration: Date | undefined= new Date();

    loadProducts(): Observable<void> {
        return this.http.get<[]>("/api/products")
            .pipe(map(data => {
                this.products = data;
                return;
            }));
    }

    get loginRequired(): boolean {
        if (this.token != null && this.expiration != null) {
            return this.token.length === 0 || this.expiration > new Date();
        } else {
            return false;
        }
       
    }

    login(creds: LoginRequest) {
        return this.http.post<LoginResults>("/account/createtoken", creds)
            .pipe(map(data => {
                this.token = data.token;
                this.expiration = data.expiration;
            }));
    }

    checkout() {
        const headers = new HttpHeaders().set("Authorization", `Bearer ${this.token}`);

        return this.http.post("/api/orders", this.order, {
            headers: headers
        })
            .pipe(map(() => {
                this.order = new Order();
            }));
    }

    addToOrder(product: Product) {

        let item: OrderItem | undefined;

        item = this.order.items.find(o => o.productId == product.id);

        if (item) {
            if (item.quantity != null)
                item.quantity++;
        } else {
            const item = new OrderItem();
            item.productId = product.id;
            item.productTitle = product.title;
            item.productGameId = product.gameId;
            item.productCategory = product.category;
            item.productPlatform = product.platform;
            item.productSize = product.size;
            item.unitPrice = product.price;
            item.quantity = 1; //for now

            this.order.items.push(item);
        }


    }
}