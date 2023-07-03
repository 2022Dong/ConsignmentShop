using ConsignmentShopLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        private Store store = new Store();
        private List<Item> shoppingCartData = new List<Item>();
        // connect ...create bingding source
        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorsBinding = new BindingSource();
        private decimal storeProfit = 0;


        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData(); // create dummy data

            // Link..
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList(); // filter list
            lbItems.DataSource = itemsBinding;

            // what do you want to show..
            lbItems.DisplayMember = "Display";
            lbItems.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            lbShoppingCart.DataSource = cartBinding;

            lbShoppingCart.DisplayMember = "Display";
            lbShoppingCart.ValueMember = "Display";

            vendorsBinding.DataSource = store.Vendors;
            lbVendors.DataSource = vendorsBinding;

            lbVendors.DisplayMember = "Display";
            lbVendors.ValueMember = "Display";
        }

        private void SetupData()
        {
            //Vendor demoVendor = new Vendor();

            //demoVendor.FirstName = "Bill";
            //demoVendor.LastName = "Smith";
            //demoVendor.Commission = .5;

            //store.Vendors.Add(demoVendor);

            //demoVendor = new Vendor();  // no need 'Vendor' in the front

            //demoVendor.FirstName = "Sue";
            //demoVendor.LastName = "Jones";
            //demoVendor.Commission = .5;

            //store.Vendors.Add(demoVendor);

            store.Vendors.Add(new Vendor { FirstName = "Bill", LastName = "Smith" });
            store.Vendors.Add(new Vendor { FirstName = "Sue", LastName = "Jones" });

            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.5M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "A Tale of Two Cities",
                Description = "A book about a revolution",
                Price = 3.80M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter Book 1",
                Description = "A book about a boy",
                Price = 5.2M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Jane Eyre",
                Description = "A book about a girl",
                Price = 1.5M,
                Owner = store.Vendors[0]
            });

            store.Name = "Seconds are Better";
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("i have been clicked"); // Testing btn

            // Figure out what is selected from the items list
            // Copy that item to the shopping cart
            // Do we remove the item from the items list? - no
            Item selectedItem = (Item)lbItems.SelectedItem;

            //MessageBox.Show(selectedItem.Title);

            shoppingCartData.Add(selectedItem); // Breakpoint to check

            cartBinding.ResetBindings(false); // if the type of the list has been changed -> true.
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            // Mark each item in the cart as sold
            // Clear the cart

            foreach (Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commission * item.Price;
                storeProfit += (1 - (decimal)item.Owner.Commission) * item.Price;
            }
            shoppingCartData.Clear();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList(); // filter list

            lblValue.Text = string.Format("${0}", storeProfit); // update lbl

            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorsBinding.ResetBindings(false);
        }
    }
}
