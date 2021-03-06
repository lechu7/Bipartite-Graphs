﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafDwudzielny
{
    class Silnik
    {
        public static List<List<int>> macierzSasiedztwa = new List<List<int>>();
        static List<List<int>> macierzDrzewowa;
        static List<List<int>> macierzNieskierowana;
        static List<int> prev;
        static int licznik;
        static List<bool> visited;

        static void DFS()
        {
            licznik = 1;
            for (int i = 0; i < macierzNieskierowana.Count; i++)
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
            for (int j = 0; j < macierzNieskierowana.Count; j++)
            {
                if (macierzNieskierowana[i][j] > 0 && !visited[j])
                {
                    macierzDrzewowa[i][j] = 1;
                    explore(j);
                }
            }
            licznik++;
        }
        static void Inicjacja()
        {
            List<int> tymczasowa = new List<int>();
            macierzDrzewowa = new List<List<int>>();
            visited = new List<bool>();
            prev = new List<int>();
            macierzNieskierowana = new List<List<int>>();
            int n = macierzSasiedztwa.Count;
            for (int i = 0; i < n; i++)
            {
                visited.Add(false);
                prev.Add(0);
                macierzDrzewowa.Add(new List<int> { 0 });
                macierzNieskierowana.Add(new List<int> { 0 });
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    macierzDrzewowa[i].Add(0);
                    macierzNieskierowana[i].Add(0);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (macierzSasiedztwa[i][j] > macierzSasiedztwa[j][i])
                    {
                        macierzNieskierowana[i][j] = macierzSasiedztwa[i][j];
                        macierzNieskierowana[j][i] = macierzSasiedztwa[i][j];
                    }
                    else
                    {
                        macierzNieskierowana[i][j] = macierzSasiedztwa[j][i];
                        macierzNieskierowana[j][i] = macierzSasiedztwa[j][i];
                    }
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
                    if (i != j)
                    {
                        if (macierzNieskierowana[i][j] != macierzDrzewowa[i][j] && macierzDrzewowa[i][j] != 1)
                        {
                            if ((Math.Max(prev[i], prev[j]) - Math.Min(prev[i], prev[j]) + 1) % 2 == 1)
                            {
                                        return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
