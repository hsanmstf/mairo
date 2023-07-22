using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour
{
    public Transform plyer;
    SpriteRenderer sp;
    Vector3 starpos;
    float hight = 2;
    [SerializeField]
    float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
      
        sp = GetComponentInChildren<SpriteRenderer>();
        starpos = transform.position;
        StartCoroutine(Englanmition());
    }

    // Update is called once per frame
    void Update()
    {
     if(plyer.position.x>transform.position.x)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
          
    }
    IEnumerator Englanmition()
    {
        Vector3 endpos = new Vector3(starpos.x, starpos.y+hight, starpos.z);
        bool isfight = true;
        float value = 0;
        while (true)
        {
            yield return null;
            // Debug.Log("dgfghghf");
            if (isfight)
            {
                transform.position = Vector3.Lerp(starpos,endpos,value);
            }
            else
            {
                transform.position = Vector3.Lerp(endpos, starpos, value);
            }
            value = value + Time.deltaTime*speed;
            if (value > 1)
            {
                value = 0;
                isfight = !isfight;
            }
        }

            


        

    }
}
