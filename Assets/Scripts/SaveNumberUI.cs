using UnityEngine;
using TMPro;

public class NumberSaveUI : MonoBehaviour
{
    public TMP_InputField numberInput;
    public TMP_Text savedNumberText;

    public void Save()
    {
        if (int.TryParse(numberInput.text, out int number))
        {
            SaveSystem.SaveNumber(number);
            savedNumberText.text = "" + number;
        }
        else
        {
            savedNumberText.text = "Please enter a valid number!";
        }
    }

    public void Load()
    {
        int number = SaveSystem.LoadNumber();

        numberInput.text = number.ToString();
        savedNumberText.text = "" + number;
    }
    private void OnEnable()
    {
        if (numberInput != null && savedNumberText != null)
        {
            Load();
        }
    }
}