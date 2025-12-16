using TMPro;
using UnityEngine;

public class Itemcollector : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    private int points = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
            points++;
            text.text = "Points: " + points;
        }
    }

}
