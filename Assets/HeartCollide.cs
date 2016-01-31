using UnityEngine;
using System.Collections;

public class HeartCollide : MonoBehaviour
{

    // Use this for initialization
    //void OnTriggerEnter(Collider col2d)
    //{
    //    if (col2d.gameObject.transform.transform.name == "Guy")
    //    {
    //        Debug.Log("Heart hit Guy");
    //    }
    //}
    void OnCollisionEnter2D(Collision2D collision)
    {
        string heartBoxContainer = string.Empty;

        if (collision.gameObject.transform.transform.name == "Guy")
        {

            Debug.Log("Heart hit Guy");
            switch (this.transform.name)
            {
                case "heart1":
                    heartBoxContainer = "heart1Box";
                    break;

                case "heart2":
                    heartBoxContainer = "heart2Box";
                    break;

                case "heart3":
                    heartBoxContainer = "heart3Box";
                    break;

                case "heart4":
                    heartBoxContainer = "heart4Box";
                    break;
            }
            GameObject obj = GameObject.Find(heartBoxContainer);
            //obj.gameObject.transform.
            this.transform.SetParent(obj.transform);
            this.transform.position = obj.transform.position;


        }
    }
}
