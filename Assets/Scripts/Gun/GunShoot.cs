using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField, Min(0f)] private float _damage = 30f;

    [Header("Ray")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Min(0f)] private float _distance = Mathf.Infinity;
    [SerializeField, Min(0f)] private int _shotCount = 1;
    [SerializeField, Min(0f)] private float _shootPause = 0.5f;

    [Header("Spread")]
    [SerializeField] private bool _useSpread;
    [SerializeField, Min(0f)] private float _spreadFactor = 0.1f;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem _muzzleEffect;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField, Min(0f)] private float _hitEffectDestroyDelay = 1f;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;


    private Camera _camera;
    private Transform cameraTransform;
    private float timeLastShoot = 0;
    private bool isEnabled = false;

    private void Start()
    {
        _camera = gameObject.GetComponentInParent<Camera>();
        cameraTransform = _camera.transform;
    }

    private void Update()
    {
        if (isEnabled && Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > timeLastShoot + _shootPause)
            {
                Shoot();
                timeLastShoot = Time.time;
            }
        }
    }

    public void Shoot()
    {
        for (var i = 0; i < _shotCount; i++)
        {
            TakeShot();
        }
        ShowMuzzleEffect();
    }

    private void TakeShot()
    {
        var direction = _useSpread ? cameraTransform.forward + CalculateSpread() : cameraTransform.forward;
        var ray = new Ray(cameraTransform.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            var hitCollider = hitInfo.collider;
            if (hitCollider.tag == "Mob")
            {
                MobBehaviour hp = hitCollider.GetComponentInParent<MobBehaviour>();
                hp.SetDamage(_damage);
            }
            ShowHitEffect(hitInfo);
        }
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3 
        {
            x = Random.Range(-_spreadFactor, _spreadFactor),
            y = Random.Range(-_spreadFactor, _spreadFactor),
            z = Random.Range(-_spreadFactor, _spreadFactor),
        };
    }

    private void ShowMuzzleEffect()
    {
        if (_muzzleEffect != null)
        {
            _muzzleEffect.Play();
        }

        if (_audioSource != null && _audioClip != null)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }

    private void ShowHitEffect(RaycastHit hitInfo)
    {
        if (_hitEffect != null)
        {
            var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
            var hitEffect = Instantiate(_hitEffect, hitInfo.point, hitEffectRotation);

            Destroy(hitEffect.gameObject, _hitEffectDestroyDelay);
        }
    }

    private void OnEnable()
    {
        InventoryOpener.onInventoryOpened += SetDisable;
        InventoryOpener.onInventoryClosed += SetEnable;
    }

    private void SetEnable()
    {
        isEnabled = true;
    }

    private void SetDisable()
    {
        isEnabled = false;
    }
}
