using UnityEngine;

public class Poolable : MonoBehaviour, IPoolable
{
    public virtual void OnGet()
    {
        gameObject.SetActive(true);
    }
    public virtual void OnRelease()
    {
        gameObject.SetActive(false);
    }
}