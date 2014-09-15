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
    public abstract class XmlDocParser : IDisposable
    {
        private static XmlDocument XmlDoc { get; set; }

        //public XmlDoc2Object(string xmlFilePath) { }

        public void ParseToXml(string xmlFilePath)
        {
            var _realObj = this;
            XmlDoc = ReadXml(xmlFilePath);


            XmlDoc.Save(xmlFilePath);
        }

        public XmlDocParser ParseToObj(string xmlFilePath)
        {
            var _realObj = this;
            XmlDoc = ReadXml(xmlFilePath);
            var _propertiesObj = _realObj.GetType().GetProperties();

            foreach (var property in _propertiesObj) {
                var xmlElement = XmlDoc.GetElementsByTagName(property.Name);
                if(xmlElement.Count > 1 && property.PropertyType.Equals("List"))
                {

                }
                else
                {
                    property.SetValue(_realObj, xmlElement.Item(0).InnerText);
                }
 
            }
           
            return _realObj;
        }

        private static XmlDocument ReadXml(string xmlFilePath)
        {
            var _xmlDoc = new XmlDocument();
            var srFile = new StreamReader(xmlFilePath, UTF8Encoding.UTF8);
            _xmlDoc.Load(srFile);
            srFile.Close();
            srFile.Dispose();
            srFile = null;
            return _xmlDoc;
        }

        public async Task<XmlDocParser> ParseToObjAsync(string xmlFilePath)
        {
            return
            await
            Task.Run<XmlDocParser>(() =>
                { return ParseToObj(xmlFilePath); }
            );
        }

        public void Dispose()
        {
            XmlDoc = null;
        }
    }
}
