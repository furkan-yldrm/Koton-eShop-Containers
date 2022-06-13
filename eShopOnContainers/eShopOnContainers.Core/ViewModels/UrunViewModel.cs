using eShopOnContainers.Core.Models;
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamFirebase.Models;

namespace XamFirebase.ViewModels
{
    public class UrunViewModel : INotifyPropertyChanged
    {
        FirebaseClient fClient;

        private Urun _product { get; set; }

        public Urun product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }

        private bool _showButton { get; set; }
        public bool showButton
        {
            get { return _showButton; }
            set
            {
                _showButton = value;
                OnPropertyChanged();
            }
        }
        private bool _isBusy { get; set; }
        public bool isBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                showButton = !value;
            }
        }

        private ICommand _btnSaveProduct { get; set; }
        public ICommand btnSaveProduct
        {
            get { return _btnSaveProduct; }
            set
            {
                _btnSaveProduct = value;
                OnPropertyChanged();
            }
        }

        private string _lblMessage { get; set; }
        public string lblMessage
        {
            get { return _lblMessage; }
            set
            {
                _lblMessage = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Urun> _lstProducts { get; set; }

        public ObservableCollection<Urun> lstProducts
        {
            get { return _lstProducts; }
            set
            {
                _lstProducts = value;
                OnPropertyChanged();
            }
        }

        private string _btnSaveText { get; set; }
        public string btnSaveText
        {
            get { return _btnSaveText; }
            set
            {
                _btnSaveText = value;
                OnPropertyChanged();
            }
        }

        readonly string productResource = "Products";
        public UrunViewModel()
        {
            try
            {
                lstProducts = new ObservableCollection<Urun>();
                btnSaveProduct = new Command(async () =>
                {
                    isBusy = true;
                    await trnProducts("ADD");
                });
                var callList = new Command(async () => await GetAllProducts());
                callList.Execute(null);

            }
            catch (Exception ex)
            {
                lblMessage = "Error occurred " + ex.Message.ToString();
            }
        }

        public bool connectFirebase()
        {
            try
            {
                if (fClient == null)
                    fClient = new FirebaseClient("https://realtimedb-eshop-default-rtdb.firebaseio.com/");
                return true;
            }
            catch (Exception ex)
            {
                lblMessage = "Hata oluştu. Error:" + ex.Message.ToString();
                return false;
            }

        }

        public async Task trnProducts(string action)
        {
            try
            {
                if (product == null || String.IsNullOrWhiteSpace(product.productName) || product.productPrice == null)
                {
                    lblMessage = "Please enter product details to save product";
                    isBusy = false;
                    return;
                }

                if (connectFirebase())
                {
                    Urun products = new Urun();
                    products.productName = product.productName;
                    products.productPrice = product.productPrice;
                    if (btnSaveText == "SAVE" && action.Equals("ADD"))
                    {
                        products.productId = Guid.NewGuid();

                        await fClient.Child(productResource).PostAsync(JsonConvert.SerializeObject(products));
                        await GetAllProducts();
                        lblMessage = "Product saved successfully";
                    }
                    else if (btnSaveText == "UPDATE" && action.Equals("ADD"))
                    {
                        products.productId = product.productId;

                        var updateProduct = (await fClient.Child(productResource).OnceAsync<Urun>()).FirstOrDefault(x => x.Object.productId == products.productId);

                        if (updateProduct == null)
                        {
                            lblMessage = "Cannot find selected Product";
                            isBusy = false;
                            return;
                        }
                        await fClient
                        .Child(productResource + "/" + updateProduct.Key).PatchAsync(JsonConvert.SerializeObject(products));
                        await GetAllProducts();
                        lblMessage = "Product updated successfully";
                    }
                    else if (action.Equals("DELETE"))
                    {
                        var deleteProduct = (await fClient
                        .Child(productResource)
                        .OnceAsync<Urun>()).FirstOrDefault(d => d.Object.productId == product.productId);

                        if (deleteProduct == null)
                        {
                            lblMessage = "Cannot find selected Product";
                            isBusy = false;
                            return;
                        }

                        await fClient
                        .Child(productResource + "/" + deleteProduct.Key).DeleteAsync();

                        await GetAllProducts();
                        lblMessage = "Product delete successfully";
                    }

                }
            }
            catch (Exception ex)
            {
                lblMessage = "Error occurred. Cannot save Product. Error:" + ex.Message.ToString();

            }
            isBusy = false;
        }

        public async Task GetAllProducts()
        {
            Clear();
            isBusy = true;
            try
            {
                lstProducts = new ObservableCollection<Urun>();
                if (connectFirebase())
                {
                    var lst = (await fClient.Child(productResource).OnceAsync<Urun>()).Select(x =>
                    new Urun
                    {
                        productId = x.Object.productId,
                        productName = x.Object.productName,
                        productPrice = x.Object.productPrice,
                    }).ToList();

                    lstProducts = new ObservableCollection<Urun>(lst);
                }
            }
            catch (Exception ex)
            {
                lblMessage = "Error occurred in getting products. Error:" + ex.Message.ToString();
            }
            isBusy = false;
        }

        public void setProduct(Urun edt)
        {
            product = new Urun();
            product.productName = edt.productName;
            product.productPrice = edt.productPrice;
            btnSaveText = "UPDATE";
            product.productId = edt.productId;
        }

        public void Clear()
        {
            product = new Urun();
            product.productName = "";
            product.productPrice = null;
            isBusy = false;
            product.productId = Guid.Empty;
            btnSaveText = "SAVE";
            lblMessage = "";
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
