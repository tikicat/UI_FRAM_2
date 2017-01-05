/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        04/01/2017 11:31
================================================================*/
 
using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorWindowTest : EditorWindow 
{
    [MenuItem ("MyMenu/OpenWindow")]
	static void OpenWindow()
    {
        Rect wr = new Rect(0,0,500,500);
        EditorWindow window = (EditorWindowTest)EditorWindow.GetWindowWithRect(typeof(EditorWindowTest), wr, true, "测试创建窗口");
        window.Show();
    }

    private string _text;
    private Texture _texture;

    public void Awake()
    {
        _texture = Resources.Load("1") as Texture;
    }

    void OnGUI()
    {
        _text = EditorGUILayout.TextField("输入文字:", _text);
        if(GUILayout.Button("打开通知", GUILayout.Width(200)))
        {
            this.ShowNotification(new GUIContent("这是一个通知栏"));
        }

        if(GUILayout.Button("关闭通知", GUILayout.Width(200)))
        {
            this.RemoveNotification();
        }

        EditorGUILayout.LabelField("鼠标在窗口的位置", Event.current.mousePosition.ToString());

        _texture = EditorGUILayout.ObjectField("添加贴图", _texture, typeof(Texture), true) as Texture;

        if(GUILayout.Button("关闭窗口", GUILayout.Width(200)))
        {
            this.Close();
        }
    }

    void OnFocus()
    {
        Debug.Log("OnFocus");
    }


    void OnLostFouce()
    {
        Debug.Log("OnLostFouce");
    }

    void OnHierarchyChange()
    {
        Debug.Log("OnHierarchyChange");
    }

    void OnProjectChange()
    {
        Debug.Log("OnProjectChange");
    }

    void OnInSpectorUpdate()
    {
        this.Repaint();
    }

    void OnSelectionChange()
    {
        foreach(Transform t in Selection.transforms)
        {
            Debug.Log("OnSelectionChange" + t.name);
        }
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
