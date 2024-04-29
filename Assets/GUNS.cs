using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GUNS : MonoBehaviour
{
    public GameObject Player;
    public Sprite[] sprite;
    public Image imag;
    public SpriteRenderer Renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      int gun=  Player.GetComponent<OnShoot>().index;
       if(gun<9&&gun>-1)
        {
            imag.sprite= sprite[gun];
       }
      
    }
}
