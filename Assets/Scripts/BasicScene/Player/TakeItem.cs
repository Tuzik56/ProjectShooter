using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _range = 10f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public void Take()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ItemController item = FindItem();
            if (item != null)
            {
                item.Take();
                PlaySound();
            }
        }
    }

    public ItemController FindItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _range, ~(1 << LayerMask.NameToLayer("RaycastIgnore"))))
        {
            if (hit.transform.TryGetComponent(out ItemController item))
            {
                return item;
            }
        }
        return null;
    }

    private void PlaySound()
    {
        if (_audioSource != null && _audioClip != null)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
