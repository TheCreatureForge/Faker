using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneEmbedder : MonoBehaviour
{
    public string sceneToLoad;
    public RawImage displayTarget;
    public RenderTexture renderTexture;
    public WindowInputForwarder inputForwarder;

    async void Start()
    {
        await SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
        displayTarget.texture = renderTexture;

        Scene loaded = SceneManager.GetSceneByName(sceneToLoad);
        foreach (var root in loaded.GetRootGameObjects())
        {
            Camera cam = root.GetComponentInChildren<Camera>();
            inputForwarder.embeddedCamera = cam;
            break;
        }
    }
}