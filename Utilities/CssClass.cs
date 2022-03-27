using System.Collections;
using System.Text;

namespace ZwiepsHaakHoek.Utilities
{
    public class CssClass : IList<string>
    {
        public string[] Classes { get; set; }

        public int Count => Classes.Length;

        public bool IsReadOnly { get; }

        public string this[int index] { get => Classes[index]; set => Classes[index] = value; }

        public CssClass(params string[] classes)
        {
            Classes = classes;
        }

        public CssClass(bool isReadOnly, params string[] classes)
        {
            IsReadOnly = isReadOnly;
            Classes = classes;
        }

        public int IndexOf(string item)
        {
            return Array.IndexOf(Classes, item);
        }

        public void Insert(int index, string item)
        {
            if (IsReadOnly)
                return;

            int newLength = Classes.Length + 1;
            var newClasses = new string[newLength];
            bool isInserted = false;

            for (int i = 0; i < newLength; i++)
            {
                if(i == index)
                {
                    newClasses[i] = item;
                    isInserted = true;
                }
                else
                {
                    newClasses[i] = Classes[isInserted ? i - 1 : i];
                }
            }

            Classes = newClasses;
        }

        public void RemoveAt(int index)
        {
            if (IsReadOnly)
                return;

            int newLength = Classes.Length - 1;
            var newClasses = new string[newLength];
            bool isRemoved = false;

            for (int i = 0; i < newLength; i++)
            {
                if (i == index)
                {
                    newClasses[i] = Classes[i + 1];
                    isRemoved = true;
                }
                else
                {
                    newClasses[i] = Classes[isRemoved ? i + 1 : i];
                }
            }

            Classes = newClasses;
        }

        public void Add(string item)
        {
            if (IsReadOnly)
                return;

            int newLength = Classes.Length + 1;
            var newClasses = new string[newLength];

            Classes.CopyTo(newClasses, 0);
            newClasses[newLength - 1] = item;

            Classes = newClasses;
        }

        public void Clear()
        {
            if (IsReadOnly)
                return;

            Classes = Array.Empty<string>();
        }

        public bool Contains(string item)
        {
            return Classes.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            Classes.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            if (IsReadOnly)
                return false;

            int newLength = Classes.Length - 1;
            var newClasses = new string[newLength];
            bool isRemoved = false;

            for (int i = 0; i < newLength; i++)
            {
                if (Classes[i] == item)
                {
                    newClasses[i] = Classes[i + 1];
                    isRemoved = true;
                }
                else
                {
                    newClasses[i] = Classes[isRemoved ? i + 1 : i];
                }
            }

            Classes = newClasses;
            return isRemoved;
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < Classes.Length; i++)
            {
                yield return Classes[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < Classes.Length; i++)
            {
                stringBuilder.Append(Classes[i]);
                if(i != Classes.Length -1)
                    stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }
    }
}
