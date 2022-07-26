using System.Collections.Generic;
using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using LMS.Prototypes;

namespace LMS.Fragments;

public class FolderFragment : Fragment
{
	private FolderRecViewAdapter _adapter;
	private RecyclerView _folderContainer;

	public FolderFragment() : base(Resource.Layout.folder_fragment)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_folderContainer = view.FindViewById<RecyclerView>(Resource.Id.folders_recycler_view);
		_adapter = new FolderRecViewAdapter(Context);

		_folderContainer!.SetAdapter(_adapter);

		var layoutManager = new GridLayoutManager(Context, 3);
		// layoutManager.SpanCount = 2;
		layoutManager.Orientation = LinearLayoutManager.Vertical;

		_folderContainer.SetLayoutManager(layoutManager);

		var fol = new List<Folder>
		{
			new(1, "test"),
			new(2, "test"),
			new(3, "test"),
			new(4, "test")
		};

		_adapter.SetFolders(fol);
	}

	public void AddFolder(Folder folder)
	{
		_adapter.AddFolder(folder);
	}
}