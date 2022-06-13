using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopOnContainers.Core.Models;
using eShopOnContainers.Core.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamFirebase.Models;
using XamFirebase.ViewModels;

namespace eShopOnContainers.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrunEkle : ContentPage
    {
        UrunViewModel vmProduct;
        public UrunEkle()
        {
            InitializeComponent();
            vmProduct = new UrunViewModel();
            this.BindingContext = vmProduct;
        }

        private async void lstProducts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (lstProducts.SelectedItem != null)
                {
                    Urun product = (Urun)e.SelectedItem;
                    if (product != null)
                    {
                        var display = await DisplayActionSheet(product.productName, "Cancel",
                        null, new string[] { "Edit", "Delete" });
                        if (display.Equals("Edit"))
                        {
                            vmProduct.setProduct(product);
                        }
                        else if (display.Equals("Delete"))
                        {
                            vmProduct.setProduct(product);
                            await vmProduct.trnProducts("DELETE");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            lstProducts.SelectedItem = null;
        }
    }
}