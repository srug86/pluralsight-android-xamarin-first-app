using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RaysHotDogs.Core
{
	public class HotDogWebRepository
	{
		string url =
			"http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";

		public HotDogWebRepository ()
		{
			Task.Run (() => this.LoadDataAsync (url)).Wait ();
		}
		
		public List<HotDog> GetAllHotDogs()
		{
			IEnumerable <HotDog> hotDogs = 
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs

				select hotDog;
			return hotDogs.ToList<HotDog> ();
		}

		public List<HotDogGroup> GetGroupedHotDogs()
		{
			return hotDogGroups;
		}

		public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
		{
			var group =  hotDogGroups.Where (h => h.HotDogGroupId == hotDogGroupId).FirstOrDefault();

			if (group != null) 
			{
				return group.HotDogs;
			}
			return null;
		}

		public List<HotDog> GetFavoriteHotDogs()
		{
			IEnumerable <HotDog> hotDogs = 
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs
					where hotDog.IsFavorite
				select hotDog;

			return hotDogs.ToList<HotDog> ();
		}

		public HotDog GetHotDogById(int hotDogId)
		{
			IEnumerable <HotDog> hotDogs = 
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.HotDogs
					where hotDog.HotDogId == hotDogId
				select hotDog;

			return hotDogs.FirstOrDefault();
		}

		private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();

		private async Task LoadDataAsync(string uri)
		{
			if (hotDogGroups != null) 
			{
				string responseJsonString = null;

				using (var httpClient = new HttpClient ()) 
				{
					try 
					{
						Task<HttpResponseMessage> getResponse = httpClient.GetAsync (uri);

						HttpResponseMessage response = await getResponse;

						responseJsonString = await response.Content.ReadAsStringAsync ();
						hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>> (responseJsonString);
					} 
					catch (Exception ex) 
					{
						//handle any errors here, not part of the sample app
						string message = ex.Message;
					}
				}
			}
		}
	}
}