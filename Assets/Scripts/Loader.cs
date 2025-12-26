using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private static Scene targetSceneIndex;
    public enum Scene
    {
        MainMenu,
        GameScene,
        LoadingScene
    }
    public static void LoadTargetScene(Scene targetScene)
    {
        Loader.targetSceneIndex = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(targetSceneIndex.ToString());
    }
}
