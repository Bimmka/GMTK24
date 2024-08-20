using System;
using System.Collections;
using Code.Gameplay.Windows.Windows.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.Loading
{
  public class SceneLoader : ISceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly LoadingCurtain _loadingCurtain;

    public SceneLoader(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
    {
      _coroutineRunner = coroutineRunner;
      _loadingCurtain = loadingCurtain;
    }

    public void LoadScene(string name, Action onLoaded = null)
    {
      _loadingCurtain.Show(() =>OnCurtainShown(name, onLoaded));
    }

    private void OnCurtainShown(string name, Action onLoaded)
    {
      _coroutineRunner.StartCoroutine(Load(name, () => HideCurtain(onLoaded)));
    }

    private void HideCurtain(Action onLoaded = null)
    {
      _loadingCurtain.Hide();
      onLoaded?.Invoke();
    }

    private IEnumerator Load(string nextScene, Action onLoaded)
    {
      if (SceneManager.GetActiveScene().name == nextScene)
      {
        onLoaded?.Invoke();
        yield break;
      }

      AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

      while (!waitNextScene.isDone)
        yield return null;

      onLoaded?.Invoke();
    }
  }
}