using System;
using System.Collections.Generic;

namespace Simple.Tests
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func) => new Comparer<U>(func);
    }
    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparsion;
        public Comparer(Func<T, T, bool> func) => comparsion = func;
        public bool Equals(T x, T y) => comparsion(x, y);
        public int GetHashCode(T obj) => obj.GetHashCode();
    }

}
