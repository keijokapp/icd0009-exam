import {PLATFORM, LogManager, autoinject} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import { AppConfig } from "app-config";

export var log = LogManager.getLogger('MainRouter');

@autoinject
export class MainRouter {
  
  public router: Router;
  
  constructor(private appConfig: AppConfig){
    log.debug('constructor');
  }
  
  configureRouter(config: RouterConfiguration, router: Router):void {
    log.debug('configureRouter');
    
    this.router = router;
    config.title = "Exam Demo App - Aurelia";
    config.map(
      [
        {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'},

        {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
        {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
        {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},

        {route: ['products','products/index'], name: 'products' + 'Index', moduleId: PLATFORM.moduleName('products/index'), nav: true, title: 'Products'},

        {route: ['orders','orders/index'], name: 'orders' + 'Index', moduleId: PLATFORM.moduleName('orders/index'), nav: true, title: 'Orders'},
        {route: 'orders/details/:id', name: 'books' + 'Details', moduleId: PLATFORM.moduleName('orders/details'), nav: false, title: 'Order Details'},
      ]
    );
    
  } 
  
}
