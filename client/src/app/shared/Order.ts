export class OrderItem {
    id?: number;
    quantity?: number;
    unitPrice?: number;
    productId?: number;
    productCategory?: string;
    productSize?: string;
    productTitle?: string;
    productPlatform?: string;
    productGameId?: string;

    get priceitem(): number {
        if (this.unitPrice != null && this.quantity != null) {
            return this.unitPrice * this.quantity;
        } else {
            return 0;
        }
    }
    

    
}

export class Order {
    orderId?: number;
    orderDate: Date = new Date();
    orderNumber?: string = Math.random().toString(36).substr(2,5);
    items: OrderItem[] = [];

    

    get subtotal(): number {

        const result = this.items.reduce(
            (tot, val) => {
                if (val.unitPrice != null && val.quantity != null) {
                    return tot + (val.unitPrice * val.quantity);
                } else {
                    return 0;
                }
            }, 0);

        return result;
    }
}
