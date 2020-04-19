using System;
using System.Collections.Generic;
using System.Text;

namespace OnBlickWeeklyChallenges
{
    public static class MultipleInstanceDifferentiator
    {
        public static void Run()
        {
            Console.WriteLine($"{Environment.NewLine}Started MultipleInstanceDifferentiator: ");

            var employee1 = new Employee
            {
                HiredDate = new DateTime(2018, 03, 22),
                Deparment = new Deparment { Name = "Engineering" },
                Email = "abhishek@xyz.com",
                Name = "Abhishek",
                Organizaion = new Organizaion { Name = "XYZ" }
            };

            var employee2 = new Employee
            {
                HiredDate = new DateTime(2018, 03, 28),
                Deparment = new Deparment { Name = "DevOps" },
                Email = "akshay@abc.com",
                Name = "Akshay",
                Organizaion = new Organizaion { Name = "ABC" }
            };

            var differences = employee1.GetDifference(employee2);

            Console.WriteLine(differences.ToString());

        }

        public static StringBuilder GetDifference<T>(this T instance1, T instance2, string instancePath = "")
        {
            var differences = new StringBuilder();

            var instanceType = instance1.GetType();
            instancePath = !string.IsNullOrEmpty(instancePath) ? instancePath + "." + instanceType.Name : instanceType.Name;

            foreach (var instanceProperty in instanceType.GetProperties())
            {
                if (!instanceProperty.CanWrite)
                    continue;

                var typeOfProperty = instanceProperty.PropertyType;
                var instance1PropertyValue = instanceProperty.GetValue(instance1);
                var instance2PropertyValue = instanceProperty.GetValue(instance2);

                if (instance1PropertyValue != null && instance2PropertyValue != null)
                {
                    if (typeOfProperty.IsClass && !typeOfProperty.Namespace.Equals("System"))
                    {
                        var subInstanceDifferences = instance1PropertyValue.GetDifference(instance2PropertyValue, instancePath);
                        differences.Append(subInstanceDifferences.ToString());
                    }
                    else
                    {
                        if (!instance1PropertyValue.Equals(instance2PropertyValue))
                        {
                            differences.Append($"{instancePath}.{instanceProperty.Name}: Instance-1 value: {instance1PropertyValue}; Instance-2 value: {instance2PropertyValue} {Environment.NewLine}");
                        }
                    }
                }
            }

            return differences;
        }
    }

    public class Organizaion
    {
        public string Name { get; set; }
    }

    public class Deparment
    {
        public string Name { get; set; }
    }

    public class Employee
    {
        public DateTime HiredDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Organizaion Organizaion { get; set; }
        public Deparment Deparment { get; set; }
    }

    
}
