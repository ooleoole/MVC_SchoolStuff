using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MVCDemo2.Models.Interface;

namespace MVCDemo2.Models.UserModelFolder
{
    public class EntityList<T> : ICollection<T>
        where T : IEntity


    {
        private bool _isReadOnly;
        private Collection<T> _innerList;


        public int Count => _innerList.Count;
        public virtual bool IsReadOnly => _isReadOnly;
        public T this[int index] => _innerList.Skip(index).FirstOrDefault();

        public EntityList()
        {
            _innerList = new Collection<T>();
        }

        public EntityList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        public void Add(T item)
        {
            item.Id = SetId();
            _innerList.Add(item);
        }

        private int SetId() => _innerList.Count > 0 ? GetFirstFreeId() : 1;


        private int GetFirstFreeId()
        {
            var sortedInnerList = _innerList.OrderBy(item => item.Id).ToList();
            var firstFreeId = sortedInnerList.Count + 1;

            for (var i = 0; i < sortedInnerList.Count; i++)
            {
                var id = sortedInnerList[i].Id;

                if (id != i + 1)
                {
                    return i + 1;
                }
            }
            return firstFreeId;
        }

        public void Clear()
        {
            _innerList.Clear();
        }

        public bool Contains(T item)
        {
            return _innerList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _innerList.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _innerList.Remove(item);
        }


    }


}