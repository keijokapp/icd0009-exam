export enum EState {
  Waiting,
  Paid,
  Process,
  Done
}

export interface IOrderUser {
  userId: number,
  username: string
}

interface IOrderListAddition {
  productId: number,
  productName: string,
  quantity: number,
  price: number
}

export interface IOrderLine {
  productId: number,
  productName: string | undefined,
  quantity: number,
  price: number | undefined,
  orderListAdditions: IOrderListAddition[]
}

export interface IOrder {
  id: number | undefined ;
  user: IOrderUser | undefined
  state: EState | undefined,
  deliveryLocation: string,
  price: number | undefined,
  orderLines: IOrderLine[],
}
