using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HT_3_P2
{
    internal class Program
    {

        public static void SaveToXmlFile(List<Book> books)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var writer = new StreamWriter("books.xml"))
            {
                serializer.Serialize(writer, books, null);
                writer.Close();
            }
        }

        public static void Main(string[] args)
        {
            using (XmlWriter writer = XmlWriter.Create("books.xml"))
            {
                // Ghi Processing Instruction (stylesheet)
                String pi = "type='text/xsl' href='book.xsl'";
                writer.WriteProcessingInstruction("xml-stylesheet", pi);

                // Ghi DOCTYPE với ENTITY
                writer.WriteDocType("catalog", null, null, "<!ENTITY h 'hardcover'>");

                // Ghi comment
                writer.WriteComment("This is a book sample XML");

                // Bắt đầu root element <book>
                writer.WriteStartElement("book");

                // Thuộc tính ISBN và yearpublished
                writer.WriteAttributeString("ISBN", "9831123212");
                writer.WriteAttributeString("yearpublished", "2002");

                // <author>
                writer.WriteElementString("author", "Mahesh Chand");

                // <title>
                writer.WriteElementString("title", "Visual C# Programming");

                // <price>
                writer.WriteElementString("price", "44.95");

                // Kết thúc thẻ </book>
                writer.WriteEndElement();

                // Kết thúc document
                writer.WriteEndDocument();

                // Flush dữ liệu ra file
                writer.Flush();
            }

            Console.WriteLine("books.xml da duoc tao thanh cong!");
        }
    }
}
