using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TotemHealth : MonoBehaviour
{
    float MaxHealth = 1f;
    HitPoints[] hitPoints;
    public bool Inactive = true;
    public List<HitPointEvent> hitPointEvents = new List<HitPointEvent>();
    private void OnEnable()
    {
        hitPoints  = GetComponentsInChildren<HitPoints>();
        foreach (HitPoints hp in hitPoints)
            MaxHealth += hp.maxHitPoints;
        if (MaxHealth > 1)
            MaxHealth -= 1;
    }
    private void Update()
    {
        if (Inactive)
            return;
        float currentHealth = 0f;
        foreach (HitPoints hp in hitPoints)
            currentHealth += hp.currentHitPoints;
        Debug.Log("HP: " + currentHealth + "/" + MaxHealth);
        HealthBar.instance.UpdateHealthbar(currentHealth, MaxHealth);
        foreach(HitPointEvent hitPointEvent in hitPointEvents)
        {
            hitPointEvent.TriggerCheck(MaxHealth, currentHealth);
        }
    }
    [System.Serializable]
    public class HitPointEvent
    {
        [Range(0, 100)]
        public float HpTriggerPrecentage;
        public UnityEvent hpEvent;
        bool hasBeenTriggered;
        public void TriggerCheck(float maxHp, float currentHp)
        {
            if (hasBeenTriggered)
                return;
            if (currentHp / maxHp * 100 <= HpTriggerPrecentage || currentHp==0)
                hpEvent.Invoke();
        }
    }
    public void ActivateTotem()
    {
        Inactive = false;
        TotemScrip[] t = GetComponentsInChildren<TotemScrip>();
        foreach (TotemScrip totemScrip in t)
            totemScrip.Activate();
    }
}
