using telegram_zip;

class Project
{
    static async Task Main(string[] args)
    {
        string botToken = "6957132336:AAHiJrjgS2814kdUjHwjw4jDa-D24dIuYrs";
        Bothandler botH = new Bothandler(botToken);
        try
        {
            await botH.Bothandle();
        }
        catch
        {
            await botH.Bothandle();
        }
    }
}