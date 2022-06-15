using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{
    public void LoadBattleScene(string SceneName) => SceneManager.LoadScene(SceneName);   
}