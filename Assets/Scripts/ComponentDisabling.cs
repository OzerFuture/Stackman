using UnityEngine;

public static class ComponentDisable 
{
    public static void Enabled<T>(this GameObject gameObject, bool state) where T : MonoBehaviour
    {
        var component = gameObject.GetComponent<T>();
        if (component != null)
        {
            component.enabled = state;
        }
    }
}
