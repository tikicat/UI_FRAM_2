/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        03/01/2017 17:16
================================================================*/
 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    private static GameObject _canvas;

    private GameObject _overlay;

    void Awake()
    {
        _canvas = new GameObject("TransitionCanvas");
        var canvas = _canvas.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        DontDestroyOnLoad(_canvas);
    }

    public static void LoadLevel(string level, float duration, Color color)
    {
        var fade = new GameObject("Transition");
        fade.AddComponent<Transition>();
        fade.GetComponent<Transition>().StartFade(level, duration, color);
        fade.transform.SetParent(_canvas.transform, false);
        fade.transform.SetAsLastSibling();
        DontDestroyOnLoad(fade);
    }

    private void StartFade(string level, float duration, Color fadeColor)
    {
        StartCoroutine(RunFade(level, duration, fadeColor));
    }

    private IEnumerator RunFade(string level, float duration, Color fadeColor)
    {
        var bgTex = new Texture2D(1,1);
        bgTex.SetPixel(0,0,fadeColor);
        bgTex.Apply();

        _overlay = new GameObject();
        var image = _overlay.AddComponent<Image>();
        var rect = new Rect(0,0,bgTex.width, bgTex.height);
        var sprite = Sprite.Create(bgTex, rect, new Vector2(0.5f, 0.5f), 1);

        image.material.mainTexture = bgTex;
        image.sprite = sprite;

        var newColor = image.color;
        image.color = newColor;
        image.canvasRenderer.SetAlpha(0.0f);

        _overlay.transform.localScale = new Vector3(1,1,1);
        _overlay.GetComponent<RectTransform>().sizeDelta = _canvas.GetComponent<RectTransform>().sizeDelta;
        _overlay.transform.SetParent(_canvas.transform, false);
        _overlay.transform.SetAsFirstSibling();

        var time = 0.0f;
        var halfDuration = duration / 2.0f;
        while(time < halfDuration)
        {
            time += Time.deltaTime;
            image.canvasRenderer.SetAlpha(Mathf.InverseLerp(0,1,time / halfDuration));
            yield return new WaitForEndOfFrame();
        }

        image.canvasRenderer.SetAlpha(1.0f);
        yield return new WaitForEndOfFrame();

        SceneManager.LoadScene(level);

        time = 0.0f;

        while(time < halfDuration)
        {
            time += Time.deltaTime;
            image.canvasRenderer.SetAlpha(Mathf.InverseLerp(1, 0 , time/halfDuration));
            yield return new WaitForEndOfFrame();
        }

        image.canvasRenderer.SetAlpha(0.0f);
        yield return new WaitForEndOfFrame();
        Destroy(_canvas);
    }
}
