using UnityEngine;

public class fishdestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LeftSide" || other.tag == "RightSide" || other.tag == "LeftSide1" || other.tag == "RightSide1" || other.tag == "LeftSide2" || other.tag == "RightSide2")
        {
            {
                Destroy(gameObject);
            }
        }
    }

}
