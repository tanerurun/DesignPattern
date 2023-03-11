using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Employee employee = new Employee();
        employee.Name = "Taner Urun";

        Employee employee2 = new Employee();
        employee2.Name = "Yusuf Poyraz";

        employee.AddSubordinate(employee2);

        Employee employee3 = new Employee();
        employee3.Name = "Ömer Kayra";
        employee.AddSubordinate(employee3);

        foreach (Employee item in employee)
        {
            Console.WriteLine(item.Name);
            foreach (Employee item2 in employee2)
            {
                Console.WriteLine(item2.Name);
            }

        }
    }
}

//bir kurumun calisanlari ve hiyarsisini yapacagiz
interface IPerson
{
    public string Name { get; set; }
}

class Employee : IPerson, IEnumerable<IPerson>
{
    List<IPerson> _subordinates = new List<IPerson>();
    public void AddSubordinate(IPerson person)
    {
        _subordinates.Add(person);
    }

    public void RemoveSubordinate(IPerson person)
    {
        _subordinates.Remove(person);
    }


    public IPerson GetSubordinate(int index)
    {
        return _subordinates[index];
    }
    public string Name { get; set; }

    public IEnumerator<IPerson> GetEnumerator()
    {
        foreach (IPerson person in _subordinates)
        { yield return person; }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
