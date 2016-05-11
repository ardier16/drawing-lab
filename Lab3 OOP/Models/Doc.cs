using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab3_OOP
{
    public class Doc
    {
        
        public static void Save(Picture pic, string source)
        {
            XmlDocument doc = new XmlDocument();
            string xml = String.Format("<?xml version='1.0' encoding='utf-8'?> <picture><x>{2}</x><y>{3}</y><h>{0}</h><w>{1}</w>", pic.Width, pic.Height, pic.Point.X, pic.Point.Y);
                      
            for (int i = 0; i < pic.FigureList.Count; i++)
            {
                xml += pic.FigureList[i].ToXml();
            }

            xml += "</picture>";
            doc.LoadXml(xml);
            doc.Save(source);
        }

        public static Picture Load(string source)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(source);

            XmlNode root = doc.DocumentElement;

            Picture pic = new Picture(new Point(int.Parse(root.ChildNodes[0].LastChild.InnerText), int.Parse(root.ChildNodes[1].LastChild.InnerText)), int.Parse(root.ChildNodes[2].LastChild.InnerText), int.Parse((root.ChildNodes[3].LastChild.InnerText)), new List<Figure>());

            for (int i = 4; i < root.ChildNodes.Count; i++)
            {
                switch (root.ChildNodes[i].FirstChild.LastChild.InnerText)
                {
                    case "Circle":
                        pic.AddFigure(new Circle(new Pen(Color.Black), double.Parse(root.ChildNodes[i].ChildNodes[1].LastChild.InnerText),
                            double.Parse(root.ChildNodes[i].ChildNodes[2].LastChild.InnerText), double.Parse(root.ChildNodes[i].ChildNodes[3].LastChild.InnerText)));
                        break;
                    case "Annulus":
                        pic.AddFigure(new Annulus(new Pen(Color.Black), double.Parse(root.ChildNodes[i].ChildNodes[1].LastChild.InnerText),
                            double.Parse(root.ChildNodes[i].ChildNodes[2].LastChild.InnerText), double.Parse(root.ChildNodes[i].ChildNodes[3].LastChild.InnerText),
                            double.Parse(root.ChildNodes[i].ChildNodes[4].LastChild.InnerText)));
                        break;
                    case "FillAnnulus":
                        pic.AddFigure(new FillAnnulus(new Pen(Color.Black), new SolidBrush(Color.Black), double.Parse(root.ChildNodes[i].ChildNodes[1].LastChild.InnerText),
                            double.Parse(root.ChildNodes[i].ChildNodes[2].LastChild.InnerText), double.Parse(root.ChildNodes[i].ChildNodes[3].LastChild.InnerText),
                            double.Parse(root.ChildNodes[i].ChildNodes[4].LastChild.InnerText)));
                        break;
                    case "Cylinder":
                        pic.AddFigure(new Cylinder(new Pen(Color.Black), double.Parse(root.ChildNodes[i].ChildNodes[1].LastChild.InnerText),
                           double.Parse(root.ChildNodes[i].ChildNodes[2].LastChild.InnerText), double.Parse(root.ChildNodes[i].ChildNodes[3].LastChild.InnerText),
                           double.Parse(root.ChildNodes[i].ChildNodes[4].LastChild.InnerText), double.Parse(root.ChildNodes[i].ChildNodes[5].LastChild.InnerText)));
                        break;
                    case "Sphere":
                        pic.AddFigure(new Sphere(new Pen(Color.Black), double.Parse(root.ChildNodes[i].ChildNodes[1].LastChild.InnerText),
                            double.Parse(root.ChildNodes[i].ChildNodes[2].LastChild.InnerText), double.Parse(root.ChildNodes[i].ChildNodes[3].LastChild.InnerText),
                            double.Parse(root.ChildNodes[i].ChildNodes[4].LastChild.InnerText)));
                        break;
                    case "Torus":
                        pic.AddFigure(new Torus(new Pen(Color.Black), new SolidBrush(Color.Blue), double.Parse(root.ChildNodes[i].ChildNodes[1].LastChild.InnerText),
                           double.Parse(root.ChildNodes[i].ChildNodes[2].LastChild.InnerText), double.Parse(root.ChildNodes[i].ChildNodes[3].LastChild.InnerText),
                           double.Parse(root.ChildNodes[i].ChildNodes[4].LastChild.InnerText), double.Parse(root.ChildNodes[i].ChildNodes[5].LastChild.InnerText)));
                        break;       

                    default:
                        break;
                }

            }

            return pic;
        }
    }
}
