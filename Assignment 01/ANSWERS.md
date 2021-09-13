##Generics

Compare the following two methods:

('
int GreaterCount<T, U>(IEnumerable<T> items, T x)
where T : IComparable<T>

int GreaterCount<T, U>(IEnumerable<T> items, T x)
where T : U
where U : IComparable<U>
')

Both methods returns the amount of elements in items which are greater than x.

Explain in your own words what the type constraints mean for both methods:

###Answer:
The type T in the first method must be of a typing that implements the IComparable interface for comparison of that type. If not, an exception will be thrown.

The type T in the second method must be of typing U, and U must be a type that implements the IComparable interface as well, so both T and U are both types that can be compared. 