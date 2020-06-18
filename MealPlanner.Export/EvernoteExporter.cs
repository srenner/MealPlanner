﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace MealPlanner.Export
{
    public class EvernoteExporter : IExport
    {
        public Stream CreateExportedNote(DateTime date, string title, string[] checklist)
        {
            throw new NotImplementedException();
        }

        private static string CreateInnerNoteContents(string[] checklist)
        {


            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlDocumentType xmlDoctype = doc.CreateDocumentType("en-note", null, "http://xml.evernote.com/pub/enml2.dtd", null);
            doc.InsertAfter(xmlDoctype, xmlDeclaration);

            XmlElement noteNode = doc.CreateElement("en-note");
            doc.AppendChild(noteNode);

            foreach(var item in checklist)
            {
                XmlElement divNode = doc.CreateElement("div");
                divNode.InnerText = item;

                XmlElement todoNode = doc.CreateElement("en-todo");
                todoNode.SetAttribute("checked", "false");
                
                divNode.AppendChild(todoNode);


                noteNode.AppendChild(divNode);
            }

            return doc.InnerXml;
        }


        public static void CreateAndSaveNote(DateTime datetime, string title, string[] checklist)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlDocumentType xmlDoctype = doc.CreateDocumentType("en-export", null, "http://xml.evernote.com/pub/evernote-export2.dtd", null);

            doc.InsertAfter(xmlDoctype, xmlDeclaration);

            XmlElement enExportNode = doc.CreateElement("en-export");
            enExportNode.SetAttribute("export-date", datetime.ToString());
            enExportNode.SetAttribute("application", "Evernote/MealPlanner");
            enExportNode.SetAttribute("version", "6.x");

            doc.AppendChild(enExportNode);

            XmlElement noteNode = doc.CreateElement("note");
            enExportNode.AppendChild(noteNode);

            XmlElement titleNode = doc.CreateElement("title");
            titleNode.InnerText = title;
            noteNode.AppendChild(titleNode);

            XmlElement contentNode = doc.CreateElement("content");
            noteNode.AppendChild(contentNode);

            string innerNoteContents = CreateInnerNoteContents(checklist);
            //string innerNoteContents = "hello";

            XmlCDataSection cdata = doc.CreateCDataSection(innerNoteContents);
            contentNode.AppendChild(cdata);

            XmlElement createdNode = doc.CreateElement("created");
            createdNode.InnerText = datetime.ToString();
            noteNode.AppendChild(createdNode);

            XmlElement updatedNode = doc.CreateElement("updated");
            updatedNode.InnerText = datetime.ToString();
            noteNode.AppendChild(updatedNode);

            doc.Save("testdoc.xml");
        }
    }
}