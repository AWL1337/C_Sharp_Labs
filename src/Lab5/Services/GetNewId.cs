namespace Services;

public static class GetNewId
{
    public static int NewId(IEnumerable<int> ids)
    {
        int id = 0;
        IEnumerable<int> enumerable = ids.ToList();
        while (enumerable.Any(obj => obj == id))
        {
            id++;
        }

        return id;
    }
}