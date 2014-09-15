using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetomovel.Xml.Test
{
    public class Project : Arquitetomovel.Xml.Parseable<Project>
    {

       
        public string TargetFrameworkVersion { get; set; }

       
    }
}
