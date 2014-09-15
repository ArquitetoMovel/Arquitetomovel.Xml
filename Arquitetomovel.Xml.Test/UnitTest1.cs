using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arquitetomovel.Xml.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var proj = new Project();
            var path = @"X:\Source\Arquitetomovel.Xml\Arquitetomovel.Xml\xmlDocTest.xml";
            var data = proj.LoadObject(path);

            //data.Serialize(path);

        }
    }
}
