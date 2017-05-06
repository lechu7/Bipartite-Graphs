using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafDwudzielny
{
    class Silnik
    {
       public static List<List<int>> macierzSasiedztwa = new List<List<int>>();
        static List<List<int>> macierzDrzewowa = new List<List<int>>();
        static List<int> prev = new List<int>();
        static List<int> post = new List<int>();
        static int licznik;
        static List<bool> visited = new List<bool>();

        static void DFS()
        {
            licznik = 1;
            for (int i = 0; i < macierzSasiedztwa.Count; i++)
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
            for (int j = 0; j < macierzSasiedztwa.Count; j++)
            {
                if (macierzSasiedztwa[i][j] == 1 && !visited[j])
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
            int n = macierzSasiedztwa.Count;
            for (int i = 0; i < n; i++)
            {
                visited.Add(false);
                prev.Add(0);
                post.Add(0);
                macierzDrzewowa.Add(new List<int> { 0 });
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    macierzDrzewowa[i].Add(0);
                }
            }
            licznik = 0;
        }
        public static bool sprawdz()
        {
            Inicjacja();
            DFS();
            for (int i = 0; i < macierzSasiedztwa.Count; i++)
            {
                for (int j = 0; j < macierzSasiedztwa.Count; j++)
                {
                    if (macierzSasiedztwa[i][j] != macierzDrzewowa[i][j])
                    {
                        if ((Math.Max(prev[i], prev[j]) - Math.Min(prev[i], prev[j]) + 1) % 2 == 1)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
