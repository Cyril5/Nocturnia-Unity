using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Com.NocturnSystem.Nocturnia
{
    public class Utils
    {

        public static Transform GetChild(Transform parent,string name)
        {
            Transform[] children = parent.GetComponentsInChildren<Transform>();
            return children.Where(c => c.name == name).FirstOrDefault();
        }

        public static Vector3 RandomInsideBoxArea(Vector3 min, Vector3 max)
        {

            float x = Random.Range(min.x, max.x);
            float y = Random.Range(min.y, max.y);
            float z = Random.Range(min.z, max.z);
            return new Vector3(x, y, z);
        }

        public static List<T> GetParentChidren<T>(GameObject parent, bool includeInactive=false)
        {
            List<T> list = parent.GetComponentsInChildren<T>(includeInactive).ToList();
            list.RemoveAt(0);
            return list;
        }
        public static List<GameObject> GetParentChidren(GameObject parent, bool includeInactive = false)
        {
            List<GameObject> list = parent.GetComponentsInChildren<GameObject>(includeInactive).ToList();
            list.RemoveAt(0);
            return list;
        }
        public static List<Transform> GetParentChidren(Transform parent, bool includeInactive = false)
        {
            List<Transform> list = parent.GetComponentsInChildren<Transform>(includeInactive).ToList();
            list.RemoveAt(0);

            return list;
        }
    }

    [System.Serializable]
    public class KeysValuesList<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        //[SerializeField] private List<TKey> keys;
        //[SerializeField] private List<TValue> values;
        [SerializeField] private List<KeysValuesListElement<TKey, TValue>> keysValues = new List<KeysValuesListElement<TKey, TValue>>();

        private string listContentText = "";

        public void OnAfterDeserialize()
        {


            Clear(); // clear current dictionnary

            //if (keysValues.keys.Count != values.Count)
            //    throw new Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

            for (int i = 0; i < keysValues.Count; i++)
                Add(keysValues[i].key, keysValues[i].value);

            listContentText = "";

            foreach (KeyValuePair<TKey, TValue> kvp in this)
            {
                listContentText += kvp.Key + ";" + kvp.Value + " | ";
            }

        }

        public void OnBeforeSerialize()
        {
            //foreach (KeyValuePair<TKey, TValue> pair in this)
            //{
            //    keys.Add(pair.Key);
            //    values.Add(pair.Value);
            //}
        }
    }

    [System.Serializable]
    public class KeysValuesListElement<TKey, TValue>
    {
        public TKey key;
        public TValue value;
    }
}