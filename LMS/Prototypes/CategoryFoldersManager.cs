using System;
using Android.App;
using Android.Views;
using Android.Widget;

namespace LMS
{
	public class CategoryFoldersManager
	{
		private readonly Activity _activity;
		private readonly GridLayout _folderHolder;

		private int _folderSize;

		public CategoryFoldersManager(Activity activity)
		{
			_activity = activity;
			_folderHolder = activity.FindViewById<GridLayout>(Resource.Id.activity_main_folder_holder);
			
			SetMaxInRow(3);
		}

		/// <summary>
		/// Sets the maximum amount of folders in a row and resizes them to fit
		/// </summary>
		/// <param name="inRow">A number of folders that fit in 1 row</param>
		public void SetMaxInRow(int inRow)
		{
			_folderHolder.ColumnCount = inRow;
			
			// get folder view from memory or inflate it if it doesn't exist
			// check possible [obsolete] once a folder view is added to layout in xml
			ImageButton folderView = _activity.FindViewById<ImageButton>(Resource.Layout.folder);
			folderView ??= (ImageButton) _activity.LayoutInflater.Inflate(Resource.Layout.folder, _folderHolder, false);

			int folderMargin = ((ViewGroup.MarginLayoutParams) folderView.LayoutParameters).LeftMargin;
			
			var metrics = _activity.Resources.DisplayMetrics;

			// scale folder view size so that if there are inRow of them they will be centered
			// and will fill full width of the screen
			_folderSize = (metrics.WidthPixels - (int) Math.Round(inRow * metrics.Density) - _folderHolder.PaddingLeft * 2 - folderMargin * 2 * inRow) / inRow;

			// scale all folder views alredy added to the layout
			for (int itr = 0; itr < _folderHolder.ChildCount; ++itr)
			{
				var child = _folderHolder.GetChildAt(itr);
				child.LayoutParameters.Width = _folderSize;
				child.LayoutParameters.Height = _folderSize;
			}
		}
		
		/// <summary>
		/// Adds folder View to the GridLayout
		/// </summary>
		public void AddFolder()
		{
			// get folder view from memory or inflate it if it doesn't exist
			// check possible [obsolete] once a folder view is added to layout in xml
			ImageButton toAdd = _activity.FindViewById<ImageButton>(Resource.Layout.folder);
			toAdd ??= (ImageButton) _activity.LayoutInflater.Inflate(Resource.Layout.folder, _folderHolder, false);

			toAdd.LayoutParameters.Width = _folderSize;
			toAdd.LayoutParameters.Height = _folderSize;

			_folderHolder.AddView(toAdd);
		}
	}
}