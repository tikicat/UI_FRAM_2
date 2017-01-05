/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        04/01/2017 14:14
================================================================*/
 
using UnityEngine;
using UnityEditor;

using System.Collections;

[CustomEditor(typeof(SceneTest))]
public class SceneEditor : Editor 
{
    void OnSceneGUI()
    {
        SceneTest test = (SceneTest)target;
        Handles.Label(test.transform.position + Vector3.up * 2, test.transform.name + " : " + test.transform.position.ToString());

        Handles.BeginGUI();
        GUILayout.BeginArea(new Rect(100, 100, 100, 100));
        if(GUILayout.Button("这是一个按钮"))
        {
            Debug.Log("SceneTest");
        }

        GUILayout.Label("我在编辑Scene视图");

        GUILayout.EndArea();

        Handles.EndGUI();

    }
}
