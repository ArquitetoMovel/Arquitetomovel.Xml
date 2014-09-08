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
            var proj = new ProjectTest();
            var path = @"X:\Source\Arquitetomovel.Xml\Arquitetomovel.Xml.Test\Arquitetomovel.Xml.Test.csproj";
            var data = proj.Deserialize(path);

            data.Serialize(path);

        }
    }
}
