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

export interface IOrderLineAddition {
  productId: number,
  productName: string | undefined,
  quantity: number,
  price: number | undefined
}

export interface IOrderLine {
  productId: number,
  productName: string | undefined,
  quantity: number,
  price: number | undefined,
  orderLineAdditions: IOrderLineAddition[]
}

export interface IOrder {
  id: number | undefined ;
  user: IOrderUser | undefined
  state: EState | undefined,
  deliveryLocation: string,
  price: number | undefined,
  orderLines: IOrderLine[],
}
