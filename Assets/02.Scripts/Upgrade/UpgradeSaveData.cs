[System.Serializable] // json 을 사용하려면 꼭 필요함
public class UpgradeSaveData
{
    public string[] Name;
    public int[] Level;

    public UpgradeSaveData(int count)
    {
        Name = new string[count];
        Level = new int[count];
    }
}