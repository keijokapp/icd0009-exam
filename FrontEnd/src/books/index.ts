import { LogManager, View, autoinject, bindable } from "aurelia-framework";
import { RouteConfig, NavigationInstruction } from "aurelia-router";
import { OrderService } from "../services/order-service";
import { IBook } from "interfaces/IBook";

export var log = LogManager.getLogger('ContactTypes.Index');

// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Index {

  private books: IBook[] = [];

  @bindable private search: string = '';

  constructor(
    private booksService: OrderService
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

  searchClicked() {
    log.debug('searchClicked', this.search);
    this.loadData();
  }

  searchResetClicked() {
    log.debug('searchResetClicked');
    this.search = '';
    this.loadData();
  }

  loadData(){

    this.booksService.fetchAll('?search=' + this.search).then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.books = jsonData;
      }
    );
  }
}
