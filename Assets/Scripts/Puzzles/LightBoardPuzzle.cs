using UnityEngine;

[System.Serializable]
public class Pattern
{
    public int[] colors;
}

public class LightBoardPuzzle : MonoBehaviour
{
    public Light[] lights;
    public readonly Color[] colors = { Color.red, Color.green };
    // patern [T1,T2,T3,T4,B4,B3,B2,B1]
    public readonly Pattern[] patterns = {
        new Pattern { colors = new int[] { 1, 0, 0, 0, 1, 1, 1, 0 } },
        new Pattern { colors = new int[] { 1, 1, 1, 1, 0, 0, 0, 0 } },
        new Pattern { colors = new int[] { 1, 0, 1, 0, 0, 1, 1, 0 } },
        new Pattern { colors = new int[] { 0, 1, 0, 0, 0, 1, 0, 1 } }
    };
    private int currentPattern = 0;

    void Start()
    {
        currentPattern = 0;
        ChangePattern();
    }

    public void OnButtonPressed(int buttonValue)
    {
        if (buttonValue == 0)
        {
            currentPattern = (currentPattern + 1) % patterns.Length;
            ChangePattern();
        }
    }

    private void ChangePattern()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (i < patterns[currentPattern].colors.Length)
            {
                int colorIndex = patterns[currentPattern].colors[i];
                lights[i].color = colors[colorIndex];
            }
        }
    }
}
