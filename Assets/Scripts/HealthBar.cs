using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
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
        bar.localScale = new Vector3(currentHp / maxHp, 1, 1);
    }
}
