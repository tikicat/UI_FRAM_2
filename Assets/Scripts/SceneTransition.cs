/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        03/01/2017 17:14
================================================================*/
 
using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour 
{
    public string _sceneName = "";
    public float _duration = 1.0f;
    public Color _color = Color.black;

    public void PerformTransition()
    {
        Transition.LoadLevel(_sceneName, _duration, _color);
    }
}
