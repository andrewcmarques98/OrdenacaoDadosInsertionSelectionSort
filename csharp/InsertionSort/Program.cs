using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc = 0;

            int number;
            string arquivo;

            DateTime inicio = new DateTime();
            DateTime fim = new DateTime();

            DateTime[] mediaTempos = { };

            Dictionary<string, string> oTempo = new Dictionary<string, string>();
            string[] oTempoMedio = { };

            string[] arquivos = { "vetorordenado1k", "vetorordenado10k", "vetorordenado100k", "vetordesordenado1k", "vetordesordenado10k", "vetordesordenado100k", "vetorordenadodesc1k", "vetorordenadodesc10k", "vetorordenadodesc100k" };
            string[] oMenu = { "Bubble Sort", "Insertion Sort", "Selection Sort" };

            #region Files
            List<Vetores> oVetores = new List<Vetores>();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            var vetorOrd1k = new Vetores() { index = 1, vetor = File.ReadAllLines($"{path}{arquivos[0]}"), file = arquivos[0], newVetor = { }, microsegundos = 0 };
            var vetorOrd10k = new Vetores() { index = 2, vetor = File.ReadAllLines($"{path}{arquivos[1]}"), file = arquivos[1], newVetor = { }, microsegundos = 0 };
            var vetorOrd100k = new Vetores() { index = 3, vetor = File.ReadAllLines($"{path}{arquivos[2]}"), file = arquivos[3], newVetor = { }, microsegundos = 0 };
            oVetores.Add(vetorOrd1k);
            oVetores.Add(vetorOrd10k);
            oVetores.Add(vetorOrd100k);

            var vetorDesord1k = new Vetores() { index = 4, vetor = File.ReadAllLines($"{path}{arquivos[3]}"), file = arquivos[3], newVetor = { }, microsegundos = 0 };
            var vetorDesord10k = new Vetores() { index = 5, vetor = File.ReadAllLines($"{path}{arquivos[4]}"), file = arquivos[4], newVetor = { }, microsegundos = 0 };
            var vetorDesord100k = new Vetores() { index = 6, vetor = File.ReadAllLines($"{path}{arquivos[5]}"), file = arquivos[5], newVetor = { }, microsegundos = 0 };
            oVetores.Add(vetorDesord1k);
            oVetores.Add(vetorDesord10k);
            oVetores.Add(vetorDesord100k);

            var vetorDesc1k = new Vetores() { index = 7, vetor = File.ReadAllLines($"{path}{arquivos[6]}"), file = arquivos[6], newVetor = { }, microsegundos = 0 };
            var vetorDesc10k = new Vetores() { index = 8, vetor = File.ReadAllLines($"{path}{arquivos[7]}"), file = arquivos[7], newVetor = { }, microsegundos = 0 };
            var vetorDesc100k = new Vetores() { index = 9, vetor = File.ReadAllLines($"{path}{arquivos[8]}"), file = arquivos[8], newVetor = { }, microsegundos = 0 };
            oVetores.Add(vetorDesc1k);
            oVetores.Add(vetorDesc10k);
            oVetores.Add(vetorDesc100k);
            #endregion

            Console.WriteLine("Qual arquivo gostaria de fazer os testes?\n");

            foreach (var item in oMenu.ToList())
            {
                opc++;
                Console.WriteLine($"{opc} - {item}");
            }

            Console.Write("\nEscolha a opção: ");

            if (!Int32.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("\nOpção inválida. Tente novamnete\n");
                Console.ReadLine();
            }
            else
            {

                for (int id = 0; id < 3; id++)
                {
                    int i = 0;
                    foreach (var file in oVetores.ToList())
                    {
                        int[] newVetor = { };

                        switch (number)
                        {
                            case 2:
                                Console.WriteLine($"\nINICINADO OS TESTE PARA INSERTION SORT: {i+1}-{file.file}");
                                Console.WriteLine();

                                Thread.Sleep(3000);
                                inicio = DateTime.Now;
                                newVetor = InsertionSort(Array.ConvertAll(file.vetor, x => int.Parse(x)));
                                fim = DateTime.Now;

                                break;

                            case 3:
                                Console.WriteLine($"\nINICINADO OS TESTE PARA SELECTION SORT: {i + 1}-{file.file}");
                                Console.WriteLine();

                                Thread.Sleep(3000);
                                inicio = DateTime.Now;
                                newVetor = SelectionSort(Array.ConvertAll(file.vetor, x => int.Parse(x)));
                                fim = DateTime.Now;
                                break;

                            default:
                                Console.WriteLine("\nOpção inválida. Tente novamnete\n");
                                Console.ReadLine();
                                break;
                        }

                        if (number != 1 || number > 3)
                        {
                            oVetores[i].newVetor = newVetor;

                            Console.WriteLine("Sorted:");
                            Console.WriteLine(string.Join(", ", newVetor));
                            Console.WriteLine();

                            long micro = ((long)(fim - inicio).TotalMilliseconds) * 1000;
                            oVetores[i].microsegundos += micro;
                            Console.WriteLine($"Tempo: {oVetores[i].microsegundos} microsegundos");
                        }

                        i++;
                    }
                }

                var numberText = number == 2 ? "INSERTION SORT" : number == 3 ? "SELECTION SORT" : "#ERROR";
                Console.WriteLine($"\nRESUMO DOS TESTES - {numberText}:");

                int i2 = 1;
                Console.WriteLine("");
                Console.WriteLine(" {0,-5} {1,-30} {2,-30}", "#", "ARQUVIO", "MICROSEGUNDOS");
                Console.WriteLine("");

                foreach (var item in oVetores.ToList())
                {
                    Console.WriteLine(" {0,-5} {1,-30} {2,-30}", i2, item.file, (item.microsegundos / 5));
                    i2++;
                }

            }
            Console.WriteLine("\n\nPressione uma tecla para finalizar");
            Console.ReadKey();
        }

        static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];

                int j = i - 1;
                for (; j >= 0 && current < array[j]; j--)
                {
                    array[j + 1] = array[j];
                }
                array[j + 1] = current;
            }

            return array;
        }

        static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = 1;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
            return array;
        }
    }

    class Vetores
    {
        public int index;
        public string[] vetor;
        public string file;
        public int[] newVetor;
        public long microsegundos;
    }
}
