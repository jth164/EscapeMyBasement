using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TagSelector;

[System.Serializable]
public class ObjectToShow
{
    [TagSelector]
    public string triggerObjectName;
    public GameObject objectToShow;
}

public class BuildTable : MonoBehaviour
{
    public List<ObjectToShow> objectsToShow;
    public GameObject winScreen;
    public AudioSource audioSource;
    void Start()
    {   
        foreach (var item in objectsToShow)
        {
            if (item.objectToShow != null)
            {
                item.objectToShow.SetActive(false);
            }
        }
        StartCoroutine(CheckWinCondition());
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (var item in objectsToShow)
        {
            if (collision.gameObject.CompareTag(item.triggerObjectName))
            {
                if (item.objectToShow != null)
                {
                    item.objectToShow.SetActive(true);
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    IEnumerator CheckWinCondition()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (AllObjectsActive())
            {
                winScreen.SetActive(true);
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length);
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    bool AllObjectsActive()
    {
        foreach (var item in objectsToShow)
        {
            if (item.objectToShow != null && !item.objectToShow.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
