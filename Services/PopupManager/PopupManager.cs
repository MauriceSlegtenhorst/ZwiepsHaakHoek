using Microsoft.AspNetCore.Components;
using System.Collections;

namespace ZwiepsHaakHoek.Services.PopupManager
{
    public class PopupManager : IPopupManager
    {
        private RenderFragment[] _popups = Array.Empty<RenderFragment>();

        public int Count => _popups.Length;

        public bool IsReadOnly => false;

        public event IPopupManager.PopupsChanged OnPopupsChanged;

        public void Add(RenderFragment popupContent)
        {
            if(popupContent is null)
                throw new ArgumentNullException(nameof(popupContent));

            var newPopupsArray = new RenderFragment[_popups.Length + 1];
            _popups.CopyTo(newPopupsArray, 0);
            newPopupsArray[newPopupsArray.Length - 1] = popupContent;
            _popups = newPopupsArray;

            OnPopupsChanged?.Invoke(popupContent);
        }

        public bool Remove(RenderFragment popupContent)
        {
            if (popupContent is null)
                throw new ArgumentNullException(nameof(popupContent));

            if (_popups.Length == 0)
                return false;

            var newPopups = new RenderFragment[_popups.Length - 1];
            bool isRemoved = false;

            for (int i = 0; i < _popups.Length; i++)
            {
                if (_popups[i] == popupContent)
                {
                    isRemoved = true;
                }
                else
                {
                    newPopups[i] = _popups[isRemoved ? i - 1 : i];
                }
            }

            _popups = newPopups;
            OnPopupsChanged.Invoke(popupContent);
            return isRemoved;
        }

        public IEnumerator<RenderFragment> GetEnumerator()
        {
            for (int i = 0; i < _popups.Length; i++)
            {
                yield return _popups[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _popups.GetEnumerator();
        }

        public void Clear()
        {
            _popups = Array.Empty<RenderFragment>();
        }

        public bool Contains(RenderFragment item)
        {
            return _popups.Contains(item);
        }

        public void CopyTo(RenderFragment[] array, int arrayIndex)
        {
            _popups.CopyTo(array, arrayIndex);
        }

        public int IndexOf(RenderFragment popupContent)
        {
            for (int i = 0; i < _popups.Length; i++)
            {
                if (_popups[i] == popupContent)
                    return i;
            }

            return -1;
        }
    }
}
