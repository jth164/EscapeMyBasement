using UnityEngine;
using TMPro;

public class NumberChanger : MonoBehaviour
{
    public TextMeshProUGUI yourText;

    private int currentNumber = 2;

    void Start()
    {
        yourText.text = "1";
    }

    public void OnButtonPressed(int input)
    {
        if (input == 0)
        {
            yourText.text = currentNumber.ToString();
            currentNumber = currentNumber < 4 ? currentNumber + 1 : 1;
        }
    }
}
