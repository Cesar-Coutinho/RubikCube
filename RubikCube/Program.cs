using System.Runtime.CompilerServices;

namespace RubikCube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            #region Variáveis
            string ladoACimaDefault = @"/\";
            string ladoABaixoDefault = @"\/";
            string ladoBCimaDefault = @"_\";
            string ladoBBaixoDefault = @"_/";


            string ladoACima = @"/\";
            string ladoABaixo = @"\/";
            string ladoBCima = @"_\";
            string ladoBBaixo = @"_/";
            string space = "";
            #endregion;

            //Neste momento, eu estava procurando os padrões de criação
            /*
            Console.WriteLine(@"     /\_\_\_\_\_\");      ==>      /\ * (o indice que ele vai ficar no cubo) + _\ * proporção do cubo
            Console.WriteLine(@"    /\/\_\_\_\_\_\");     ==>   a cada indice ele recebe /\
            Console.WriteLine(@"   /\/\/\_\_\_\_\_\");    ==>   /\/\/\ e a proporção é sempre a mesma no lado b por motivos obvios
            Console.WriteLine(@"  /\/\/\/\_\_\_\_\_\");   ==> eu tenho q me preocupar com a lógica de criar a parte A, a parte B apenas concatena na parte A.
            Console.WriteLine(@" /\/\/\/\/\_\_\_\_\_\");
            Console.WriteLine(@"/\/\/\/\/\/\_\_\_\_\_\");
            Console.WriteLine(@"\/\/\/\/\/\/_/_/_/_/_/");
            Console.WriteLine(@" \/\/\/\/\/_/_/_/_/_/");
            Console.WriteLine(@"  \/\/\/\/_/_/_/_/_/");
            Console.WriteLine(@"   \/\/\/_/_/_/_/_/");
            Console.WriteLine(@"    \/\/_/_/_/_/_/");
            Console.WriteLine(@"     \/_/_/_/_/_/");

            for (int i = 0; i < 1; i++) 
            {
                Console.WriteLine(space+ladoACima+ladoBCima+ladoBCima);
                Console.WriteLine(ladoACima+ladoACima+ladoBCima+ladoBCima);
                Console.WriteLine(ladoABaixo+ ladoABaixo+ladoBBaixo+ ladoBBaixo);
                Console.WriteLine(space+ladoABaixo+ladoBBaixo+ ladoBBaixo);
            }
            for (int i = 0; i < 1; i++) 
            {
                Console.WriteLine( "  "+ladoACima+ladoBCima + ladoBCima);
                Console.WriteLine( space+ladoACima+ ladoACima+ladoBCima + ladoBCima);
                Console.WriteLine(ladoACima+ladoACima+ ladoACima+ladoBCima + ladoBCima);
                Console.WriteLine(ladoABaixo+ ladoABaixo+ ladoABaixo + ladoBBaixo + ladoBBaixo);
                Console.WriteLine(space+ladoABaixo+ ladoABaixo+ladoBBaixo + ladoBBaixo);
                Console.WriteLine("  " + ladoABaixo+ladoBBaixo + ladoBBaixo);
            }
           */

            Console.Write("Escreva o valor n: ");
            int n = int.Parse(Console.ReadLine());

            if(n > 29) 
            {
                n = 29;
            }

            Console.Clear();
            string[] cubo = new string[n * 2 ];
            if(n < 30)
            {
                if (n > 1)
                {
                    while (space.Length < n - 1)
                    {
                        space += " ";
                    }
                }
                ContruirLadoACima(cubo, n, space, ladoACima, ladoACimaDefault);
                ConstruirLadoBCima(cubo,n,space,ladoBCima,ladoBCimaDefault);
                ConstruirLadoABaixo(cubo,n,space,ladoABaixo,ladoABaixoDefault);
                ConstruirLadoBBaixo(cubo,n,space,ladoBBaixo,ladoBBaixoDefault);
            }

            foreach (string item in cubo)
            {
                Console.WriteLine(item);
            }



            Console.ReadKey();
        }

        public static void ContruirLadoACima(string[] cubo, int n, string space, string ladoACima, string ladoACimaDefault)
        {
            for (int j = 0; j < n; j++)
            {
                if (j == 0)
                {
                    cubo[j] = space + ladoACima;
                    ladoACima += ladoACimaDefault;
                }
                else
                {
                    if (space != string.Empty)
                    { 
                        space  = default(string);
                        space = "";
                        while(space.Length < n - j - 1)
                        {
                            space += " ";
                        }
                    }

                    cubo[j] += space + ladoACima;
                    ladoACima += ladoACimaDefault;
                }
            }
        }

        public static void ConstruirLadoBCima(string[] cubo, int n, string space, string ladoBCima, string ladoBCimaDefault)
        {
            for (int j = 0; j < n; j++)
            {

                while (ladoBCima.Length != n * 2)
                {
                    ladoBCima += ladoBCimaDefault;
                }
                cubo[j] += ladoBCima;
            }
        }

        public static void ConstruirLadoABaixo(string[] cubo, int n, string space, string ladoABaixo, string ladoABaixoDefault)
        {
            for (int j = n * 2 - 1; j > n * 2 / 2 - 1; j--)
            {
                if (j == n * 2 - 1)
                {
                    cubo[j] = space + ladoABaixo;
                    ladoABaixo += ladoABaixoDefault;
                }
                else
                {
                    if (space != string.Empty)
                    {
                        int cont = space.Length;
                        space = default(string);
                        space = "";
                        while (space.Length < cont - 1)
                        {
                            space += " ";
                        }
                    }

                    cubo[j] += space + ladoABaixo;
                    ladoABaixo += ladoABaixoDefault;
                }
            }
        }
        public static void ConstruirLadoBBaixo(string[] cubo, int n, string space, string ladoBBaixo, string ladoBBaixoDefault)
        {
            for (int j = n * 2 - 1; j > n * 2 / 2 - 1; j--)
            {
                while (ladoBBaixo.Length != n * 2)
                {
                    ladoBBaixo += ladoBBaixoDefault;
                }
                cubo[j] += ladoBBaixo;
            }
        }
    }
}