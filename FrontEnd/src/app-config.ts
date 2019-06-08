import {LogManager, autoinject} from "aurelia-framework";

export var log = LogManager.getLogger('AppConfig');

@autoinject
export class AppConfig {
  
  public apiUrl = 'http://localhost:5000/api/';
  public jwt: string | null = null;

  constructor() {
    log.debug('constructor');
  }

}
