namespace Pronia.UI;

public static class Extensions
{
    public static bool CheckFileType(this IFormFile file, string fileType)
    {
        return file.ContentType.Contains(fileType);
    }
    public static bool CheckFileSizeKb(this IFormFile file, int fileSize)
    {
        return file.Length/ 1024 <= fileSize;
    }
    public static string CreateFile(this IFormFile file, string env, params string[] steps)
    {
        string fileName = Guid.NewGuid().ToString() + file.FileName;
        string dbPath = string.Empty;

        foreach (var step in steps)
        {
            dbPath = Path.Combine(dbPath, step);
        }
        dbPath = Path.Combine(dbPath, fileName);

        string filePath = Path.Combine(env, dbPath);
        using(FileStream stream = new(filePath,FileMode.Create))
        {
            file.CopyTo(stream);
        }

        dbPath = "\\" + dbPath;
        return dbPath;
    }
}
