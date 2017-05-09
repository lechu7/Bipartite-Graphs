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
using System.Windows.Forms;

namespace GrafDwudzielny
{
    class GeneracjaGrafu
    {
        public static Form1 glowna = Form1.getInstance();

        public static Image generateGraph(string algorytmGrafu)
        {


            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);


            var wrapper = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);


            byte[] output = wrapper.GenerateGraph(algorytmGrafu, Enums.GraphReturnType.Png);

            Image tmp = null;
            using (var ms = new MemoryStream(output))
            {
                try
                {
                    tmp = Image.FromStream(ms);
                }
                catch (Exception)
                {
                    glowna.Czyszczenie();
                    MessageBox.Show("Źle podane są krawędzie lub wierzchołki.\nGraf został zresetowny.", "Błąd wprowadzania",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    

                }

            }

            return tmp;


        }
    }
}
