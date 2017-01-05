/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        05/01/2017 19:55
================================================================*/
 
using UnityEngine;
using System.Collections;

public class PopupOpener : MonoBehaviour {

    public GameObject _popupPrefab;
    protected Canvas _canvas;

	// Use this for initialization
	void Start () {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
	}
	
    public virtual void OpenPopup()
    {
        var popup = Instantiate(_popupPrefab) as GameObject;
        popup.SetActive(true);
        popup.transform.localScale = Vector3.one;

        popup.transform.SetParent(_canvas.transform, false);
        popup.GetComponent<Popup>().Open();
    }

}
