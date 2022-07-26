using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.RecyclerView.Widget;

namespace LMS.Prototypes;

public class FolderRecViewAdapter : RecyclerView.Adapter
{
	private Context _context;
	private List<Folder> _folders = new List<Folder>();

	public FolderRecViewAdapter(Context context)
	{
		_context = context;
	}

	public override int ItemCount => _folders.Count;

	public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
	{
		View view = LayoutInflater.From(parent.Context)?.Inflate(Resource.Layout.folder, parent, false);
		return new ViewHolder(view);
	}

	public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
	{
	}

	public void SetFolders(List<Folder> folders)
	{
		_folders = folders;
		NotifyDataSetChanged();
	}

	public void AddFolder(Folder folder)
	{
		_folders.Add(folder);
		NotifyItemInserted(ItemCount - 1);
	}

	public class ViewHolder : RecyclerView.ViewHolder
	{
		private ConstraintLayout _folder;
		private ImageView _image;
		private TextView _name;

		public ViewHolder(View itemView) : base(itemView)
		{
			_folder = itemView.FindViewById<ConstraintLayout>(Resource.Id.folder_parent);
			_image = itemView.FindViewById<ImageView>(Resource.Id.folder_image);
			_name = itemView.FindViewById<TextView>(Resource.Id.folder_name);
		}
	}
}