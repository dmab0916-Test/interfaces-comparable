using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Comparable
{
    [TestClass]
    public class CompareTests
    {
        // IComparable is an interface that is widely used within the .net framework. Many collections, lists, array etc. uses this
        // interface to know how to do sort operations.
        class Student : IComparable
        {
            public int Age { get; set; }

            public string Name { get; set; }

            public int CompareTo(object obj)
            {
                // TODO: Implment the CompareTo method, so that unit tests will parse
                // TODO: But do in the test first spirit, only implement enough to make one test pass at a time
                // Hint: you can use the "is" keyword to compare two objects. E.g if(obj is Teacher){ ... } else { exception }
                // Hint: You cna use the as keyword to soft cast (will return null if it fails). E.g. Animal other = obj as Animal

                throw new NotImplementedException("Compare to has not yet been implemented");
            }
        }

        [TestMethod]
        public void SigneTheSameAgeAsGert()
        {

            Student s1 = new Student() { Name = "Signe", Age = 24 };
            Student s2 = new Student() { Name = "Gert", Age = 24 };

            Assert.IsTrue(s1.CompareTo(s2) == 0);
        }

        [TestMethod]
        public void HansIsOlderThanSigne()
        {
            Student s1 = new Student() { Name = "Hans", Age = 30 };
         
            Student s2 = new Student() { Name = "Signe", Age = 24 };


            Assert.IsTrue(s1.CompareTo(s2) == -1);
        }

        [TestMethod]
        public void SigneIsYoungerThanAage()
        {
            Student s1 = new Student() { Name = "Åge", Age = 70 };
            Student s2 = new Student() { Name = "Signe", Age = 24 };

            Assert.IsTrue(s2.CompareTo(s1) == 1);
        }

        [TestMethod]
        public void CustomCompareToMethodBehaveLikeNetCompareToMethod()
        {
            Student s1 = new Student() { Name = "Hans", Age = 30 };
            Student s2 = new Student() { Name = "Åge", Age = 70 };

            int expected = s1.Age.CompareTo(s2.Age);

            int actual = s1.CompareTo(s2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListCanBeSortedAscendingWithYoungestFirst()
        {
            Student s1 = new Student() { Name = "Anne", Age = 24 };
            Student s2 = new Student() { Name = "Hanne", Age = 24 };
            Student s3 = new Student() { Name = "Peter", Age = 30 };
            Student s4 = new Student() { Name = "Jørgen", Age = 70 };

            ArrayList list = new ArrayList() { s3, s4, s3, s1 };
            list.Sort();
            Student actual = list[0] as Student;
            Assert.AreEqual(s1.Age, actual.Age);
        }
    }
}
