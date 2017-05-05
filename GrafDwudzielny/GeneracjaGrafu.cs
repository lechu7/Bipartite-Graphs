using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;
using System.IO;
using System.Drawing;

namespace GrafDwudzielny
{
    class GeneracjaGrafu
    {
       
        public static Image generateGraph(string algorytmGrafu)
        {
        

            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);


            var wrapper = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);
           
           
            byte[] output = wrapper.GenerateGraph(algorytmGrafu, Enums.GraphReturnType.Png);

            // File.Delete("img.png");
            Image tmp;
            using (var ms = new MemoryStream(output))
            {
               tmp= Image.FromStream(ms);
            }

            return tmp;


        }
    }
}
