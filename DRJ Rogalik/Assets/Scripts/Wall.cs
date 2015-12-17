using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public Sprite dmgWall;
    public int hp = 4;
    private SpriteRenderer spriteRender;
	// Use this for initialization
	void Awake ()
    {
        spriteRender = GetComponent<SpriteRenderer>();
	 
	}
    public void DamageWall(int loss)
    {
        spriteRender.sprite = dmgWall;
        hp -= loss;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
