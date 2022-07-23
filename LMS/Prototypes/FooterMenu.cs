using System.Diagnostics.CodeAnalysis;
using Android.Views;
using Android.Widget;

namespace LMS
{
	public class FooterMenu
	{
		private readonly LinearLayout _menu;

		public FooterMenu([NotNull] LinearLayout menu)
		{
			_menu = menu;
			Init();
		}

		private void Init()
		{
			for (int itr = 0; itr < _menu.ChildCount; ++itr)
			{
				_menu.GetChildAt(itr)!.Click += (sender, touchEventArgs) =>
				{
					ResetButtonStates();
					((Button) sender).Activated = true;
				};
			}
		}

		private void ResetButtonStates()
		{
			for (int itr = 0; itr < _menu.ChildCount; ++itr)
				_menu.GetChildAt(itr)!.Activated = false;
		}
		
	}
}