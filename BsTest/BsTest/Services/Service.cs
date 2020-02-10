using BsTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace BsTest.Services
{
    public class Service
    {
        JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
        private string getData(string service)
        {
            WebRequest webRequest = null;
            switch (service)
            {
                case "albums":
                    webRequest = WebRequest.Create("https://jsonplaceholder.typicode.com/albums");
                    break;
                case "photos":
                    webRequest = WebRequest.Create("https://jsonplaceholder.typicode.com/photos");
                    break;
                case "comments":
                    webRequest = WebRequest.Create("https://jsonplaceholder.typicode.com/comments");
                    break;
                default:
                    break;
            }

            WebResponse webResponse = webRequest.GetResponse();
            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
            string responseFromServer = streamReader.ReadToEnd();
            streamReader.Close();
            webResponse.Close();

            return responseFromServer;

        }

        public List<Album> GetAlbumList()
        {
            return jsonSerializer.Deserialize<List<Album>>(this.getData("albums"));
        }


        public List<Photo> GetPhotos()
        {
            return jsonSerializer.Deserialize<List<Photo>>(this.getData("photos"));
        }

        public List<Comment> GetComments()
        {
            return jsonSerializer.Deserialize<List<Comment>>(this.getData("comments"));
        }

    }
}