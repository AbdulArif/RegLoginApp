using RegLoginApp.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Masterdetailpage : MasterDetailPage
    {
        public List<MasterPageItems> menuList { get; set; }

        public Masterdetailpage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItems>();
            //this are for android Icons you can download from android asset studio and include in Your Project Resources Folder
            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            //var page1 = new MasterPageItem() { Title = "FastDelivery", Icon = "ic_local_shipping_black_24dp.png", TargetType = typeof(View1) };
            //var page2 = new MasterPageItem() { Title = "Menus", Icon = "ic_restaurant_black_24dp", TargetType = typeof(View2) };
            //var page3 = new MasterPageItem() { Title = "Free Pizza", Icon = "ic_local_pizza_black_24dp.png", TargetType = typeof(View3) };
            //var page4 = new MasterPageItem() { Title = "Dining", Icon = "ic_local_dining_black_24dp.png", TargetType = typeof(View4) };
            //var page5 = new MasterPageItem() { Title = "Parking", Icon = "ic_local_parking_black_24dp.png", TargetType = typeof(View3) };
            //var page6 = new MasterPageItem() { Title = "LocateUs", Icon = "ic_my_location_black_24dp.png", TargetType = typeof(View2) };

            //Fot Ios icons
            var page1 = new MasterPageItems() { Title = "Detail Report", Icon = "ic_action_chrome_reader_mode.png", TargetType = typeof(Report) };
            var page2 = new MasterPageItems() { Title = "Summary Report", Icon = "ic_action_chrome_reader_mode.png", TargetType = typeof(SummaryReport) };
            var page3 = new MasterPageItems() { Title = "Enter Data", Icon = "ic_action_dvr.png", TargetType = typeof(EnterData) };
            var page4 = new MasterPageItems() { Title = "Log IN", Icon = "ic_action_dvr.png", TargetType = typeof(LoginPage) };
            var page5 = new MasterPageItems() { Title = "Sign Up", Icon = "ic_action_dvr.png", TargetType = typeof(MainPage) };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(SummaryReport)));
            this.BindingContext = new
            {
                Header = "",
                Image = "http://www3.hilton.com/resources/media/hi/GSPSCHF/en_US/img/shared/full_page_image_gallery/main/HH_food_22_675x359_FitToBoxSmallDimension_Center.jpg",
                //Footer = "         -------- Welcome To HotelPlaza --------           "
                Footer = "Welcome To this app"
            };
        }



        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItems)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }   
    }
}