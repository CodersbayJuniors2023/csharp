namespace LinkedListTemplate;

public interface IMyList
{
    /// <summary>
    /// Inserts an element at the end of the list.
    /// </summary>
    /// <param name="element">Element to store.</param>
    void Insert(string element);

    /// <summary>
    /// Finds the element in the list.
    /// </summary>
    /// <para>Element to find.</para>
    /// <returns>Returns the index of the element. -1 otherwise.</returns>
    int GetIndex(string element);

    /// <summary>
    /// Deletes the element.
    /// </summary>
    /// <param name="element">Element to delete.</param>
    /// <returns>true if deletion was possible, false otherwise.</returns>
    bool Delete(string element);

    /// <summary>
    /// Checks if the list contains an element.
    /// </summary>
    /// <param name="element"></param>
    /// <returns>True if the element is in the list, false otherwise.</returns>
    bool Contains(string element);
}