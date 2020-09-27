import SaleTypes from "./models/SaleType";

export function getSaleTypeMessage(saleType: SaleTypes) {
    switch (saleType) {
        case 0:
            return "---";
        case 1:
            return "Compre 1 leve 2";
        case 2:
            return "Compre 3 por 1";
    }
}
