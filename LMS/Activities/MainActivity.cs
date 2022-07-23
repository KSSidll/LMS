using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace LMS
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            
            var footerMenu = new FooterMenu(FindViewById<LinearLayout>(Resource.Id.activity_main_footer_menu));
            var categoryFoldersManager = new CategoryFoldersManager(this);
            categoryFoldersManager.AddFolder();

            var addfolder = FindViewById<Button>(Resource.Id.add_folder_placeholder);
            addfolder.Click += (sender, args) => categoryFoldersManager.AddFolder();

        }
    }
}