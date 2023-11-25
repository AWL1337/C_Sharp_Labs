namespace Itmo.ObjectOrientedProgramming.Lab4.Receivers;

public interface IReceiver
{
    public char FolderChar { get; }
    public char FileChar { get; }
    public char ShiftChar { get; }
    public void CopyFile(string source, string dest);
    public void MoveFile(string source, string dest);
    public void RenameFile(string source, string newName);
    public void DeleteFile(string source);
    public string ListTree(string path, int depth);
    public string ShowFile(string path);
}