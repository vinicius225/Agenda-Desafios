
using System.Text;

StringBuilder sb = new StringBuilder();

using (var sha2 = System.Security.Cryptography.SHA256.Create())
{
    Encoding encoding = Encoding.UTF8;
    Byte[] bytes = sha2.ComputeHash(encoding.GetBytes("admin"));

    foreach (var item in bytes)
    {
        sb.Append(item.ToString("x2"));
    }
}
Console.WriteLine( sb.ToString());
Console.WriteLine( sb.ToString());