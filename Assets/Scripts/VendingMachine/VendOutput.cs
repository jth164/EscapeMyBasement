using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class VendOutput : MonoBehaviour
{
    public TextMeshProUGUI outputText;
    private string enteredCode = "";

    public Dictionary<string, GameObject> codeToItem;

    public Transform spawnLocation;

    public GameObject gpuObject;
    public GameObject mbObject;
    public GameObject caseObject;

    private void Start()
    {
        outputText.text = "";
        outputText.color = Color.white;

        codeToItem = new Dictionary<string, GameObject>
        {
            { "6969", gpuObject },
            { "4078", mbObject },
            { "0375", caseObject }
        };
    }

    public void OnButtonPressed(int buttonNumber)
    {
        if (codeToItem.Count == 0)
            return;

        enteredCode += buttonNumber.ToString();
        outputText.text = enteredCode.PadLeft(4, '*');

        bool isStartOfValidCode = false;
        foreach (string code in codeToItem.Keys)
        {
            if (code.StartsWith(enteredCode))
            {
                isStartOfValidCode = true;
                break;
            }
        }

        outputText.color = isStartOfValidCode ? Color.green : Color.red;

        if (enteredCode.Length == 4)
        {
            if (codeToItem.ContainsKey(enteredCode))
            {
                outputText.text = "Correct Code";
                outputText.color = Color.green;

                GameObject instantiatedObject = Instantiate(codeToItem[enteredCode], spawnLocation.position, spawnLocation.rotation);

                if (instantiatedObject.name == "gpuObject")
                {
                    instantiatedObject.tag = "gGPU";
                }
                else if (instantiatedObject.name == "mbObject")
                {
                    instantiatedObject.tag = "gMB";
                }
                else if (instantiatedObject.name == "caseObject")
                {
                    instantiatedObject.tag = "gCase";
                }

                codeToItem.Remove(enteredCode);
                StartCoroutine(CorrectCode());
            }
            else
            {
                outputText.text = "Wrong code";
                outputText.color = Color.red;
                StartCoroutine(FailedCode());
            }
            enteredCode = "";
        }
        else if (enteredCode.Length > 4)
        {
            outputText.text = "Wrong code";
            outputText.color = Color.red;
            StartCoroutine(FailedCode());
        }
    }

    IEnumerator FailedCode()
    {
        yield return new WaitForSeconds(1);
        outputText.text = "";
        outputText.color = Color.white;
    }
    IEnumerator CorrectCode()
    {
        yield return new WaitForSeconds(1);
        outputText.text = "";
        outputText.color = Color.white;
    }
}
