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
    internal class XmlSerialParser
    {

        public static Object Deserialize(string XmlOfAnObject, Type ObjectType)
        {
            var StrReader = new StringReader(XmlOfAnObject);
            var serializer = new XmlSerializer(ObjectType);
            var XmlReader = new XmlTextReader(StrReader);
            try
            {
                Object AnObject = serializer.Deserialize(XmlReader);
                return AnObject;
            }
            catch (Exception exp)
            {
                //Handle Exception Code
                throw exp;
            }
            finally
            {
            
                serializer = null;
            }
        }

        public static string Serialilze(object realObject)
        {
            var serializer = new XmlSerializer(realObject.GetType());
            var sw = new StringWriter();
            var tw = new XmlTextWriter(sw);
            try
            {
                
                serializer.Serialize(tw, realObject);
                return sw.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
                tw.Close();
                serializer = null;
            }
        }
    }
}
