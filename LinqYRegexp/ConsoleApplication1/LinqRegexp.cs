using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*
 * En C# Linq, la creación/definición de consultas está separada de la ejecución de las mismas.
 * Primero, se definen las consultas y después se ejecutan haciendo uso de un foreach. Además,
 * se pueden usar expresiones regulares en las mismas consultas. Las expresiones regulares se
 * pueden usar gracias a la clase "Regexp", que se encuentra dentro del espacio de nombre
 * "System.Text.RegularExpressions". Para poder usar consultas Linq, debemos usar el espacio
 * de nombre "System.Linq".
*/

namespace ConsoleApplication1
{
    class LinqRegexp
    {
        static void Main(string[] args)
        {
            string[] cadenas = {"Pepe","Pepeon","Juan",
                               "María","Pepito","José",
                                 "Alfredo","Sebastián",
                              "Eliseo","Luis","Rafael" };

            int[] ristraNumeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Regex expReg1 = new Regex("[a-c]");
            Regex expReg2 = new Regex("^P.*$");

            //===================================================
            //===================================================
            //Definición de consultas:

            //Saca nombres que contengan una letra del intervalo de "a" a "c".
            var nombreConsulta1 =
                from nombre in cadenas
                where expReg1.IsMatch(nombre)
                select nombre;

            //Saca nombre que empiecen por P, les siga cualquier letra 0 o infinitas veces, y acaben.
            var nombreConsulta2 =
                from nombre in cadenas
                where expReg2.IsMatch(nombre)
                select nombre;

            //Saca impares.
            var numConsulta =
                from numero in ristraNumeros
                where (numero % 2 != 0)
                select numero;
          
            //===================================================
            //===================================================
            //Ejecución de consultas:

            Console.WriteLine("Números:");
            
            foreach (var tmp in numConsulta)
                Console.Write(tmp + ", ");
            

            Console.WriteLine("\n");
            Console.WriteLine("Nombres:");

            foreach (var tmp in nombreConsulta1)
            {
                Console.Write(tmp + ", ");
            }

            Console.WriteLine("\n");

            foreach (var tmp in nombreConsulta2)
            {
                Console.Write(tmp + ", ");
            }

            Console.ReadLine();
        }
    }
}
