using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_14
{
    using System;

    class Program
    {
        const int MaxEncuestas = 1000;
        static int[] edades = new int[MaxEncuestas];
        static char[] vacunado = new char[MaxEncuestas];
        static int contador = 0;

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("Encuesta Covid-19");
                Console.WriteLine("================================");
                Console.WriteLine("1: Realizar Encuesta");
                Console.WriteLine("2: Mostrar Datos de la encuesta");
                Console.WriteLine("3: Mostrar Resultados");
                Console.WriteLine("4: Buscar Personas por edad");
                Console.WriteLine("5: Salir");
                Console.WriteLine("================================");
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RealizarEncuesta();
                        break;
                    case 2:
                        MostrarDatosEncuesta();
                        break;
                    case 3:
                        MostrarResultados();
                        break;
                    case 4:
                        BuscarPorEdad();
                        break;
                    case 5:
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

            } while (opcion != 5);
        }

        static void RealizarEncuesta()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Encuesta de vacunación");
            Console.WriteLine("===================================");
            Console.Write("¿Qué edad tienes?: ");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Te has vacunado");
            Console.WriteLine("1: Sí  2: No");
            Console.Write("Ingrese una opción: ");
            char respuesta = Console.ReadKey().KeyChar;
            Console.WriteLine();

            edades[contador] = edad;
            vacunado[contador] = (respuesta == '1') ? 'S' : 'N';
            contador++;

            Console.WriteLine("===================================");
            Console.WriteLine("¡Gracias por participar!");
            Console.WriteLine("===================================");
            Console.Write("Presione una tecla ...");
            Console.ReadKey();
        }

        static void MostrarDatosEncuesta()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Datos de la encuesta");
            Console.WriteLine("===================================");
            Console.WriteLine("ID | Edad | Vacunado");
            Console.WriteLine("=======================");

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i:D4} | {edades[i]:D2} | {(vacunado[i] == 'S' ? "Si" : "No")}");
            }

            Console.WriteLine("===================================");
            Console.Write("Presione una tecla ...");
            Console.ReadKey();
        }

        static void MostrarResultados()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Resultados de la encuesta");
            Console.WriteLine("===================================");

            int totalVacunados = 0;
            int totalNoVacunados = 0;
            int[] rangosEdad = new int[6];

            for (int i = 0; i < contador; i++)
            {
                if (vacunado[i] == 'S')
                    totalVacunados++;
                else
                    totalNoVacunados++;

                if (edades[i] >= 1 && edades[i] <= 20)
                    rangosEdad[0]++;
                else if (edades[i] >= 21 && edades[i] <= 30)
                    rangosEdad[1]++;
                else if (edades[i] >= 31 && edades[i] <= 40)
                    rangosEdad[2]++;
                else if (edades[i] >= 41 && edades[i] <= 50)
                    rangosEdad[3]++;
                else if (edades[i] >= 51 && edades[i] <= 60)
                    rangosEdad[4]++;
                else
                    rangosEdad[5]++;
            }

            Console.WriteLine($"{totalVacunados:D2} personas se han vacunado");
            Console.WriteLine($"{totalNoVacunados:D2} personas no se han vacunado");

            Console.WriteLine($"Existen:{rangosEdad[0]:D2} personas entre 01 y 20 años");
            Console.WriteLine($"Existen:{rangosEdad[1]:D2} personas entre 21 y 30 años");
            Console.WriteLine($"Existen:{rangosEdad[2]:D2} personas entre 31 y 40 años");
            Console.WriteLine($"Existen:{rangosEdad[3]:D2} personas entre 41 y 50 años");
            Console.WriteLine($"Existen:{rangosEdad[4]:D2} personas entre 51 y 60 años");
            Console.WriteLine($"Existen:{rangosEdad[5]:D2} personas de más de 61 años");

            Console.WriteLine("===================================");
            Console.Write("Presione una tecla ...");
            Console.ReadKey();
        }

        static void BuscarPorEdad()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Buscar a personas por edad");
            Console.WriteLine("================================");
            Console.Write("¿Qué edad quieres buscar?: ");
            int edadBuscada = int.Parse(Console.ReadLine());

            int vacunados = 0;
            int noVacunados = 0;

            for (int i = 0; i < contador; i++)
            {
                if (edades[i] == edadBuscada)
                {
                    if (vacunado[i] == 'S')
                        vacunados++;
                    else
                        noVacunados++;
                }
            }

            Console.WriteLine($"{vacunados:D2} se vacunaron");
            Console.WriteLine($"{noVacunados:D2} no se vacunaron");

            Console.WriteLine("================================");
            Console.Write("Presione una tecla ...");
            Console.ReadKey();
        }
    }

}
