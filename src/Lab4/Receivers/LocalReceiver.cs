using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Receivers;

public class LocalReceiver : IReceiver
{
    public int DepthLimit { get; private set; }
    public char FolderChar { get; } = 'F';
    public char FileChar { get; } = 'f';
    public char ShiftChar { get; } = ' ';
    public string ListTree(string path, int depth)
    {
        DepthLimit = depth;
        return FolderTraversal(string.Empty, 0, path);
    }

    public string ShowFile(string path)
    {
        return File.ReadAllText(path);
    }

    public void CopyFile(string source, string dest)
    {
        File.Copy(source, dest);
    }

    public void MoveFile(string source, string dest)
    {
        File.Move(source, dest);
    }

    public void RenameFile(string source, string newName)
    {
        string directory = Path.GetDirectoryName(source) ?? string.Empty;
        string dest = Path.Combine(directory, newName);
        MoveFile(source, dest);
    }

    public void DeleteFile(string source)
    {
        File.Delete(source);
    }

    private string FolderTraversal(string message, int depth, string path)
    {
        if (depth > DepthLimit) return string.Empty;

        foreach (string file in Directory.GetFiles(path))
        {
            message += $"{(ShiftChar, depth)} {FileChar} {file}\n";
        }

        foreach (string directory in Directory.GetDirectories(path))
        {
            message += $"{(ShiftChar, depth)} {FolderChar} {directory}\n";
            FolderTraversal(message, depth + 1, Path.Combine(path, directory));
        }

        return message;
    }
}