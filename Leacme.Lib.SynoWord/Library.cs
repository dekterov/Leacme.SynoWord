// Copyright (c) 2017 Leacme (http://leac.me). View LICENSE.md for more information.
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Leacme.Lib.SynoWord {

	public class Library {

		public static RestClient dicClient { get; } = new RestClient("https://en.wiktionary.org/w/api.php");

		public Library() {

		}

		/// <summary>
		/// Retrieve the definition for a term via the Wiktionary API.
		/// /// </summary>
		/// <param name="searchTerm"></param>
		/// <returns>The term definition response object. If successful, the formatted definition string is retrieved via
		/// DefinitionResults.Query.Pages.First().Value.Extract where its Key is not -1 </returns>
		public async Task<DefinitionResults> GetSearchTermResponceAsync(string searchTerm) {
			var searchReq = new RestRequest(dicClient.BaseUrl, Method.GET, DataFormat.Json);
			searchReq.AddQueryParameter("action", "query");
			searchReq.AddQueryParameter("format", "json");
			searchReq.AddQueryParameter("prop", "extracts");
			searchReq.AddQueryParameter("explaintext", "");
			searchReq.AddQueryParameter("titles", searchTerm);
			return await Task.Run(() => JsonConvert.DeserializeObject<DefinitionResults>(dicClient.Execute(searchReq).Content));
		}
	}
}