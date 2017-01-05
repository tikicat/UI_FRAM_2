/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        04/01/2017 11:01
================================================================*/
 
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TestEditor))]
[ExecuteInEditMode]
public class MyEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        TestEditor editorTest = (TestEditor)target;
        editorTest._rectVaule = EditorGUILayout.RectField("窗口坐标", editorTest._rectVaule);

        editorTest._texture = EditorGUILayout.ObjectField("增加一个贴图", editorTest._texture, typeof(Texture),true) as Texture;
        base.OnInspectorGUI();
    }
}
