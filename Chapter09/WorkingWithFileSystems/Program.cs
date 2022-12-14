using static System.Console;
using static System.IO.Directory;
using static System.Environment;
using static System.IO.Path;
using System.IO;

//methods
static void OutputFileSystemInfo()
{
    WriteLine("{0, -33}   {1}", "Path.PathSeparator", PathSeparator);
    WriteLine("{0, -33}   {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);
    WriteLine("{0, -33}   {1}", "Directory.GetCurrentDirectory()", GetCurrentDirectory());
    WriteLine("{0, -33}   {1}", "Environment.CurrentDirectory", CurrentDirectory);
    WriteLine("{0, -33}   {1}", "Environment.SystemDirectory", SystemDirectory);
    WriteLine("{0, -33}   {1}", "Path.GetTempPath()", GetTempPath());

    

    WriteLine("GetFolderPath(SpecialFolder)");
    WriteLine("{0, -33}   {1}", ".System", GetFolderPath(SpecialFolder.System));
    WriteLine("{0, -33}   {1}", ".ApplicationData", GetFolderPath(SpecialFolder.ApplicationData));
    WriteLine("{0, -33}   {1}", ".MyDoctuments", GetFolderPath(SpecialFolder.MyDocuments));
    WriteLine("{0, -33}   {1}", ".Personal", GetFolderPath(SpecialFolder.Personal));
}
static void WorkWithDrives()
{
    WriteLine("{0, -30} | {1, -10} | {2, -7} | {3, 18} | {4, 18}", "NAME","TYPE","FORMAT","SIZE(BYTES)","FREE SPACE");
    foreach(DriveInfo drive in DriveInfo.GetDrives())
    {
        WriteLine("{0, -30} | {1, -10} | {2, -7} | {3,18:N0} | {4,18:N0}", drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
    }
}
static void WorkWithDirectories()
{
    //define a directory path for a new folder
    //starting in the user's folder
    var newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09","NewFolder");
    WriteLine($"Working with: {newFolder}");
    //check if it exists
    WriteLine($"Does it exist? {Exists(newFolder)}");
    //create directory
    WriteLine("Creating it...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist? {Exists(newFolder)}");
    Write("Confirm that the directory exists, and then press Enter: ");
    ReadLine();
    //delete directory
    WriteLine("Deleting it...");
    Delete(newFolder, recursive: true);
    WriteLine($"Does it exist? {Exists(newFolder)}");
}
static void WorkWithFiles()
{
    //define a directory path to output files
    //starting in the user's folder
    var dir = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09","OutputFiles");
    CreateDirectory(dir);
    //define file paths
    string textFile = Combine(dir, "Dummy.txt");
    string backupFile = Combine(dir, "Dummy.bak");
    WriteLine($"Working with : {textFile}");
    //check if file exists
    WriteLine($"Does it exist? {File.Exists(textFile)}");
    //create a new text file and write a line to it
    StreamWriter textWriter = File.CreateText(textFile);
    textWriter.WriteLine("Hello, C#!");
    textWriter.Close(); // close file and release sources
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    //copy the file and overwrite if it already exists
    File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
    WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
    Write("Confirm the file exists, and then press ENTER: ");
    ReadLine();

    //delete file
    WriteLine("Deleting it...");
    File.Delete(textFile);
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    //read from the text file backup
    WriteLine($"Reading contents of {backupFile}:");
    StreamReader textReader = File.OpenText(backupFile);
    WriteLine(textReader.ReadToEnd());
    textReader.Close();

    //Managing paths
    WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
    WriteLine($"File Name: {GetFileName(textFile)}");
    WriteLine($"File Name without extension: {GetFileNameWithoutExtension(textFile)}");
    WriteLine($"File extension: {GetExtension(textFile)}");
    WriteLine($"Random File Name: {GetRandomFileName()}");
    WriteLine($"Temporary File Name: {GetTempFileName()}");

    var info = new FileInfo(backupFile);
    WriteLine($"{backupFile}:");
    WriteLine($"Contains {info.Length} bytes");
    WriteLine($"Last accessed {info.LastAccessTime}");
    WriteLine($"Has readonly set to {info.IsReadOnly}");

}

//main method
WorkWithDirectories();
WorkWithDrives();
OutputFileSystemInfo();
WorkWithFiles();