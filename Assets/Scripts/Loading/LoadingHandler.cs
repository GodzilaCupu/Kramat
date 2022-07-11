using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingHandler : MonoBehaviour
{
    [SerializeField] private LoadingProgresSO so_progres;

    private List<AsyncOperation> sceneLoading = new List<AsyncOperation>();
    private float totalSceneProgres;

    private void Start()
    {
        EventsManager.current.onLoadScene += LoadGame;
    }

    private void OnDisable()
    {
        EventsManager.current.onLoadScene -= LoadGame;
    }

    private void LoadGame(enum_ScenesName startScene,enum_ScenesName targetScene)
    {
        sceneLoading.Add(SceneManager.UnloadSceneAsync(((int)startScene)));
        sceneLoading.Add(SceneManager.LoadSceneAsync(((int)enum_ScenesName.Loading),LoadSceneMode.Additive));
        sceneLoading.Add(SceneManager.LoadSceneAsync(((int)targetScene)));

        if (sceneLoading[2].isDone)
            sceneLoading.Add(SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()));
    }

    public IEnumerator LoadingProgres()
    {
        for(int i = 0 ; i < sceneLoading.Count; i++)
        {
            while (!sceneLoading[i].isDone)
            {
                totalSceneProgres = 0;
                foreach(AsyncOperation operation in sceneLoading)
                {
                    totalSceneProgres += operation.progress;
                }
                totalSceneProgres = (totalSceneProgres / sceneLoading.Count) * 100f;
                so_progres._loadingProgres = totalSceneProgres;

                yield return null;
            }
        }
    }
}
