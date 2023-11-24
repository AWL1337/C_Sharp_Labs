namespace Itmo.ObjectOrientedProgramming.Lab4.Receivers;

public class NoReceiver : IReceiver
{
    public char FolderChar { get; }
    public char FileChar { get; }
    public char ShiftChar { get; }
    public string ListTree(string path, int depth)
    {
        throw new System.NotImplementedException();
    }

    public string ShowFile(string path)
    {
        throw new System.NotImplementedException();
    }

    public void CopyFile(string source, string dest)
    {
        throw new System.NotImplementedException();
    }

    public void MoveFile(string source, string dest)
    {
        throw new System.NotImplementedException();
    }

    public void RenameFile(string source, string newName)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteFile(string source)
    {
        throw new System.NotImplementedException();
    }
}