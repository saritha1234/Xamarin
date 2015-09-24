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
using Java.Net;
using Android.Graphics;
using Java.IO;
using Android.Graphics.Drawables;
using Android.Util;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace WeatherApp
{
	public class DataAdapter : BaseAdapter<Forecast> {

		List<Forecast> items;
		Item item;

		Activity context;
		public DataAdapter(Activity context, List<Forecast> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override Forecast this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items [position];
			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate (Resource.Layout.CustomRow, null);

			view.FindViewById<TextView> (Resource.Id.Text1).Text = item.Day + " " + item.Date;
			view.FindViewById<TextView> (Resource.Id.Text2).Text = item.Text;
			view.FindViewById<TextView> (Resource.Id.Text3).Text = "Low  : " + Celsius(Convert.ToDouble(item.Low)).ToString() + (char) 176  +"c"  + " " + "," + " " + "High  : " + Celsius(Convert.ToDouble(item.High)).ToString() + (char) 176  +"c";
			view.FindViewById<ImageView> (Resource.Id.btnImage).SetImageResource (GetImage (item.Text));

			return view;
		}

		public int Celsius(double fahrenheit)
		{
			double c = 5.0 / 9.0 * (fahrenheit - 32);
			return (int)c;
		}

		public int GetImage(string conditionText)
		{
			int imageResourceId = Resource.Drawable.NAImage;

			if (conditionText.ToLower ().Contains ("sunny")) {
				imageResourceId = Resource.Drawable.Sunny;
			} else if (conditionText.ToLower ().Contains ("clear")) {
				imageResourceId = Resource.Drawable.ClearSky;
			} else if (conditionText.ToLower ().Contains ("partly cloudy")) {
				imageResourceId = Resource.Drawable.PartlyCloudy;
			} else if (conditionText.ToLower ().Contains ("cloudy")) {
				imageResourceId = Resource.Drawable.MostlyCloudyWindy;
			} else if (conditionText.ToLower ().Contains ("wind")) {
				imageResourceId = Resource.Drawable.MostlyCloudyWindy;
			} else if (conditionText.ToLower ().Contains ("rain")) {
				imageResourceId = Resource.Drawable.Rain;
			} else if (conditionText.ToLower ().Contains ("rain wind")) {
				imageResourceId = Resource.Drawable.PMLightRainWind;
			} else if (conditionText.ToLower ().Contains ("showers")) {
				imageResourceId = Resource.Drawable.LightRainShower;
			} else if (conditionText.ToLower ().Contains ("showers/wind")) {
				imageResourceId = Resource.Drawable.PMShowers;
			} else if (conditionText.ToLower ().Contains ("vicinity")) {
				imageResourceId = Resource.Drawable.ShowersVicinity;
			} else if (conditionText.ToLower ().Contains ("fog")) {
				imageResourceId = Resource.Drawable.Fog;
			} else if (conditionText.ToLower ().Contains ("thunderstorms")) {				
				imageResourceId = Resource.Drawable.Thunderstorms;
			} else if (conditionText.ToLower ().Contains ("drizzle")) {				
				imageResourceId = Resource.Drawable.Drizzle;
			} else if (conditionText.ToLower ().Contains ("snow")) {				
				imageResourceId = Resource.Drawable.Snow;
			} else if (conditionText.ToLower ().Contains ("tornado")) {				
				imageResourceId = Resource.Drawable.Tornado;
			} else if (conditionText.ToLower ().Contains ("hurricane")) {				
				imageResourceId = Resource.Drawable.Hurricane;
			} else if (conditionText.ToLower ().Contains ("storm")) {				
				imageResourceId = Resource.Drawable.Thunderstorms;
			} else if (conditionText.ToLower ().Contains ("hail")) {				
				imageResourceId = Resource.Drawable.Hail;
			} else if (conditionText.ToLower ().Contains ("smoky")) {				
				imageResourceId = Resource.Drawable.Fog;
			} else if (conditionText.ToLower ().Contains ("cold")) {				
				imageResourceId = Resource.Drawable.Cold;
			} else if (conditionText.ToLower ().Contains ("haze")) {				
				imageResourceId = Resource.Drawable.Haze;
			} else if (conditionText.ToLower ().Contains ("dust")) {				
				imageResourceId = Resource.Drawable.Haze;
			} else if (conditionText.ToLower ().Contains ("sleet")) {				
				imageResourceId = Resource.Drawable.Sleet;
			} else if (conditionText.ToLower ().Contains ("blustery")) {				
				imageResourceId = Resource.Drawable.Drizzle;
			} else if (conditionText.ToLower ().Contains ("windy")) {				
				imageResourceId = Resource.Drawable.Windy;
			} else if (conditionText.ToLower ().Contains ("thundershowers")) {				
				imageResourceId = Resource.Drawable.ThunderShowers;
			} else if (conditionText.ToLower ().Contains ("fair (day)")) {				
				imageResourceId = Resource.Drawable.MostlySunny;
			} else if (conditionText.ToLower ().Contains ("fair (night)")) {				
				imageResourceId = Resource.Drawable.ClearSky;
			} else if (conditionText.ToLower ().Contains ("hot")) {				
				imageResourceId = Resource.Drawable.Hot;
			} else	{							
				imageResourceId = Resource.Drawable.NAImage;
			}
			return imageResourceId;

		}

		private Bitmap GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;
			if(!(url=="null"))
				using (var webClient = new WebClient())
				{
					var imageBytes = webClient.DownloadData(url);
					if (imageBytes != null && imageBytes.Length > 0)
					{
						imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
					}
				}

			return imageBitmap;
		}
	} 
}

