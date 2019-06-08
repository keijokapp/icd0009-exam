import { LogManager, View, autoinject, bindable } from "aurelia-framework";
import { RouteConfig, NavigationInstruction } from "aurelia-router";
import { OrderService } from "../services/order-service";
import { IOrder } from "interfaces/IOrder";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('ContactTypes.Index');

// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Index {

  private orders: IOrder[] = [];

  constructor(
    private orderService: OrderService,
    private appConfig: AppConfig
  ) {
    log.debug('constructor');
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');

    this.loadData();

  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }

  loadData(){
    this.orderService.fetchAll('').then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.orders = jsonData;
      }
    );
  }

  updateState(order) {
    console.log(order);
    fetch(this.appConfig.apiUrl + 'Order/' + order.id + '/state?state=' + order.state, {
      method: 'PUT',
        headers: {
          Authorization: 'Bearer ' + this.appConfig.jwt,
        }
    })
  }
}
