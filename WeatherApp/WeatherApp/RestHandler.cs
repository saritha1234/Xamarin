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
using RestSharp;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace WeatherApp
{
	public class RestHandler
	{
		private string url;

		private IRestResponse response;


		public RestHandler ()
		{
			url = "";
		}

		public RestHandler(string lurl)
		{
			url = lurl;
		}

		public Rss ExecuteRequest()
		{
			var client = new RestClient(url);
			var request = new RestRequest();

			response = client.Execute(request);

			XmlSerializer serializer = new XmlSerializer(typeof(Rss));
			Rss objRss;

			TextReader sr = new StringReader(response.Content);
			objRss = (Rss)serializer.Deserialize(sr);
			return objRss;

		}

		public async Task<Rss> ExecuteRequestAsync()
		{
			var client = new RestClient(url);
			var request = new RestRequest();

			response = await client.ExecuteTaskAsync(request);

			XmlSerializer serializer = new XmlSerializer(typeof(Rss));
			Rss objRss;

			TextReader sr = new StringReader(response.Content);
			objRss = (Rss)serializer.Deserialize(sr);
			return objRss;
		}
	}
}

