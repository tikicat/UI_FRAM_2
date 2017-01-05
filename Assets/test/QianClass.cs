/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        04/01/2017 10:07
================================================================*/
 
using System;
[CustomAttribute("QianClass")]
class QianClass
{
    public static void Main()
    {
        QianClass c = new QianClass();
    }

    public QianClass()
    {
        if (this.GetType().IsDefined(typeof(CustomAttribute), false))
        {
            System.Console.WriteLine("QianClass");
        }
    }
}
