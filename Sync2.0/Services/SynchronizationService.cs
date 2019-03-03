using RestSharp;
using Sync2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Services
{
    public class SynchronizationService
    {
        private readonly ApplicationDbContext _context;
        private readonly RestClient _client;

        public SynchronizationService(ApplicationDbContext context)
        {
            _context = context;
            _client = new RestClient("http://localhost:3267");
        }

        public void Sync()
        {
            //foreach (var item in _context.ProjectTables.Where(p => p.)
            //{

            //}

            //var request = new RestRequest("api/ProjectTables", Method.POST);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            //// easily add HTTP Headers
            //request.AddHeader("header", "value");

            //// add files to upload (works with compatible verbs)
            //request.AddFile(path);

            //// execute the request
            //IRestResponse response = _client.Execute(request);
            //var content = response.Content; // raw content as string

            //// or automatically deserialize result
            //// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<Person> response2 = _client.Execute<Person>(request);
            //var name = response2.Data.Name;

            //// easy async support
            //_client.ExecuteAsync(request, response => {
            //    Console.WriteLine(response.Content);
            //});

            //// async with deserialization
            //var asyncHandle = _client.ExecuteAsync<Person>(request, response => {
            //    Console.WriteLine(response.Data.Name);
            //});

            //// abort the request on demand
            //asyncHandle.Abort();
        }
    }
}
