using System.Collections;
using UnityEngine;

public class EnemyHp : MobHp
{
    [SerializeField] private float originalHp = 50;
    [SerializeField] private ParticleSystem destroyEffect;
    [SerializeField] private AudioClip _audioClip;

    private float currentHp;
    private DropItem dropItem;
    private AudioSource _audioSource;

    private void Start()
    {
        currentHp = originalHp;
        dropItem = GetComponent<DropItem>();
        _audioSource = GameObject.FindGameObjectWithTag("MainAudioSource").GetComponent<AudioSource>();
    }

    public override bool SetDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp > 0)
        {
            return true;
        }
        else
        {
            dropItem.CheckMob();
            Die();
            showDestroyEffect();

            return false;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void showDestroyEffect()
    {
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
        }

        if (_audioSource != null && _audioClip != null)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}