﻿using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace WeatherApp
{
	[XmlRoot(ElementName="location", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
	public class Location {
		[XmlAttribute(AttributeName="city")]
		public string City { get; set; }
		[XmlAttribute(AttributeName="region")]
		public string Region { get; set; }
		[XmlAttribute(AttributeName="country")]
		public string Country { get; set; }
	}

	[XmlRoot(ElementName="units", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
	public class Units {
		[XmlAttribute(AttributeName="temperature")]
		public string Temperature { get; set; }
		[XmlAttribute(AttributeName="distance")]
		public string Distance { get; set; }
		[XmlAttribute(AttributeName="pressure")]
		public string Pressure { get; set; }
		[XmlAttribute(AttributeName="speed")]
		public string Speed { get; set; }
	}

	[XmlRoot(ElementName="wind", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
	public class Wind {
		[XmlAttribute(AttributeName="chill")]
		public string Chill { get; set; }
		[XmlAttribute(AttributeName="direction")]
		public string Direction { get; set; }
		[XmlAttribute(AttributeName="speed")]
		public string Speed { get; set; }
	}

	[XmlRoot(ElementName="atmosphere", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
	public class Atmosphere {
		[XmlAttribute(AttributeName="humidity")]
		public string Humidity { get; set; }
		[XmlAttribute(AttributeName="visibility")]
		public string Visibility { get; set; }
		[XmlAttribute(AttributeName="pressure")]
		public string Pressure { get; set; }
		[XmlAttribute(AttributeName="rising")]
		public string Rising { get; set; }
	}

	[XmlRoot(ElementName="astronomy", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
	public class Astronomy {
		[XmlAttribute(AttributeName="sunrise")]
		public string Sunrise { get; set; }
		[XmlAttribute(AttributeName="sunset")]
		public string Sunset { get; set; }
	}

	[XmlRoot(ElementName="image")]
	public class Image {
		[XmlElement(ElementName="title")]
		public string Title { get; set; }
		[XmlElement(ElementName="width")]
		public string Width { get; set; }
		[XmlElement(ElementName="height")]
		public string Height { get; set; }
		[XmlElement(ElementName="link")]
		public string Link { get; set; }
		[XmlElement(ElementName="url")]
		public string Url { get; set; }
	}

	[XmlRoot(ElementName="condition", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
	public class Condition {
		[XmlAttribute(AttributeName="text")]
		public string Text { get; set; }
		[XmlAttribute(AttributeName="code")]
		public string Code { get; set; }
		[XmlAttribute(AttributeName="temp")]
		public string Temp { get; set; }
		[XmlAttribute(AttributeName="date")]
		public string Date { get; set; }
	}

	[XmlRoot(ElementName="forecast", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
	public class Forecast {
		[XmlAttribute(AttributeName="day")]
		public string Day { get; set; }
		[XmlAttribute(AttributeName="date")]
		public string Date { get; set; }
		[XmlAttribute(AttributeName="low")]
		public string Low { get; set; }
		[XmlAttribute(AttributeName="high")]
		public string High { get; set; }
		[XmlAttribute(AttributeName="text")]
		public string Text { get; set; }
		[XmlAttribute(AttributeName="code")]
		public string Code { get; set; }
	}

	[XmlRoot(ElementName="guid")]
	public class Guid {
		[XmlAttribute(AttributeName="isPermaLink")]
		public string IsPermaLink { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="item")]
	public class Item {
		[XmlElement(ElementName="title")]
		public string Title { get; set; }
		[XmlElement(ElementName="lat", Namespace="http://www.w3.org/2003/01/geo/wgs84_pos#")]
		public string Lat { get; set; }
		[XmlElement(ElementName="long", Namespace="http://www.w3.org/2003/01/geo/wgs84_pos#")]
		public string Long { get; set; }
		[XmlElement(ElementName="link")]
		public string Link { get; set; }
		[XmlElement(ElementName="pubDate")]
		public string PubDate { get; set; }
		[XmlElement(ElementName="condition", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
		public Condition Condition { get; set; }
		[XmlElement(ElementName="description")]
		public string Description { get; set; }
		[XmlElement(ElementName="forecast", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
		public List<Forecast> Forecast { get; set; }
		[XmlElement(ElementName="guid")]
		public Guid Guid { get; set; }
	}

	[XmlRoot(ElementName="channel")]
	public class Channel {
		[XmlElement(ElementName="title")]
		public string Title { get; set; }
		[XmlElement(ElementName="link")]
		public string Link { get; set; }
		[XmlElement(ElementName="description")]
		public string Description { get; set; }
		[XmlElement(ElementName="language")]
		public string Language { get; set; }
		[XmlElement(ElementName="lastBuildDate")]
		public string LastBuildDate { get; set; }
		[XmlElement(ElementName="ttl")]
		public string Ttl { get; set; }
		[XmlElement(ElementName="location", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
		public Location Location { get; set; }
		[XmlElement(ElementName="units", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
		public Units Units { get; set; }
		[XmlElement(ElementName="wind", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
		public Wind Wind { get; set; }
		[XmlElement(ElementName="atmosphere", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
		public Atmosphere Atmosphere { get; set; }
		[XmlElement(ElementName="astronomy", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
		public Astronomy Astronomy { get; set; }
		[XmlElement(ElementName="image")]
		public Image Image { get; set; }
		[XmlElement(ElementName="item")]
		public Item Item { get; set; }
	}

	[XmlRoot(ElementName="rss")]
	public class Rss {
		[XmlElement(ElementName="channel")]
		public Channel Channel { get; set; }
		[XmlAttribute(AttributeName="yweather", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Yweather { get; set; }
		[XmlAttribute(AttributeName="geo", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Geo { get; set; }
		[XmlAttribute(AttributeName="version")]
		public string Version { get; set; }
	}
}

