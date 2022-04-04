using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hearts;

    [SerializeField]
    private Sprite emptyHeart;

    [SerializeField]
    private Sprite fullHeart;

    private int health = 3;
    private SpriteRenderer spriteR;


    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            print("Well, you died. Better luck next time :P");
            transform.position = startPos;
            health = 3;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            spriteR = hearts[i].GetComponent<SpriteRenderer>();
            if (i < health)
            {
                spriteR.sprite = fullHeart;
            }
            else
            {
                spriteR.sprite = emptyHeart;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            health--;
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
