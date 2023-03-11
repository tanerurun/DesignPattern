internal class Program
{
    private static void Main(string[] args)
    {

        Mediator mediator = new Mediator();
        Teacher teacher = new Teacher(mediator);
        teacher.Name = "Taner";
        mediator.Teacher = teacher;





        Student yusuf = new Student(mediator);
        yusuf.Name = "Poyraz";
        mediator.Student.Add(yusuf);

    }
}

abstract class CourseMember
{
    protected Mediator Mediator;

    protected CourseMember(Mediator mediator)
    {
        Mediator = mediator;
    }
}
class Teacher : CourseMember
{
    public Teacher(Mediator mediator) : base(mediator)
    {

    }
    public string Name { get; set; }


    internal void RecieveQuestion(string question, Student student)
    {
        Console.WriteLine("Teacher received a question from {0} ,{1} ", student.Name, question);

    }
    public void SendNewImageUrl(string url)
    {
        Console.WriteLine("Teacher change slide : {0}", url);
        Mediator.UpdateImage(url);
    }

    public void AnswerQuestion(string answer, Student student)
    {
        Console.WriteLine("Teacher answer  question {0},{1}", student.Name, answer);

    }


}
class Student : CourseMember
{
    public Student(Mediator mediator) : base(mediator)
    {
    }

    public string Name { get; internal set; }

    internal void RecieveImage(string url)
    {
        Console.WriteLine("Studnet receive Image");
    }

    internal void ReceiveAnswer()
    {
        Console.WriteLine("Studnet receive answer");
    }
}
class Mediator
{
    public Teacher Teacher { get; set; }
    List<Student> Students { get; set; }

    public void UpdateImage(string url)
    {
        foreach (var student in Students)
        {
            student.RecieveImage(url);
        }
    }


    public void SendQuestion(string question, Student student)
    {
        Teacher.RecieveQuestion(question, student);
    }


    public void SendAnswer(string answer, Student student)
    {
        student.ReceiveAnswer();
    }
}