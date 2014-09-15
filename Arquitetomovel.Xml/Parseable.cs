using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Arquitetomovel.Xml
{
    [Serializable]
    public abstract class Parseable<T>
    {
        public T LoadObject(string xmlFilePath)
        {
            var srXmlFile = new StreamReader(xmlFilePath, UTF8Encoding.UTF8);
            var serializer = new XmlSerializer(typeof(T));
            try
            {
                T realObject = (T)serializer.Deserialize(srXmlFile);
                return realObject;
            }
            catch (Exception exp)
            {
                //Handle Exception Code
                throw exp;
            }
            finally
            {
                srXmlFile.Close();
                srXmlFile = null;
                serializer = null;
            }
        }
    }
}
