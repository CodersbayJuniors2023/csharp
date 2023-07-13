using LinkedListTemplate;

MyLinkedList linkedList = new();

linkedList.Insert("a");
linkedList.Insert("b");
linkedList.Insert("c");

foreach (var element in linkedList)
{
   Console.Write(element + " ");
}

Console.WriteLine();

Console.WriteLine(linkedList.ToString());

Console.WriteLine(linkedList.GetIndex("c"));

linkedList.Delete("b");

Console.WriteLine(linkedList.GetIndex("c"));