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
        public static byte[] generateGraph()
        {


            // These three instances can be injected via the IGetStartProcessQuery, 
            //                                               IGetProcessStartInfoQuery and 
            //                                               IRegisterLayoutPluginCommand interfaces

            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            // GraphGeneration can be injected via the IGraphGeneration interface

            var wrapper = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);
           
           
            byte[] output = wrapper.GenerateGraph("digraph{a -> b; b -> c; c -> a;}", Enums.GraphReturnType.Png);
            return output;
           
        }
    }
}
