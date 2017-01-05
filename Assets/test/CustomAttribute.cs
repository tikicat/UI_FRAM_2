/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        04/01/2017 09:55
================================================================*/
 
using System;
using System.Collections;
using System.Collections.Generic;
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CustomAttribute : System.Attribute 
{
    string _name;
	public CustomAttribute(string name)
    {
        _name = name;
    }
}
