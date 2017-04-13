using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafDwudzielny
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
      ///  [STAThread]

        static List<List<int>> macierz = new List<List<int>>();
        static List<List<int>> macierzDrzewowa = new List<List<int>>();
        static List<int> prev = new List<int>();
        static List<int> post = new List<int>();
        static int licznik;
        static List<bool> visited = new List<bool>();

        static void DFS()
        {
            licznik = 1;
            for (int i = 0; i < macierz.Count; i++)
            {
                if (!visited[i])
                {
                    explore(i);
                }
            }
        }
        static void explore(int i)
        {
            visited[i] = true;
            prev[i] = licznik;
            licznik++;
            for (int j = 0; j < macierz.Count; j++)
            {
                if (macierz[i][j]==1 && !visited[j])
                {
                    macierzDrzewowa[i][j] = 1;
                    explore(j);
                }
            }
            post[i] = licznik;
            licznik++;
        }
        static void Inicjacja()
        {
            List<int> tymczasowa = new List<int>();
            for (int i = 0; i < macierz.Count; i++)
            {
                visited.Add(false);
                prev.Add(0);
                post.Add(0);
                macierzDrzewowa.Add(new List<int>{0});
            }
            for (int i = 0; i < macierz.Count; i++)
            {
                for (int j = 1; j < macierz.Count; j++)
                {
                    macierzDrzewowa[i].Add(0);
                }
            }
            licznik = 0;
        }
        public static bool sprawdz()
        {
            List<int> jeden = new List<int>() { 0,1,1};
            List<int> dwa = new List<int> { 1, 0, 1};
            List<int> trzy = new List<int> { 1,1, 0 };
          //  List<int> cztery = new List<int> {1,0, 1, 0 };
            macierz.Add(jeden);
            macierz.Add(dwa);
            macierz.Add(trzy);
          //  macierz.Add(cztery);
            Inicjacja();
            DFS();
            for (int i = 0; i < macierz.Count; i++)
            {
                for (int j = 0; j < macierz.Count; j++)
                {
                    if (macierz[i][j]!=macierzDrzewowa[i][j])
                    {
                        if ((Math.Max(prev[i],prev[j])-Math.Min(prev[i],prev[j])+1)%2==1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
