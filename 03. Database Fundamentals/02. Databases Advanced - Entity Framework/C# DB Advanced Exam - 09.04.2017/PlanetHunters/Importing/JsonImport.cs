using Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importing
{
    public class JsonImport
    {
        public static void Json(string path, List<object> givenObjects)
        {
            var json = File.ReadAllText(path);
            var collection = JsonConvert.DeserializeObject(json);
        }        
    }
}
