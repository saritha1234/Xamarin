using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Xml;
using RestSharp.Serializers;

namespace WeatherApp
{
	[Activity (Label = "WeatherApp", MainLauncher = true, Icon = "@drawable/weather")]
	public class MainActivity : Activity
	{
		RestHandler objRest;
		ListView lstForecast;
		List<Forecast> myList ;
		TextView lblCurrentLocation;
		TextView lblTemparature;
		TextView lblHumidity;
		TextView lblWindSpeed;
		TextView lblVisibility;
		TextView lblConditionText;
		TextView lblSunrise;
		TextView lblSunset;
		ImageView imgWeatherIcon;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			lstForecast = FindViewById<ListView> (Resource.Id.lstForecast);

			lblCurrentLocation = FindViewById<TextView> (Resource.Id.lblCurrentLocation);
			lblTemparature = FindViewById<TextView> (Resource.Id.lblTemparature);
			lblHumidity = FindViewById<TextView> (Resource.Id.lblHumidity);
			lblWindSpeed = FindViewById<TextView> (Resource.Id.lblWindSpeed);
			lblVisibility = FindViewById<TextView> (Resource.Id.lblVisibility);
			lblConditionText = FindViewById<TextView> (Resource.Id.lblConditionText);
			lblSunrise = FindViewById<TextView> (Resource.Id.lblSunrise);
			lblSunset = FindViewById<TextView> (Resource.Id.lblSunset);
			imgWeatherIcon = FindViewById<ImageView> (Resource.Id.imgWeatherIcon);

			LoadHamiltonWeather ();
		}
		public int Celsius(double fahrenheit)
		{
			double c = 5.0 / 9.0 * (fahrenheit - 32);
			return (int)c;
		}

		private void LoadWeather(Rss Response)
		{
			lstForecast.Adapter = new DataAdapter (this, Response.Channel.Item.Forecast);
			myList = Response.Channel.Item.Forecast;

			lblCurrentLocation.Text = Response.Channel.Location.City + ", " + Response.Channel.Location.Country + System.Environment.NewLine
				+ Response.Channel.Item.PubDate;
			lblTemparature.Text = "Temparature : " + Celsius(Convert.ToDouble(Response.Channel.Item.Condition.Temp)).ToString() + (char) 176  +"c" ;
			lblHumidity.Text = "Humidity : " + Response.Channel.Atmosphere.Humidity + @"%";
			lblWindSpeed.Text = "Windspeed : " + Response.Channel.Wind.Speed + @"km/h";
			lblVisibility.Text = "Visibility : " + Response.Channel.Atmosphere.Visibility;
			lblConditionText.Text = Response.Channel.Item.Condition.Text;
			lblSunrise.Text = "Sunrise : " + Response.Channel.Astronomy.Sunrise;
			lblSunset.Text = "Sunset : " + Response.Channel.Astronomy.Sunset;
			imgWeatherIcon.SetImageResource (GetImage(Response.Channel.Item.Condition.Text));
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
			} else if (conditionText.ToLower ().Contains ("thudershowers")) {				
				imageResourceId = Resource.Drawable.ThunderShowers;
			} else if (conditionText.ToLower ().Contains ("fair (day)")) {				
				imageResourceId = Resource.Drawable.MostlySunny;
			} else if (conditionText.ToLower ().Contains ("fair (night)")) {				
				imageResourceId = Resource.Drawable.ClearSky;
			} else if (conditionText.ToLower ().Contains ("fair (day)")) {				
				imageResourceId = Resource.Drawable.MostlySunny;
			} else if (conditionText.ToLower ().Contains ("hot")) {				
				imageResourceId = Resource.Drawable.Hot;

			} else	{							
				imageResourceId = Resource.Drawable.NAImage;					
			}
			return imageResourceId;
		}

		public async void LoadAucklandWeather()
		{
			objRest = new RestHandler (@"http://weather.yahooapis.com/forecastrss?w=2348079");
			var Response = await objRest.ExecuteRequestAsync ();
			LoadWeather (Response);
		}

		public async void LoadChristchurchWeather()
		{
			objRest = new RestHandler (@"http://weather.yahooapis.com/forecastrss?w=2348327");
			var Response = await objRest.ExecuteRequestAsync ();
			LoadWeather (Response);
		}

		public async void LoadHamiltonWeather()
		{
			objRest = new RestHandler (@"http://weather.yahooapis.com/forecastrss?w=2348696");
			var Response = await objRest.ExecuteRequestAsync ();
			LoadWeather (Response);
		}

		public async void LoadWellingtonWeather()
		{
			objRest = new RestHandler (@"http://weather.yahooapis.com/forecastrss?w=2351310");
			var Response = await objRest.ExecuteRequestAsync ();
			LoadWeather (Response);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			menu.Add ("Auckland");
			menu.Add ("Christchurch");
			menu.Add ("Hamilton");
			menu.Add ("Wellington");
			return base.OnPrepareOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			var itemTitle = item.TitleFormatted.ToString ();
			switch (itemTitle)
			{
			case "Auckland":
				LoadAucklandWeather();
				break;
			case "Christchurch":
				LoadChristchurchWeather();
				break;
			case "Hamilton":
				LoadHamiltonWeather();
				break;	
			case "Wellington":
				LoadWellingtonWeather();
				break;				
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}


	



