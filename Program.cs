using SimpleMoviesAppV2.Controller;
//using SimpleMoviesAppV2.Model;
using MyMangerLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMoviesAppV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieController controller = new MovieController();
            controller.Start();
        }
    }
}
