using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternDemo
{
    class PersonBuilder
    {
        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private int _age { get; set; }
        private int _eyeColor { get; set; }
        private int _hairColor { get; set; }

        public PersonBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _firstName = "John";
            _lastName = "Smith";
            _age = 30;
            _eyeColor = 153;
            _hairColor = 153;
        }

        public PersonBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public PersonBuilder WithAge(int age)
        {
            _age = age;
            return this;
        }

        public PersonBuilder WithEyeColor(int eyeColor)
        {
            _eyeColor = eyeColor;
            return this;
        }

        public PersonBuilder WithHairColor(int hairColor)
        {
            _hairColor = hairColor;
            return this;
        }

        public Person Build()
        {
            Person person = new Person(_firstName, _lastName, _age, _eyeColor, _hairColor);
            return person;
        }
    }
}
