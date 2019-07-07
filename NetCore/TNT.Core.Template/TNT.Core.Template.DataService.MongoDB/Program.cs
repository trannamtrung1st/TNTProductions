using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TNT.Core.Template.DataService.MongoDB.Data;
using TNT.Core.Template.DataService.MongoDB.Helpers;
using TNT.Core.Template.DataService.MongoDB.ViewModels;

namespace TNT.Core.Template.DataService.MongoDB
{

    class Program
    {
        static Func<List<List<int>>, int> test = a => 1;
        static void Main(string[] args)
        {
            Console.WriteLine(1.GetType().SyntaxName());
        }

    }
}
