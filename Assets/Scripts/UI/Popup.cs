/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        05/01/2017 16:33
================================================================*/
 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Popup : MonoBehaviour {

    public Color _backgroundColor = new Color(10.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f, 0.6f);

    private GameObject _background;

    public void Open()
    {
        AddBackground();
    }

    public void Close()
    {
        var animator = GetComponent<Animator>();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
            animator.Play("Close");

        RemoveBackground();
        StartCoroutine(RunPopopDestroy());
    }

    private IEnumerator RunPopopDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(_background);
        Destroy(gameObject);
    }

    private void AddBackground()
    {
        var bgTex = new Texture2D(1, 1);
        bgTex.SetPixel(0, 0, _backgroundColor);
        bgTex.Apply();

        _background = new GameObject("PopupBackground");
        var image = _background.AddComponent<Image>();
        var rect = new Rect(0, 0, bgTex.width, bgTex.height);
        var sprite = Sprite.Create(bgTex, rect, new Vector2(0.5f, 0.5f), 1);
        image.material.mainTexture = bgTex;
        image.sprite = sprite;
        var newColor = image.color;
        image.color = newColor;
        image.canvasRenderer.SetAlpha(0.0f);
        image.CrossFadeAlpha(1.0f, 0.4f, false);

        var canvas = GameObject.Find("Canvas");
        _background.transform.localScale = Vector3.one;
        _background.GetComponent<RectTransform>().sizeDelta = canvas.GetComponent<RectTransform>().sizeDelta;
        _background.transform.SetParent(canvas.transform, false);
        _background.transform.SetSiblingIndex(transform.GetSiblingIndex());

    }

	private void RemoveBackground()
    {
        var image = _background.GetComponent<Image>();
        if (image != null)
            image.CrossFadeAlpha(0.0f, 0.2f, false);
    }
}
