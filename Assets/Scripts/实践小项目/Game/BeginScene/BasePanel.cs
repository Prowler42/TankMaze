using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour  where T:class //约束 T是类类型
{   
    public virtual void ShowPanel()
    {
         this.gameObject.SetActive(true);
    }
    public virtual void HidePanel()
    {
        this.gameObject.SetActive(false);
    }
    //每个面板都是单例模式
    //静态私有成员
    private static T instance; //继承了MONOBEHAVIOR的类不能new出对象
    //静态公共属性
    public static T Instance
    {
        get { return instance;}
    }

    private void Awake()
    {
        //由于单例无法初始化
        //在生命周期开始就去获取挂载了该脚本的类对象
        //转换为对应类型 并用instance存储
        instance =this as T;
    }

    void Update()
    {
        
    }
}
