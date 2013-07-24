using System;
using System.Collections.Generic;
using System.Linq;
using BddSpecFlowDemo.Models;

namespace BddSpecFlowDemo.Services
{
    public class AlbumsService : IAlbumsService
    {
        private Dictionary<string, string> data;
 
        public AlbumsService()
        {
            data = new Dictionary<string, string>
                       {
                           { "Actually", "Pet Shop Boys" },
                           { "Baby Beluga", "Raffi" },
                           { "A Charlie Brown Christmas", "Various" },
                       };
        }

        public Album SearchByTitle(string searchString)
        {
            var foundTitle = data.Keys.FirstOrDefault(title => title.ToUpper().Contains(searchString.ToUpper()));
            return string.IsNullOrEmpty(foundTitle)
                       ? null
                       : new Album {Title = foundTitle, Artist = data[foundTitle]};
        }
    }
}