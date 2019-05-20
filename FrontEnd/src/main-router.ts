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

        {route: ['books','books/index'], name: 'books' + 'Index', moduleId: PLATFORM.moduleName('books/index'), nav: true, title: 'Books'},
        {route: 'books/details/:id', name: 'books' + 'Details', moduleId: PLATFORM.moduleName('books/details'), nav: false, title: 'Book Details'},


        /*

        //{route: '', name: '', moduleId: PLATFORM.moduleName(''), nav: true, title: ''},
        {route: ['persons','persons/index'], name: 'persons' + 'Index', moduleId: PLATFORM.moduleName('persons/index'), nav: true, title: 'Persons'},
        {route: 'persons/create', name: 'persons' + 'Create', moduleId: PLATFORM.moduleName('persons/create'), nav: false, title: 'Persons Create'},
        {route: 'persons/edit/:id', name: 'persons' + 'Edit', moduleId: PLATFORM.moduleName('persons/edit'), nav: false, title: 'Persons Edit'},
        {route: 'persons/delete/:id', name: 'persons' + 'Delete', moduleId: PLATFORM.moduleName('persons/delete'), nav: false, title: 'Persons Delete'},
        {route: 'persons/details/:id', name: 'persons' + 'Details', moduleId: PLATFORM.moduleName('persons/details'), nav: false, title: 'Persons Details'},

        {route: ['contacts','contacts/index'], name: 'contacts' + 'Index', moduleId: PLATFORM.moduleName('contacts/index'), nav: true, title: 'Contacts'},
        {route: 'contacts/create', name: 'contacts' + 'Create', moduleId: PLATFORM.moduleName('contacts/create'), nav: false, title: 'Contacts Create'},
        {route: 'contacts/edit/:id', name: 'contacts' + 'Edit', moduleId: PLATFORM.moduleName('contacts/edit'), nav: false, title: 'Contacts Edit'},
        {route: 'contacts/delete/:id', name: 'contacts' + 'Delete', moduleId: PLATFORM.moduleName('contacts/delete'), nav: false, title: 'Contacts Delete'},
        {route: 'contacts/details/:id', name: 'contacts' + 'Details', moduleId: PLATFORM.moduleName('contacts/details'), nav: false, title: 'Contacts Details'},

        {route: ['contacttypes','contacttypes/index'], name: 'contacttypes' + 'Index', moduleId: PLATFORM.moduleName('contacttypes/index'), nav: true, title: 'ContactTypes'},
        {route: 'contacttypes/create', name: 'contacttypes' + 'Create', moduleId: PLATFORM.moduleName('contacttypes/create'), nav: false, title: 'ContactTypes Create'},
        {route: 'contacttypes/edit/:id', name: 'contacttypes' + 'Edit', moduleId: PLATFORM.moduleName('contacttypes/edit'), nav: false, title: 'ContactTypes Edit'},
        {route: 'contacttypes/delete/:id', name: 'contacttypes' + 'Delete', moduleId: PLATFORM.moduleName('contacttypes/delete'), nav: false, title: 'ContactTypes Delete'},
        {route: 'contacttypes/details/:id', name: 'contacttypes' + 'Details', moduleId: PLATFORM.moduleName('contacttypes/details'), nav: false, title: 'ContactTypes Details'},
        */
      ]  
    );
    
  } 
  
}
