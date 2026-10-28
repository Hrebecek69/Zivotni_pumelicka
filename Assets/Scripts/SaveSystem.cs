using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveNumber(int number)
    {
        PlayerPrefs.SetInt("SavedNumber", number);
        PlayerPrefs.Save();
    }

    public static int LoadNumber()
    {
        return PlayerPrefs.GetInt("SavedNumber", 0);
    }
}
