using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using LMS.Prototypes;

namespace LMS;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
	private FolderRecViewAdapter _adapter;
	private RecyclerView _folderContainer;

	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(Resource.Layout.activity_main);

		var footerMenu = new FooterMenu(FindViewById<LinearLayout>(Resource.Id.activity_main_footer_menu));

		_adapter = new FolderRecViewAdapter();

		_folderContainer = FindViewById<RecyclerView>(Resource.Id.folders_recycler_view);
		_folderContainer.SetAdapter(_adapter);
		GridLayoutManager layoutManager = new GridLayoutManager(this, 3);
		layoutManager.Orientation = GridLayoutManager.Vertical;
		_folderContainer.SetLayoutManager(layoutManager);

		List<Folder> fol = new List<Folder>();
		fol.Add(new Folder(1, "test"));
		fol.Add(new Folder(2, "test"));
		fol.Add(new Folder(3, "test"));
		fol.Add(new Folder(4, "test"));
		_adapter.SetFolders(fol);

		Button injectfoldertofolderrecviewthroughfolderrecviewadapter =
			FindViewById<Button>(Resource.Id.add_folder_placeholder);
		injectfoldertofolderrecviewthroughfolderrecviewadapter!.Click += (sender, args) =>
		{
			_adapter.AddFolder(new Folder(1, "test"));
		};
	}
}