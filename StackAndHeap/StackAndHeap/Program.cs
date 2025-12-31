namespace StackAndHeap;

internal class Program
{
    #region [Example Stack] Stack frames and function calls
    int Multiply(int x, int y)
    {
        int result = x * y;
        return result;
    }
    #endregion

    #region [Example Stack] Recursion and stack overflow
    int Factorial(int n)
    {
        if (n == 1)
            return 1;

        return n * Factorial(n - 1);
    }
    #endregion

    #region [Example Heap] Objects living beyond a function
    class Person
    {
        public string Name { get; set; }
    }

    Person CreatePerson()
    {
        return new Person { Name = "Maria" };
    }
    #endregion

    #region [Example] Logical memory leaks
    static List<Person> cache = new();

    void AddPerson()
    {
        cache.Add(new Person());
    }
    #endregion
}
