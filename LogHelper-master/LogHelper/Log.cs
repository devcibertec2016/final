using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogHelper
{
    public class Log
    {
        public static string WriteFooter()
        {
            //retorno
            return string.Format("Este aplicativo fue desarrollado por los integrantes:{0},{1},{2}", "Jorge Araujo", "Luis Cano", "Fernando Huamani");
        }
    }
}
