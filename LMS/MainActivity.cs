using Android.App;
using Android.OS;
using AndroidX.Fragment.App;
using LMS.Prototypes;

namespace LMS;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
public class MainActivity : FragmentActivity
{
	// ActionBar on top
	// Fragment FolderFragment in the middle
	// // Clicking Folder launches new activity
	// ViewPager with FragmentPagerAdapter as a footer to swipe between FolderFragment's

	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(Resource.Layout.activity_main);

		FolderFragmentAdapter folderFragmentAdapter = new FolderFragmentAdapter(this);
		folderFragmentAdapter.AddFolderFragment();
		folderFragmentAdapter.UseFragment();
	}
}