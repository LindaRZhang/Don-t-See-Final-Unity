using UnityEngine;
using UnityEngine.UI;
/* Linda Rong Zhang
*  This file change input text's and text's position
*  Citation: https://www.youtube.com/watch?v=0bvDmqqMXcA
*/
public class TextAndInput : MonoBehaviour
{
    public Text h;
    public InputField y;
    // The place where the words stick to wall and where madlib will be showing
    
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);//make the word go with position ish
        h.transform.position = pos;
        y.transform.position = pos+ new Vector3(0,-30,-30);
    }
}
