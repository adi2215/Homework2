using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadfer : MonoBehaviour
{
    public Animator trans;
    public GameObject errorGame;

    public void BackToMenu() => StartCoroutine(LoadLevelNext(0));
    public void GoToGame() 
    {   
        if (File.Exists(Application.persistentDataPath + "/Data.json"))
        {
            var dataStr = File.ReadAllText(Application.persistentDataPath + "/Data.json");
            var data = JsonUtility.FromJson<DataGame>(dataStr);
            data.checkDie = true;
        }

        StartCoroutine(LoadLevelNext(1));
    }
    public void ExitToGame() => Application.Quit();

    public void ContinueGame()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data.json"))
        {
            errorGame.SetActive(true);
            Invoke(nameof(TurnOffError), 2.5f);
        }

        else
        {
            var dataStr = File.ReadAllText(Application.persistentDataPath + "/Data.json");
            var data = JsonUtility.FromJson<DataGame>(dataStr);
            
            SceneManager.LoadScene(data.sceneID);
        }
    }

    private void TurnOffError() => errorGame.SetActive(false);

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadLevelNext(index));
    }

    IEnumerator LoadLevelNext(int levelIndex)
    {
        trans.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
