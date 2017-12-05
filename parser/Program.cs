using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace parser
{
    class Program
    {
        public static List<string> strList = new List<string>();
        private static Dictionary<string, int> dic = new Dictionary<string, int>();

        static void search(string writePath, XmlNode xnode)
        {

            foreach (XmlNode a in xnode.ChildNodes)
            {
                if (a.LastChild == null)
                {
                    strList.Add(String.Format("Founder: {0}", xnode.InnerText + Environment.NewLine));
                }
                else if (a.LastChild != null)
                { 
                    search(writePath, a);
                }
                else if (a.InnerText == "")
                {
                    strList.Add("Founder: null");
                }                    
            }
        }
        static void Writed(string text, string writePath)
        {
                File.AppendAllText(writePath, text, Encoding.UTF8);
        }
        static void WritedLine(string text, string writePath)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
        static void Main(string[] args)
        {
            dic.Add("NAME", 1);
            dic.Add("SHORT_NAME", 2);
            dic.Add("EDRPOU", 3);
            dic.Add("ADDRESS", 4);
            dic.Add("BOSS", 5);
            dic.Add("KVED", 6);
            dic.Add("STAN", 7);
            dic.Add("FOUNDERS", 8);
            dic.Add("FOUNDER", 9);

            string writePath = @"D:\local\4.txt";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\BanCry\Desktop\1.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    int x = dic[childnode.Name];
                    switch (x)
                    {
                        case 1:
                            if (childnode.InnerText != "")
                            {
                                Writed(String.Format("Имя: {0}", childnode.InnerText + " "), writePath);
                            }
                            else
                                Writed("Name: null", writePath);
                            break;
                        case 2:
                            if (childnode.InnerText != "")
                            {
                                Writed(String.Format("SHORT: {0}", childnode.InnerText + " "), writePath);
                            }
                            else
                                Writed("SHORT: null", writePath);
                            break;

                        case 3:
                            if (childnode.InnerText != "")
                            {

                                Writed(String.Format("EDRPOU: {0}", childnode.InnerText + " "), writePath);
                            }
                            else
                                Writed("EDRPOU: null", writePath);
                            break;

                        case 4:
                            if (childnode.InnerText != "")
                            {
                                Writed(String.Format("ADDRESS: {0}", childnode.InnerText + " "), writePath);

                            }
                            else
                                Writed("ADDRESS: null", writePath);
                            break;
                        case 5:
                            if (childnode.InnerText != "")
                            {
                                Writed(String.Format("BOSS: {0}", childnode.InnerText + " "), writePath);
                            }
                            else
                                Writed("BOSS: null", writePath);
                            break;

                        case 6:
                            if (childnode.InnerText != "")
                            {
                                Writed(String.Format("KVED: {0}", childnode.InnerText + " "), writePath);
                            }
                            else
                                Writed("KVED: null", writePath);
                            break;

                        case 7:
                            if (childnode.InnerText != "")
                            {

                                Writed(String.Format("Stan: {0}", childnode.InnerText + " "), writePath);
                            }
                            else
                                Writed("STAN: null", writePath);
                            break;

                        case 8:
                            foreach (XmlNode a in childnode.ChildNodes)
                            {
                                if (a.Name == "FOUNDER" && a.LastChild == null)
                                {
                                    Writed(String.Format("Founder: {0}", childnode.InnerText + Environment.NewLine), writePath);
                                }
                                else if (a.Name == "FOUNDER" && a.LastChild != null)
                                {
                                    search(writePath, a);
                                }
                                for (int i = 0; i < strList.Count; i++)
                                {
                                    Writed(strList[i], writePath);
                                }
                                strList.Clear();
                            }
                            break;

                    }
                    Writed(Environment.NewLine, writePath);

                }
                Writed(Environment.NewLine, writePath);
            }
            Console.ReadKey();
        }
    }
}
