using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemPool<T> where T : Poolable, IPoolable
{
    T m_prefItem;
    List<T> m_lstItemFree;
    List<T> m_lstItemBusy;

    public ItemPool(T a_itemPrefab, int a_initialCount)
    {
        m_prefItem = a_itemPrefab;
        m_lstItemFree = new List<T>();

        for (int i = 0; i < a_initialCount; i++)
        {
            T l_newItem = GameObject.Instantiate(m_prefItem);
            l_newItem.gameObject.SetActive(false);
            m_lstItemFree.Add(l_newItem);
        }

        m_lstItemBusy = new List<T>();
    }

    public T GetItem()
    {
        T l_item;
        if (m_lstItemFree.Count > 0)
        {
            int l_lastIndex = m_lstItemFree.Count - 1;
            l_item = m_lstItemFree[l_lastIndex];
            m_lstItemFree.RemoveAt(l_lastIndex);
        }
        else
        {
            l_item = GameObject.Instantiate(m_prefItem);
            m_lstItemBusy.Add(l_item);
        }

        l_item.OnGet();
        return l_item;
    }

    public void ReleaseItem(T a_item)
    {
        m_lstItemFree.Add(a_item);
        m_lstItemBusy.Remove(a_item);
        a_item.OnRelease();
    }
}