import { LogManager, View, autoinject, bindable } from "aurelia-framework";
import { RouteConfig, NavigationInstruction } from "aurelia-router";
import { OrderService } from "../services/order-service";
import {IOrderLine, IOrderLineAddition} from "interfaces/IOrder";
import {IProduct} from "../interfaces/IProduct";
import {ProductService} from "../services/product-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('ContactTypes.Index');



// automatically inject dependencies declared as private constructor parameters
// will be accessible as this.<variablename> in class
@autoinject
export class Index {

  public products: IProduct[] = [];
  public additions: IProduct[] = [];

	@bindable private toppingSelection: string[] = [];

  @bindable private order = {
    deliveryLocation: '',
    price: 0,
    orderLines: []
  }

  constructor(
    private productService: ProductService,
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
    this.recalculate();
  }

	increaseOrderLine(orderLine) {
		orderLine.quantity++;
    this.recalculate();
	}

	decreaseOrderLine(orderLine) {
		orderLine.quantity--;
		if(!orderLine.quantity) {
			const existing = this.order.orderLines.indexOf(orderLine);
			if(existing >= 0) {
				this.order.orderLines.splice(existing, 1);
			}
		}
    this.recalculate();
	}

	addAddition(i) {
		this.order.orderLines[i].additions.push({
			product: this.additions[this.toppingSelection[i]],
			quantity: 1
		});
    this.recalculate();
	}


	increaseAddition(addition) {
		addition.quantity++;
		this.recalculate();
	}

	decreaseAddition(orderLine, addition) {
		addition.quantity--;
		if(!addition.quantity) {
			const existing = orderLine.additions.indexOf(addition);
			if(existing >= 0) {
				orderLine.additions.splice(existing, 1);
			}
		}
    this.recalculate();
	}

  recalculate() {
    let price = 0;

    for(const line of this.order.orderLines) {
      price += line.product.price * line.quantity;
      for (const addition of line.additions) {
        price += addition.product.price * addition.quantity;
      }
    }

    this.order.price = price;
  }

	post() {
    console.log(this.order);
    this.orderService.post({
      deliveryLocation: this.order.deliveryLocation,
      orderLines: this.order.orderLines.map(l => (<IOrderLine> {
        productId: l.product.id,
        quantity: l.quantity,
        price: undefined,
        productName: undefined,
        orderLineAdditions: l.additions.map(a => <IOrderLineAddition>({
          productId: a.product.id,
          quantity: a.quantity
        }))
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
