/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        03/01/2017 15:24
================================================================*/
 
using UnityEngine;
using System.Collections;

public class MonoBehaviorSingleton<T> : MonoBehaviour where T : MonoBehaviorSingleton<T> 
{
    private static MonoBehaviorSingleton<T> instance;

    protected static bool _setNullAfterDestroy = true;

    private static bool _destroyed = true;

    private static bool _initializedAtLeastOnce = true;

    private static bool _needInitialization = true;

    protected bool Destroyed
    {
        get { return _destroyed; }
    }

    public void Awake()
    {
        if(instance == null || _destroyed)
        {
            instance = this;
            _destroyed = false;
        }
        else if(instance != this)
        {
            Debug.LogError("Two instance of the same singleton '" + this + "'");
        }

        if(_needInitialization)
        {
            _needInitialization = false;
            _initializedAtLeastOnce = true;
#if UNITY_EDITOR || SAMPLE_OUTSIDE_EDITOR
            Profiler.BeginSample(instance.name + ".Initialize");
#endif
            instance.Initialize();
#if UNITY_EDITOR || SAMPLE_OUTSIDE_EDITOR
            Profiler.EndSample();
#endif

        }
    }

    public void OnDestroy()
    {
#if UNITY_EDITOR || SAMPLE_OUTSIDE_EDITOR 
        Profiler.BeginSample(name + ".Destroy");
#endif
        Destroy();
#if UNITY_EDITOR || SAMEPLE_OUTSIDE_EDITOR
        Profiler.EndSample();
#endif
    }

    public static T Instance
    {
        get
        {
            if(instance == null || _destroyed || _needInitialization)
            {
                if(instance == null || _destroyed)
                {
                    MonoBehaviorSingleton<T> newInstance = MonoBehaviour.FindObjectOfType(typeof(MonoBehaviorSingleton<T>)) as MonoBehaviorSingleton<T>;
                    if(newInstance != null)
                    {
                        instance = newInstance;
                        _destroyed = false;
                    }
                }

                if(instance != null && !_destroyed)
                {
                    if(_needInitialization)
                    {
                        _needInitialization = false;
                        _initializedAtLeastOnce = true;
#if UNITY_EDITOR || SAMPLE_OUTSIDE_EDITOR
                        Profiler.BeginSample(instance.name + ".Initialize");
#endif
                        instance.Initialize();
#if UNITY_EDITOR || SAMPLE_OUTSIDE_EDITOR
                        Profiler.EndSample();
#endif
                    }
                }
                else
                {
                    if(!_initializedAtLeastOnce)
                    {
                        Debug.LogError("Missing Singleton '" + typeof(T).Name + "'");
                    }
                }
            }
            return (T)instance;
        }
    }

    public static void Dispose()
    {
        if(instance != null && !_destroyed)
        {
            Destroy(instance.gameObject);
            instance = null;
        }
    }

    protected virtual void Initialize()
    {
    }

    protected virtual void Destroy()
    {
    }

    static public bool IsInitialized()
    {
        return instance != null && !_destroyed;
    }

    static public bool IsAvailable()
    {
        return IsInitialized() || MonoBehaviour.FindObjectOfType(typeof(MonoBehaviorSingleton<T>)) != null;
    }
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
