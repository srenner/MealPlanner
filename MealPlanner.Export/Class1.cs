using System;
using System.Xml;

namespace MealPlanner.Export
{
    public class Class1
    {

        public static void Test1()
        {
            XmlDocument doc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlDocumentType xmlDoctype = doc.CreateDocumentType("en-export", null, "http://xml.evernote.com/pub/evernote-export2.dtd", null);

            doc.InsertAfter(xmlDoctype, xmlDeclaration);

            XmlElement enExportNode = doc.CreateElement("en-export");
            enExportNode.SetAttribute("export-date", DateTime.Now.ToString());
            enExportNode.SetAttribute("application", "Evernote/MealPlanner");
            enExportNode.SetAttribute("version", "6.x");



            doc.AppendChild(enExportNode);

            XmlElement noteNode = doc.CreateElement("note");
            enExportNode.AppendChild(noteNode);


            XmlElement titleNode = doc.CreateElement("title");
            titleNode.InnerText = "This is the note title";
            noteNode.AppendChild(titleNode);

            //content
            XmlElement contentNode = doc.CreateElement("content");
            noteNode.AppendChild(contentNode);

            XmlCDataSection cdata = doc.CreateCDataSection("this is the actual content of the note");
            contentNode.AppendChild(cdata);
            
            XmlElement createdNode = doc.CreateElement("created");
            createdNode.InnerText = DateTime.Now.ToString();
            noteNode.AppendChild(createdNode);
            
            XmlElement updatedNode = doc.CreateElement("updated");
            updatedNode.InnerText = DateTime.Now.ToString();
            noteNode.AppendChild(updatedNode);

            doc.Save("testdoc.xml");

        }

        private static string GenerateNoteContent(string[] checklistItems)
        {
            throw new NotImplementedException();
        }
    }
}
