using System;
using System.IO;
using System.Xml.Serialization;
using Ex4.Model;

namespace Ex4.Service
{
    public class FileService
    {
        private const string DefaultFile = "../../sayings.xml";

        public void Save(SayingsModel sayings, string fileName = DefaultFile)
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(SayingsModel));
                Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, sayings);
                fStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public SayingsModel Load(string fileName = DefaultFile)
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(SayingsModel));
                Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                SayingsModel questions = (SayingsModel) xmlFormat.Deserialize(fStream);
                fStream.Close();
                return questions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public SayingsModel InitSayings()
        {
            SayingsModel sayingsModel = new SayingsModel();
            for (int i = 0; i < firstParts.Length; i++)
            {
                sayingsModel.AddItem(firstParts[i], lastParts[i]);
            }

            Save(sayingsModel);
            return sayingsModel;
        }

        private static string[] firstParts =
        {
            "Не плюй в колодец",
            "Под лежачий камень",
            "Ласточка весну начинает",
            "Что летом родится"
        };

        private static string[] lastParts =
        {
            "пригодится воды напиться",
            "и вода не течет",
            "соловей кончает",
            "то зимой пригодится"
        };
    }
}