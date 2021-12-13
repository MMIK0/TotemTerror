using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public static PlayerHealthBar instance;
    public Transform bar;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public void UpdateHealthbar(float currentHp,float maxHp)
    {
        if (!bar)
            return;
        bar.localScale = new Vector3(1,currentHp / maxHp, 1);
    }
}
