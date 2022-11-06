using System;
using System.Text;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var sb = new StringBuilder();
        if( id.HasValue ) {
            sb.AppendFormat("[{0}] - ",id.Value);
        }
        sb.AppendFormat("{0} - ",name);
        sb.Append((department ?? "OWNER").ToUpper());
        return sb.ToString();
    }
}
