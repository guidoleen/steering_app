using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Systems;
using Android.Graphics;
using Android.Content.PM;


namespace AppSteering.Droid
{
	public class CreateView // extends Activity, View.IOnTouchListener
	{
		public string iIdView;
		public CreateView (int inumberviews, RelativeLayout layout, List<TextView> listinsert, Context context, int _width, int _height)
		{

			for (int i = 0; i <= inumberviews; i++) 
			{
				TextView tv01 = new TextView(context);
				tv01.Text = i.ToString();
				iIdView = i.ToString();
				tv01.SetWidth(_width);
				tv01.SetHeight(_height);
				tv01.Alpha = 0.5f;
				// tv01.SetOnTouchListener(this);
				tv01.SetBackgroundResource (Resource.Drawable.cornerssetup);

				layout.AddView (tv01);
				listinsert.Add (tv01);
			}
		}
	}
}