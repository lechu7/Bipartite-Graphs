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
        public static Form1 glowna = GrafDwudzielny.Form1.getInstance();
        public static void generateGraph(string algGrafu)
        {
        

            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);


            var wrapper = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);
           
           
            byte[] output = wrapper.GenerateGraph(algGrafu, Enums.GraphReturnType.Png);

            using (var ms = new MemoryStream(output))
            {
                Image.FromStream(ms).Save("img.png");   
            }
            
        


        }
    }
}
