import { LogManager, View, autoinject, bindable } from "aurelia-framework";
import { RouteConfig, NavigationInstruction } from "aurelia-router";
import { OrderService } from "../services/order-service";
import {IOrder, IOrderLine} from "interfaces/IOrder";
import {IProduct} from "../interfaces/IProduct";
import {ProductService} from "../services/product-service";

export var log = LogManager.getLogger('ContactTypes.Index');



// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Index {

  private products: IProduct[] = [];
  private additions: IProduct[] = [];

	@bindable private toppingSelection: string[] = [];

  private order = {
    deliveryLocation: '',
    price: 0,
    orderLines: []
  }

  @bindable private search: string = '';

  constructor(
    private productService: ProductService,
  private orderService: OrderService
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
    this.productService.fetchAll('').then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.products = jsonData.filter(p => p.categoryType !== 2);
        this.additions = jsonData.filter(p => p.categoryType === 2);
      }
    );
  }

  addProduct(product) {
		const existing = this.order.orderLines.find(l => l.product === product && !l.additions.length);
		if(existing) {
			existing.quantity++;
		} else {
			this.order.orderLines.push({
				product,
				quantity: 1,
				additions: []
			});
		}
  }

	increaseOrderLine(orderLine) {
		orderLine.quantity++
	}

	decreaseOrderLine(orderLine) {
		orderLine.quantity--;
		if(!orderLine.quantity) {
			const existing = this.order.orderLines.indexOf(orderLine);
			if(existing >= 0) {
				this.order.orderLines.splice(existing, 1);
			}
		}
	}

	addAddition(i, product) {
		this.order.orderLines[i].additions.push({
			product: this.additions[i],
			quantity: 1
		});
console.log(this.order.orderLines[i].additions);
	}


	increaseAddition(addition) {
		addition.quantity++;
	}

	decreaseAddition(orderLine, addition) {
		addition.quantity--;
		if(!addition.quantity) {
			const existing = orderLine.additions.indexOf(addition);
			if(existing >= 0) {
				orderLine.additions.splice(existing, 1);
			}
		}
	}


	post() {
    this.orderService.post({
      deliveryLocation: <string> this.order.deliveryLocation,
      orderLines: <IOrderLine[]> this.order.orderLines.map(l => ({
        productId: l.productId,
        quantity: l.quantity
      })),
      price: undefined,
      state: undefined,
      id: undefined,
      user: undefined
    }).then(r => {
      if(r.ok) {
        this.order = {
          deliveryLocation: '',
          price: 0,
          orderLines: []
        }
      }
    })
	}
}
