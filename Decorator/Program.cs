namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoreItem orderItemBoughtInStore = new OrderItem(2.00f);
            VATTax vatTax = new VATTax(orderItemBoughtInStore);
            CashPaymentTax cashPaymentTax = new CashPaymentTax(vatTax);
            Console.WriteLine($"Order item bought in store with cash: {cashPaymentTax.getPrice()}");

            StoreItem orderItemOrderedWithDiscount = new OrderItem(2.00f);
            vatTax = new VATTax(orderItemOrderedWithDiscount);
            Discount discount = new Discount(vatTax, 0.15f);
            ShippingTax shippingTax = new ShippingTax(discount);
            Console.WriteLine($"Order item ordered online with discount: {shippingTax.getPrice()}");

            Console.ReadKey();
        }

        public abstract class StoreItem
        {
            protected float price;
            public abstract float getPrice();
        }
        public class OrderItem : StoreItem
        {

            public OrderItem(float price)
            {
                this.price = price;
            }

            public override float getPrice()
            {
                return price;
            }
        }

        public class PriceDecorator : StoreItem
        {
            protected readonly StoreItem component;

            public PriceDecorator(StoreItem component)
            {
                this.component = component;
            }

            public override float getPrice()
            {
                return component.getPrice();
            }
        }
        public class ShippingTax : PriceDecorator
        {
            private float tax = 1.23f;
            public ShippingTax(StoreItem component) : base(component)
            {
            }

            public override float getPrice()
            {
                return base.getPrice() + tax;
            }
        }
        public class Discount : PriceDecorator
        {
            private float discount;
            public Discount(StoreItem component, float discount) : base(component)
            {
                this.discount = discount;
            }
            public override float getPrice()
            {
                return base.getPrice() - base.getPrice() * discount;
            }
        }
        public class CashPaymentTax : PriceDecorator
        {
            private float tax = 0.69f;
            public CashPaymentTax(StoreItem component) : base(component)
            {
            }
            public override float getPrice()
            {
                return base.getPrice() + tax;
            }
        }
        public class VATTax : PriceDecorator
        {
            private float tax = 0.21f;
            public VATTax(StoreItem component) : base(component)
            {
            }
            public override float getPrice()
            {
                return base.getPrice() + base.getPrice() * tax;
            }
        }
    }
}