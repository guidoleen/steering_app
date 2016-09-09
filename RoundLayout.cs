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
using Android.Gestures;

namespace AppSteering.Droid
{
	[Activity (Label = "RoundLayout", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]	
	public class RoundLayout : Activity, View.IOnTouchListener
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			// Gesture creating for retrieving touch
			GestureOverlayView GestOverView = new GestureOverlayView(this);
			GestOverView.GestureColor = Color.Transparent;
			GestOverView.SetOnTouchListener(this);

			// Create Layout and list for the views
			var _roundlayout = new RelativeLayout(this);
			var _layoutParams = new RelativeLayout.LayoutParams (ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent);
			_roundlayout.LayoutParameters = _layoutParams;

			// Call the createview method
			CreateView creview = new CreateView (24, _roundlayout, _listInsert, this.BaseContext, 30, 30);

			// Put the metrics for display
			var metrics = Resources.DisplayMetrics;
			var _Screenwidth = metrics.WidthPixels;

			// Call the Method to make circle
			PositionView(_listInsert, _Screenwidth);

			// De globale textview waarde toevoegen aan de layout
			textvWaarde = new TextView (this.BaseContext);
			textvWaarde.SetWidth(200);
			textvWaarde.SetHeight (100);
			textvWaarde.SetTextColor(Android.Graphics.Color.Black);
			textvWaarde.SetBackgroundColor (Android.Graphics.Color.Aqua);
			_roundlayout.AddView (textvWaarde);

			// Laat layout zien TODO
			GestOverView.AddView(_roundlayout);
			SetContentView(GestOverView);

			// _roundlayout.SetOnTouchListener (this);
//			SetContentView (_roundlayout);
		}

		// global list for the views
		public List<TextView> _listInsert = new List<TextView>();

		// The Actual Method for circleDrwawing
		public void PositionView(List<TextView> _listPos, float _screenwidth)
		{
			double iChanger = 7;
			float iScreenWidth = _screenwidth/2;
			double itellX = 0;
			double itellY = 0;
			double ilistpos = _listPos.Count;
			double iRadius = (360/ilistpos);
			double iRadiusFlag = 1;
			double iHalfDiam = ((ilistpos - 1) * iChanger);

			for (int i = 0; i < ilistpos; i++) 
			{
				double iDistXFlag = iRadius * iRadiusFlag;

				const double Deg = Math.PI / 180;
				double iSin = Math.Round(Math.Sin(iDistXFlag * Deg), 4);
				double iCos = Math.Round(Math.Cos(iDistXFlag * Deg), 4);

				itellX = iSin * iHalfDiam;
				itellY = iCos * iHalfDiam;

				// Console.WriteLine (iSin + " "  + iDistXFlag + " " + iCos + " " +  i.ToString ());

				// Eventually the values for position
				_listPos[i].SetX ((float)itellX + iScreenWidth);
				_listPos [i].SetY ((float)itellY + iScreenWidth);

				// set the Listener TODO
				// _listPos [i].SetOnTouchListener(this);

				// Ophogen van de hulpvariable
				iRadiusFlag++;
			}
		}

		// Global Textview to show values
		public TextView textvWaarde;
		public bool OnTouch(View v, MotionEvent E)
		{
			// Hulp textview doorgeven waardes
			switch (E.Action) 
			{
			case MotionEventActions.HoverEnter:
			case MotionEventActions.HoverMove:
			case MotionEventActions.Down:
			case MotionEventActions.Move:
				v.Alpha = 1.0f;
				// Console.WriteLine (v.GetX ().ToString ());
				textvWaarde.Text = E.GetX().ToString();
				break;

			// TODO eventueel aanzetten alfa
//			case MotionEventActions.Up:
//				v.Alpha = 0.3f;
//				break;
			}
			return true;
		}
	}
}

////// TODO!!!
/// 		// Global Textview to show values
//public TextView textvWaarde;
//public bool OnTouch(View v, MotionEvent E)
//{
//	// Hulp textview doorgeven waardes
//	TextView tvv = new TextView(this.BaseContext);
//	tvv = (TextView) v;
//
//	switch (E.Action) 
//	{
//	case MotionEventActions.HoverEnter:
//	case MotionEventActions.HoverMove:
//	case MotionEventActions.Down:
//	case MotionEventActions.Move:
//		v.Alpha = 1.0f;
//		// Console.WriteLine (v.GetX ().ToString ());
//		Console.WriteLine (tvv.Text.ToString ());
//		textvWaarde.Text = tvv.Text.ToString ();
//		break;
//	case MotionEventActions.Up:
//		v.Alpha = 0.3f;
//		break;
//	}
//	return true;
//}
