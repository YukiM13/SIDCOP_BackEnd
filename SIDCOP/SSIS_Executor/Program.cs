using System;
using System.Diagnostics;

namespace SSIS_Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Si no pasan argumentos, mostramos cómo usarlo
            if (args.Length == 0)
            {
                Console.WriteLine("Uso: SSIS_Executor.exe <RutaDelPaquete.dtsx>");
                return;
            }

            // El primer argumento será la ruta del paquete
            string dtsxPath = args[0];

            // Si quieres, puedes permitir un segundo argumento para la contraseña
            string password = "admin123";

            string arguments = $"/F \"{dtsxPath}\" /De \"{password}\"";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "dtexec.exe",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process proc = Process.Start(psi))
            {
                string output = proc.StandardOutput.ReadToEnd();
                string error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();

                Console.WriteLine("Salida:");
                Console.WriteLine(output);
                Console.WriteLine("Errores:");
                Console.WriteLine(error);
            }
        }
    }
}
