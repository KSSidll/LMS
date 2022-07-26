using System.Collections.Generic;
using AndroidX.Fragment.App;
using LMS.Fragments;

namespace LMS.Prototypes;

public class FolderFragmentAdapter
{
	private readonly List<FolderFragment> _folderFragments;
	private readonly FragmentActivity _fragmentActivity;

	public FolderFragmentAdapter(FragmentActivity fragmentActivity)
	{
		_fragmentActivity = fragmentActivity;
		_folderFragments = new List<FolderFragment>();
	}

	public void AddFolderFragment()
	{
		_folderFragments.Add(new FolderFragment());
	}

	public void UseFragment()
	{
		FragmentTransaction fragmentTransaction = _fragmentActivity.SupportFragmentManager.BeginTransaction();
		fragmentTransaction.Replace(Resource.Id.folder_fragment, _folderFragments[0]);
		fragmentTransaction.Commit();
	}
}