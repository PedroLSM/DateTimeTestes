using System;
using System.Collections.Generic;

namespace DateTimeTestes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime horasTrabalhadasTotal = new DateTime();
            var horasObrigatorias = 100;

            DateTime horasTrabalhadasObrigatoria = new DateTime();
            horasTrabalhadasObrigatoria = horasTrabalhadasObrigatoria.AddHours(horasObrigatorias);
            var horasPorDia = new List<double>()
            {
                8, 10, 10, 8, 8, 8, 8, 8, 8, 8
            };

            foreach (var hora in horasPorDia)
            {
                horasTrabalhadasTotal = horasTrabalhadasTotal.AddHours(hora);
            }
            horasTrabalhadasTotal = horasTrabalhadasTotal.AddMinutes(59);

            var horasDeSaldo = horasTrabalhadasTotal - horasTrabalhadasObrigatoria;

            // -----
            string horas = GetHoras(horasTrabalhadasTotal.Ticks);
            string minutos = GetMinutos(horasTrabalhadasTotal.Ticks);

            Console.Write("Total de Horas Trabalhada: ");
            Console.WriteLine(horas + ":" + minutos);
            // -----
            horas = GetHoras(horasTrabalhadasObrigatoria.Ticks);
            minutos = GetMinutos(horasTrabalhadasObrigatoria.Ticks);

            Console.Write("Horas Obrigratoria: ");
            Console.WriteLine(horas + ":" + minutos);
            // -----
            horas = GetHoras(horasDeSaldo.Ticks);
            minutos = GetMinutos(horasDeSaldo.Ticks);

            Console.Write("Saldo Total de Horas: ");
            Console.WriteLine(horas + ":" + minutos);
            // -----

            Console.ReadKey();
        }

        private static string GetMinutos(long ticks)
        {
            string minutos = "" + Math.Abs(new TimeSpan(ticks).Minutes);
            minutos = minutos.Equals("0") ? "00" : minutos;
            minutos = !minutos.Equals("00") && Convert.ToInt32(minutos) < 10 ? "0" + minutos : minutos;

            return minutos;
        }

        private static string GetHoras(long ticks)
        {
            string horas = "" + (int)new TimeSpan(ticks).TotalHours;
            horas = horas.Equals("0") ? "00" : horas;
            if (!horas.Equals("00") && Math.Abs(Convert.ToInt32(horas)) < 10)
            {
                if (Convert.ToInt32(horas) < 0)
                {
                    horas = "-0" + Math.Abs(Convert.ToInt32(horas));
                }
                else
                {
                    horas = "0" + horas;
                }
            }

            return horas;
        }
    }
}
