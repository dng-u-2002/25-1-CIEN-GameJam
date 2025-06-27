using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowController : MonoBehaviour
{
    [SerializeField] List<string> SceneNames;
    [SerializeField] RectTransform DarkImage;
    string NowSceneName { get { return SceneNames[NowLevel]; } }
    int MapCount
    {
        get { return SceneNames.Count; }
    }
    int NowLevel = -1;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        RemoveDarkScreen();
        StartNextMap();
    }

    StrangeEventMap MapController;
    Coroutine SceneLoader;

    void Move2StartMap()
    {
        ShowDarkScreen();
        if (SceneLoader != null)
        {
            StopCoroutine(SceneLoader);
            SceneLoader = null;
        }
        if (NowLevel >= 0)
            SceneLoader = StartCoroutine(_UnLoadNowScene());

        NowLevel = 0;

        var scene = SceneNames[NowLevel];
        if (SceneLoader != null)
        {
            StopCoroutine(SceneLoader);
            SceneLoader = null;
        }
        SceneLoader = StartCoroutine(_LoadScene(scene));
        RemoveDarkScreen();
    }
    void StartNextMap()
    {
        ShowDarkScreen();
        if (SceneLoader != null)
        {
            StopCoroutine(SceneLoader);
            SceneLoader = null;
        }
        if(NowLevel >= 0)
            SceneLoader = StartCoroutine(_UnLoadNowScene());

        NowLevel++;

        var scene = SceneNames[NowLevel];
        if (SceneLoader != null)
        {
            StopCoroutine(SceneLoader);
            SceneLoader = null;
        }
        SceneLoader = StartCoroutine(_LoadScene(scene));
        RemoveDarkScreen();
    }

    IEnumerator _UnLoadNowScene()
    {
        var scene = SceneManager.GetSceneByName(NowSceneName);
        if (scene != null)
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(scene);
            while (!asyncUnload.isDone)
            {
                yield return null;
            }
        }
    }

    IEnumerator _LoadScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        RemoveDarkScreen();
    }

    void ShowDarkScreen()
    {
        DarkImage.gameObject.SetActive(true);
    }

    void RemoveDarkScreen()
    {
        DarkImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var map = FindObjectOfType<StrangeEventMap>();
            var successionFlag = map.CheckIsPlayerSuccessed();

            if (successionFlag == true)
            {
                Debug.Log("Player Successed!");
                if (NowLevel < MapCount - 1)
                {
                    StartNextMap();
                }
                else
                {
                    Debug.Log("All maps completed!");
                }
            }
            else
            {
                Debug.Log("Player Failed! Restarting map...");
                //StartNextMap();
            }
        }
    }
}
