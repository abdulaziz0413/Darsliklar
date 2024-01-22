using System.Text;
using System.Text.RegularExpressions;

string path = "D:\\lessonsfile\\myTex.py";
string path2 = "D:\\";
string source = "print(\"Don't sleep, great works are waiting you\")";
File.WriteAllText(path, source);
Console.WriteLine("Ma'lumot yozildi");

/* File.Copy(path, path2);
 Console.WriteLine("Ma'lumot nusxalandi");
 //File.Delete(path*/

/*FileStream fil = new FileStream(path, FileMode.OpenOrCreate);
StreamWriter write = new StreamWriter(fil);
write.WriteLine("salom dunyo");
write.Close();
fil.Close();


FileStream file = new FileStream(path, FileMode.Open);
StreamReader sr = new StreamReader(file);
string line = sr.ReadLine();
Console.WriteLine(line);
*/
using (StreamWriter sw = new StreamWriter(path))
{
    sw.WriteLine(source);
}
IEnumerable<string> files = new List<string>() { "SALOM", "DUNYO" };

File.AppendAllLines(path, files);
string[] vaules = File.ReadAllLines(path);
foreach(string vaule in vaules)
{
    Console.WriteLine(vaule);
}

/*using(StreamReader sr = new StreamReader(path))
{
    Console.WriteLine(sr.ReadToEnd());
}*/
Console.WriteLine("************************");
//DirectoryInfo dr = new DirectoryInfo(path2);
string[] qiymatlar = Directory.GetFiles(path2);
/*foreach(string javoblar  in qiymatlar)
{
    Console.WriteLine(javoblar);    
}*/
/*string[] directory = Directory.GetDirectories(path2);
foreach(string directory2 in directory)
{
    Console.WriteLine(directory2);
}*/
DateTime data = Directory.GetLastAccessTime("D:\\Downloads\\Telegram Desktop\\ConsoleApp_uy_ishi");
Console.WriteLine(data);
DirectoryInfo dri = new DirectoryInfo("D:\\Downloads\\Telegram Desktop\\ConsoleApp_uy_ishi");

Console.WriteLine(dri.CreationTime);
DriveInfo driveInfo = new DriveInfo(path);
Console.WriteLine(driveInfo);
DriveInfo [] driveInfo1 = DriveInfo.GetDrives();
foreach(DriveInfo d in driveInfo1)
{
    Console.WriteLine(d);
}