using System;
using System.Collections.Generic;

namespace Assignment1
{
    public static class Iterators
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            foreach (var i in items){//var i is IEnumerable<IEnumerable<T>>
                foreach (T j in i) {
                    yield return j;
                }
            }
        }
//yield moves found elements to th ienumerable return statement in constructor
        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var i in items){
                if(predicate(i)){
                    yield return i;
                }
            }
        }
    }
}
