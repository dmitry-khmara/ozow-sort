namespace Ozow.Sort.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Please enter a string to sort: ");

            var stringToSort = System.Console.ReadLine();

            var sorter = new Sorter();
            var sortedString = sorter.Sort(stringToSort);

            System.Console.WriteLine("Here is your sorted string: " + sortedString);
        }
    }
}
