using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoLAccManager
{
	public class Account
	{
		public string AccountUser
		{
			get;
			set;
		}

		public string AccountPass
		{
			get;
			set;
		}

		public string AccountIGN
		{
			get;
			set;
		}

		public string AccountRank
		{
			get;
			set;
		}

		public static async Task<string> GetAsync(string uri)
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(uri);
			obj.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			using HttpWebResponse response = (HttpWebResponse)(await obj.GetResponseAsync());
			using Stream stream = response.GetResponseStream();
			using StreamReader reader = new StreamReader(stream);
			return await reader.ReadToEndAsync();
		}

		public static List<Account> LoadAccounts()
		{
			List<Account> list = new List<Account>();
			StreamReader streamReader = new StreamReader("apikey.txt");
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				if (text.StartsWith("RiotDevAPIKey:"))
				{
					_ = text.Split(':')[1];
				}
			}
			string key = text;
			JArray jArray = new JArray();
			using (StreamReader reader = File.OpenText("accountData.json"))
			{
				using JsonTextReader reader2 = new JsonTextReader(reader);
				jArray = (JArray)JToken.ReadFrom(reader2);
			}
			foreach (JToken item in jArray)
			{
				Account account = new Account(item.ToString());
				string ingame = account.AccountIGN;
				string rank = string.Empty;
				Task.Run(async delegate
				{
					while (true)
					{
						try
						{
							JToken arg = JObject.Parse(GetAsync($"https://euw1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{ingame}?api_key={key}").Result)["id"];
							JObject jObject = (JObject)JArray.Parse(GetAsync($"https://euw1.api.riotgames.com/lol/league/v4/entries/by-summoner/{arg}?api_key={key}").Result).FirstOrDefault((JToken x) => x["queueType"]!.ToString() == "RANKED_SOLO_5x5");
							rank = jObject["tier"]?.ToString() + " " + jObject["rank"]?.ToString() + " | " + jObject["leaguePoints"]?.ToString() + "LP";
							return;
						}
						catch (Exception)
						{
							Thread.Sleep(1000);
						}
					}
				}).GetAwaiter().GetResult();
				account.AccountRank = rank;
				list.Add(account);
			}
			return list;
		}

		public Account()
		{
		}

		public Account(string json)
		{
			JObject jObject = JObject.Parse(json);
			AccountUser = jObject["AccountUser"]!.ToString();
			AccountPass = jObject["AccountPass"]!.ToString();
			AccountIGN = jObject["AccountIGN"]!.ToString();
			AccountRank = jObject["AccountRank"]!.ToString();
		}
	}
}
