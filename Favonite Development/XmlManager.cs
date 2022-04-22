using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Favonite_Development
{
    public class XmlManager<T>
    {
        public Type type { get; private set; }

        public T Load(string path) //takes the content from the xml file and loads it in.
        {
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                
                XmlSerializer xml = new XmlSerializer(type);
                instance = (T)xml.Deserialize(reader);
            }
            return instance;
        }

        public void Save(string path,object obj) //saves content back into a xml file.
        {
            using (TextWriter writrer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(type);
                xml.Serialize(writrer, obj);
            }
        }


    }
}
