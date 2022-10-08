using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;
//define an array of Viper pilot call signs

string[] callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };
void WorkWithText()
{
    StreamWriter text = null;

    try
    {
    //define a file to write to
    string textFile = Combine(CurrentDirectory, "streams.txt");
    //create a text file and return a helper writer
    text = File.CreateText(textFile);
    //enumerate the strings, writing each one to the stream on a separate line
    foreach (string item in callsigns)
    {
        text.WriteLine(item);
    }
    text.Close();//release resources

    //output the contents of the file
    WriteLine($"{textFile} contains {textFile.Length:N0} bytes.");
    WriteLine(File.ReadAllText(textFile));
    }
    catch (Exception ex)
    {
        WriteLine($"{ex.GetType} says {ex.Message}");
    }
    finally
    {
        if (text != null)
        {
            text.Dispose();
            WriteLine("The stream writer's unmanaged resources have been disposed.");
        }
    }

}
WorkWithText();
void WorkWithXml()
{
    FileStream xmlFileStream = null;
    XmlWriter xml = null;
    try
    {

        //define a file to write to
        string xmlFile = Combine(CurrentDirectory, "streams.xml");

        //create a file stream
        xmlFileStream = File.Create(xmlFile);

        //wrap the file stream in an xml writer helper and automatically indent nested elements
        xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

        //write the XML declaratoin
        xml.WriteStartDocument();

        //write a root element
        xml.WriteStartElement("callsigns");

        //enumerate the strings writing each one to the stream
        foreach (string item in callsigns)
        {
            xml.WriteElementString("callsign", item);
        }

        //Write the close root element
        xml.WriteEndElement();

        //close helper and stream
        xml.Close();
        xmlFileStream.Close();

        //output all the contents of the file
        WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length:N0} bytes.");

        WriteLine(File.ReadAllText(xmlFile));
    }
    catch (Exception ex)
    {
        //if the path doesn't exist the exception will be caught
        WriteLine($"{ex.GetType()} says {ex.Message}");
    }
    finally
    {
        if (xml != null)
        {
            xml.Dispose();
            WriteLine("The XML writer's unmanaged resources have been disposed.");
        }
        if (xmlFileStream != null)
        {
            xmlFileStream.Dispose();
            WriteLine("The file stream's unmanaged resources have been disposed.");
        }
    }
}
WorkWithXml();
void WorkWithCompression(bool useBrotli = true)
{
    string fileExt = useBrotli ? "brotli" : "gzip";

    //compress the XML output
    string FilePath = Combine(CurrentDirectory, $"streams.{fileExt}");
    FileStream file = File.Create(FilePath);
    Stream compressor;
    if (useBrotli)
    {
        compressor = new BrotliStream(file, CompressionMode.Compress);
    }
    else
    {
        compressor = new GZipStream(file, CompressionMode.Compress);
    }
    using (compressor)
    {
        using (XmlWriter xml = XmlWriter.Create(compressor))
        {
            xml.WriteStartDocument();
            xml.WriteStartElement("callsigns");
            foreach (string item in callsigns)
            {
                xml.WriteElementString("callsign", item);
            }

        }
    }
    //output all the contens of the compressed file
    WriteLine($"{FilePath} contains {new FileInfo(FilePath).Length:N0} bytes.");
    WriteLine($"The compressed contents:");
    WriteLine(File.ReadAllText(FilePath));

    //read a compressed file
    WriteLine("Reading the compressed XML file:");
    file = File.Open(FilePath, FileMode.Open);
    Stream decompressor;
    if (useBrotli)
    {
        decompressor = new BrotliStream(file, CompressionMode.Decompress);
    }
    else
    {
        decompressor = new GZipStream(file, CompressionMode.Decompress);
    }

    using (decompressor)
    {
        using (XmlReader reader = XmlReader.Create(decompressor))
        {
            while (reader.Read()) //read the next XML node
            {
                //check if we are on an element node named callsign
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                {
                    reader.Read();//move to the next inside element
                    WriteLine($"{reader.Value}"); //read its value
                }                
            }
        }
    }
}
WorkWithCompression();
WorkWithCompression(useBrotli: false);
