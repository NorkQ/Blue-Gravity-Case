using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class ExtensionMethods
{
    public static Transform FindDeepChild(this Transform aParent, string aName)
    {
        if (aParent != null)
        {
            var result = aParent.Find(aName);
            if (result != null)
                return result;

            foreach (Transform child in aParent)
            {
                result = child.FindDeepChild(aName);
                if (result != null)
                    return result;
            }
        }

        return null;
    }

    public static T FindClosest<T>(this Transform aCenterObject, Component[] aColliders)
    {
        float nearestDistance = float.MaxValue;
        float dummyDistance = float.MaxValue;
        T nearestObject = default(T);
        foreach(Component component in aColliders)
        {
            dummyDistance = (component.transform.position - aCenterObject.position).sqrMagnitude;
            if (dummyDistance < nearestDistance)
            {
                nearestDistance = dummyDistance;
                nearestObject = component.GetComponent<T>();
            }
        }

        return nearestObject;
    }

    public static Transform[] GetAllChildren(this Transform i_Parent)
    {
        List<Transform> allChildren = new List<Transform>();

        for(int i = 0; i < i_Parent.childCount; i++)
        {
            allChildren.Add(i_Parent.GetChild(i));
        }

        return allChildren.ToArray();
    }

    public static T FindDeepChild<T>(this Transform aParent, string aName)
    {
        T result = default(T);

        var transform = aParent.FindDeepChild(aName);

        if (transform != null)
        {
            result = (typeof(T) == typeof(GameObject)) ? (T)Convert.ChangeType(transform.gameObject, typeof(T)) : transform.GetComponent<T>();
        }

        if (result == null)
        {
            Debug.LogError($"FindDeepChild didn't find: '{aName}' on GameObject: '{aParent.name}'");
        }

        return result;
    }

    public static T GetRandomItem<T>(this IList<T> i_List)
    {
        T result = default(T);

        result = i_List[UnityEngine.Random.Range(0, i_List.Count)];

        return result;
    }

    public static bool IsBetween(this float val, float low, float high)
    {
        return val >= low && val <= high;
    }

    public static bool IsBetween(this int val, int low, int high)
    {
        return val >= low && val <= high;
    }

    public static bool IsBetween(this int val, float low, float high)
    {
        return val >= low && val <= high;
    }

    public static void AddX(this Transform i_Transform, float i_X)
    {
        i_Transform.position = new Vector3(i_Transform.position.x + i_X, i_Transform.position.y, i_Transform.position.z);
    }

    public static void AddY(this Transform i_Transform, float i_Y)
    {
        i_Transform.position = new Vector3(i_Transform.position.x, i_Transform.position.y + i_Y, i_Transform.position.z);
    }

    public static void AddLocalY(this Transform i_Transform, float i_Y)
    {
        i_Transform.localPosition = new Vector3(i_Transform.localPosition.x, i_Transform.localPosition.y + i_Y, i_Transform.localPosition.z);
    }

    public static void SetX(this Transform i_Transform, float i_X)
    {
        i_Transform.position = new Vector3(i_X, i_Transform.position.y, i_Transform.position.z);
    }

    public static void SetY(this Transform i_Transform, float i_Y)
    {
        i_Transform.position = new Vector3(i_Transform.position.x, i_Y, i_Transform.position.z);
    }

    public static void SetZ(this Transform i_Transform, float i_Z)
    {
        i_Transform.position = new Vector3(i_Transform.position.x, i_Transform.position.y, i_Z);
    }

    public static void SetLocalX(this Transform i_Transform, float i_X)
    {
        i_Transform.localPosition = new Vector3(i_X, i_Transform.localPosition.y, i_Transform.localPosition.z);
    }

    public static void SetLocalY(this Transform i_Transform, float i_Y)
    {
        i_Transform.localPosition = new Vector3(i_Transform.localPosition.x, i_Y, i_Transform.localPosition.z);
    }

    public static void SetLocalZ(this Transform i_Transform, float i_Z)
    {
        i_Transform.localPosition = new Vector3(i_Transform.localPosition.x, i_Transform.localPosition.y, i_Z);
    }

    public static void SetLocalScaleX(this Transform i_Transform, float i_X)
    {
        i_Transform.localScale = new Vector3(i_X, i_Transform.localScale.y, i_Transform.localScale.z);
    }

    public static void SetLocalScaleY(this Transform i_Transform, float i_Y)
    {
        i_Transform.localScale = new Vector3(i_Transform.localScale.x, i_Y, i_Transform.localScale.z);
    }

    public static void SetLocalScaleZ(this Transform i_Transform, float i_Z)
    {
        i_Transform.localScale = new Vector3(i_Transform.localScale.x, i_Transform.localScale.y, i_Z);
    }

    public static void SetAlpha(this Material i_Material, float i_A)
    {
        i_Material.color = new Color(i_Material.color.r, i_Material.color.g, i_Material.color.b, i_A);
    }

    public static Color SetAlpha(this Color i_Color, float i_Alpha)
    {
        return new Color(i_Color.r, i_Color.g, i_Color.b, i_Alpha);
    }

    public static T Clone<T>(T source)
    {
        if (!typeof(T).IsSerializable)
        {
            throw new System.ArgumentException("The type must be serializable.", "source");
        }

        if (UnityEngine.Object.ReferenceEquals(source, null))
        {
            return default(T);
        }

        System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        Stream stream = new MemoryStream();
        using (stream)
        {
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }
}
