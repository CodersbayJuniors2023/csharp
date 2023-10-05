namespace HelloLinq
{
    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }

    class Program
    {
        static readonly List<Student> students = new()
        {
            new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };

        static void Main()
        {
            // first score greater 90 and the fourth greater 80. Result descending by the first score.
            var studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] > 80
                orderby student.Scores[0] descending
                select student;

            foreach (var student in studentQuery)
            {
                Console.WriteLine("{0}, {1}, {2}", student.First, student.Last, student.Scores[0]);
            }

            // group the student's first letter of their last name and order the the results by the group key
            var studentQuery2 =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"{student.First}, {student.Last}");
                }
            }

            // returns those students whose first test score was higher than their average score
            var studentQuery3 =
                from student in students
                let totalScore = student.Scores.Sum()
                where totalScore / student.Scores.Count < student.Scores[0]
                select student.First + " " + student.Last;

            foreach (var student in studentQuery3)
            {
                Console.WriteLine(student);
            }

            // average scrore from all students
            var studentQuery4 =
                from student in students
                select student.Scores.Sum() / 4;

            double averageScore = studentQuery4.Average();

            // students whose total score is greater then the average.
            // create an anonymous type with an id an the score.
            var studentQuery5 =
                from student in students
                let totalScoreAverage = student.Scores.Sum() / 4
                where totalScoreAverage > averageScore
                orderby totalScoreAverage descending
                select new { id = student.ID, score = totalScoreAverage };

            Console.WriteLine($"Average from all students: {averageScore}");
            foreach (var anonymStudent in studentQuery5)
            {
                Console.WriteLine($"Student ID: {anonymStudent.id} Score: {anonymStudent.score}");
            }

        }
    }

}
