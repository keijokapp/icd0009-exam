import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";
import {IOrder} from "../interfaces/IOrder";
import {IProduct} from "../interfaces/IProduct";

export var log = LogManager.getLogger('ProductService');

@autoinject
export class ProductService extends BaseService<IProduct> {
  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Product');
  }
}
