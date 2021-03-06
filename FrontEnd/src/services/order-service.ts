import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IOrder} from "../interfaces/IOrder";

export var log = LogManager.getLogger('OrderService');

@autoinject
export class OrderService extends BaseService<IOrder> {
  

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Order');
  }

}
